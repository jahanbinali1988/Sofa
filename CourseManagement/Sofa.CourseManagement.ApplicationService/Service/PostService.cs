using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.Post;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Enum;
using Sofa.SharedKernel.Validation;
using System;
using Sofa.SharedKernel;

namespace Sofa.CourseManagement.ApplicationService
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostDomainService _postDomainService;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;
        public PostService(IUnitOfWork unitOfWork, IPostDomainService postDomainService, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._postDomainService = postDomainService;
            this._busControl = busControl;
            this._logger = logger;
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
                this._logger.Warning("Course Management-Post Service-Add Post ", e.Message);
                return new AddPostResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), new Guid());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Post Service-Add Post ", e.Message);
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
                this._logger.Warning("Course Management-Post Service-Get Post ", e.Message);
                return new GetPostByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Post Service-Get Post ", e.Message);
                return new GetPostByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
