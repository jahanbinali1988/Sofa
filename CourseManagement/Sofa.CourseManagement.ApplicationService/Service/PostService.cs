using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.Post;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Enum;
using Sofa.SharedKernel.Log;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostDomainService _postDomainService;
        private readonly IBusControl _busControl;
        public PostService(IUnitOfWork unitOfWork, IPostDomainService postDomainService, IBusControl busControl)
        {
            this._unitOfWork = unitOfWork;
            this._postDomainService = postDomainService;
            this._busControl = busControl;
        }

        public AddPostResponse AddPost(AddPostRequest request)
        {
            try
            {
                request.Validate();

                this._postDomainService.CanAdd(request.Title);
                var post = Post.DefaultFactory(request.Title, request.Order, (PostTypeEnum)request.PostType, request.LessonId, request.IsActive);

                this._unitOfWork.postRepository.Add(post);
                this._unitOfWork.Commit();

                _busControl.Publish<RegisterPostEvent>(new RegisterPostEvent() {
                    LessonId = post.LessonId,
                    Order = post.Order,
                    PostType = (short)post.PostType,
                    Title = post.Title,
                    Description = "Created in CourseManagement Module",
                    Id = post.Id,
                    IsActive = post.IsActive
                });

                return new AddPostResponse(true, "ثبت با موفقیت انجام شد", "", post.Id);
            }
            catch (BusinessException e)
            {
                Logger.Log("BusinessException", "CourseManagement", "Post", "AddPost", e.Message);
                return new AddPostResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), new Guid());
            }
            catch (Exception e)
            {
                Logger.Log("Exception", "CourseManagement", "Post", "AddPost", e.Message);
                return new AddPostResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), new Guid());
            }
        }

        public GetPostByIdResponse Get(GetPostByIdRequest request)
        {
            try
            {
                request.Validate();

                var post = this._unitOfWork.postRepository.Get(request.PostId);
                return new GetPostByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Post = post.Convert() };
            }
            catch (BusinessException e)
            {
                Logger.Log("BusinessException", "CourseManagement", "Post", "Get", e.Message);
                return new GetPostByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                Logger.Log("Exception", "Booking", "Post", "Get", e.Message);
                return new GetPostByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
