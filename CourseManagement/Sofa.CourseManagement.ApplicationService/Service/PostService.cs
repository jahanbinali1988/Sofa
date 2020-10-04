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
                var post = Post.CreateInstance(null, request.Title, request.Order, (ContentTypeEnum)request.ContentType, request.Content, request.LessonPlanId, request.IsActive, request.Description);

                this._unitOfWork.postRepository.Add(post);
                this._unitOfWork.Commit();

                _busControl.Publish<RegisterPostEvent>(new RegisterPostEvent() {
                    Order = post.Order,
                    PostType = (short)post.ContentType,
                    Title = post.Title,
                    Description = "Created in CourseManagement Module",
                    Id = post.Id,
                    IsActive = post.IsActive
                });

                return new AddPostResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = post.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Post Service-Add Post ", e.Message);
                return new AddPostResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Post Service-Add Post ", e.Message);
                return new AddPostResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public DeletePostResponse Delete(DeletePostRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.postRepository.SafeDelete(request.Id);
                this._unitOfWork.Commit();

                return new DeletePostResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Post Service-Delete Post ", e.Message);
                return new DeletePostResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Post Service-Delete Post ", e.Message);
                return new DeletePostResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetPostByIdResponse Get(GetPostByIdRequest request)
        {
            try
            {
                request.Validate();

                var post = this._unitOfWork.postRepository.Get(request.PostId);
                var result = post.Convert();
                return new GetPostByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Post = result };
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

        public GetAllPostResponse GetAll(GetAllPostRequest request)
        {
            try
            {
                request.Validate();

                var posts = this._unitOfWork.postRepository.GetAll();
                var result = posts.Convert();
                return new GetAllPostResponse(true, "دریافت اطلاعات با موفقیت انجام شد") { Posts = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Post Service-GetAll Post ", e.Message);
                return new GetAllPostResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Post Service-GetAll Post ", e.Message);
                return new GetAllPostResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdatePostResponse Update(UpdatePostRequest request)
        {
            try
            {
                request.Validate();

                var post = Post.CreateInstance(request.Id, request.Title, request.Order, (ContentTypeEnum)request.ContentType, request.Content, request.LessonPlanId, request.IsActive, request.Description);
                this._unitOfWork.postRepository.Update(post);
                this._unitOfWork.Commit();

                return new UpdatePostResponse(true, "به روز رسانی با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Post Service-Update Post ", e.Message);
                return new UpdatePostResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Post Service-Update Post ", e.Message);
                return new UpdatePostResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
