using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.Course;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseDomainService _courseDomainService;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public CourseService(IUnitOfWork unitOfWork, ICourseDomainService courseDomainService, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._courseDomainService = courseDomainService;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddCourseResponse AddCourse(AddCourseRequest request)
        {
            try
            {
                request.Validate();
                _courseDomainService.CanAdd(request.Title);

                var course = Course.CreateInstance(null, request.Title, request.AgeRange, request.FieldId, request.IsActive, request.Description);
                this._unitOfWork.courseRepository.Add(course);
                this._unitOfWork.Commit();
                this._busControl.Publish<RegisterCourseEvent>(new RegisterCourseEvent()
                {
                    Description = "Created in CourseManagement module",
                    Id = course.Id,
                    CreateDate = course.CreateDate,
                    IsActive = course.IsActive,
                    IsDeleted = course.IsDeleted,
                    ModifiedDate = course.ModifyDate,
                    Title = course.Title,
                    AgeRange = (short)course.AgeRange,
                    FieldId = course.FieldId
                });

                return new AddCourseResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = course.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Course Service-Add Course ", e.Message);
                return new AddCourseResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Course Service-Add Course ", e.Message);
                return new AddCourseResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public DeleteCourseResponse Delete(DeleteCourseRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.courseRepository.SafeDelete(request.Id);
                this._unitOfWork.Commit();
                this._busControl.Publish<UpdateCourseIsDeletedStatusEvent>(new UpdateCourseIsDeletedStatusEvent()
                {
                    Id = request.Id
                });

                return new DeleteCourseResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Course Service-Delete Course ", e.Message);
                return new DeleteCourseResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Course Service-Delete Course ", e.Message);
                return new DeleteCourseResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetCourseByIdResponse Get(GetCourseByIdRequest request)
        {
            try
            {
                request.Validate();

                var course = this._unitOfWork.courseRepository.Get(request.CourseId);
                var result = course.Convert();
                return new GetCourseByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Course = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Course Service-Get Course ", e.Message);
                return new GetCourseByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Course Service-Get Course ", e.Message);
                return new GetCourseByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetAllCourseResponse GetAll(GetAllCourseRequest request)
        {
            try
            {
                request.Validate();

                var courses = this._unitOfWork.courseRepository.GetAll();
                var result = courses.Convert();
                return new GetAllCourseResponse(true, "دریافت اطلاعات با موفقیت انجام شد") { Courses = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Course Service-GetAll Course ", e.Message);
                return new GetAllCourseResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Course Service-GetAll Course ", e.Message);
                return new GetAllCourseResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdateCourseResponse Update(UpdateCourseRequest request)
        {
            try
            {
                request.Validate();

                var course = Course.CreateInstance(request.Id, request.Title, request.AgeRange, request.FieldId, request.IsActive, string.Empty);
                this._unitOfWork.courseRepository.Update(course);
                this._unitOfWork.Commit();
                this._busControl.Publish<RegisterCourseEvent>(new RegisterCourseEvent()
                {
                    Description = "Updated in CourseManagement module",
                    Id = course.Id,
                    CreateDate = course.CreateDate,
                    IsActive = course.IsActive,
                    IsDeleted = course.IsDeleted,
                    ModifiedDate = course.ModifyDate,
                    Title = course.Title,
                    AgeRange = (short)course.AgeRange,
                    FieldId = course.FieldId
                });

                return new UpdateCourseResponse(true, "به روز رسانی با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Course Service-Update Course ", e.Message);
                return new UpdateCourseResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Course Service-Update Course ", e.Message);
                return new UpdateCourseResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public ChangeActiveStatusCourseResponse ChangeActiveStatus(ChangeActiveStatusCourseRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.courseRepository.ChangeActiveStatus(request.Id);
                this._unitOfWork.Commit();
                this._busControl.Publish<UpdateCourseIsActiveStatusEvent>(new UpdateCourseIsActiveStatusEvent()
                {
                    Id = request.Id
                });

                return new ChangeActiveStatusCourseResponse(true, "به روزرسانی با موفقیت انجام شد.");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Course Service-ChangeActiveStatus ", e.Message);
                return new ChangeActiveStatusCourseResponse(false, "به روزرسانی با موفقیت انجام شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Course Service-ChangeActiveStatus ", e.Message);
                return new ChangeActiveStatusCourseResponse(false, "به روزرسانی با موفقیت انجام شد.", e.Message.ToString());
            }
        }

        public SearchCourseResponse Search(SearchCourseRequest request)
        {
            try
            {
                var course = this._unitOfWork.courseRepository.QueryPage(request.PageIndex, request.PageSize,
                    (c => c.Title.StartsWith(request.Caption)));
                var result = course.Convert();
                return new SearchCourseResponse(true, "عملیات خواندن با موفقیت انجام شد") { Courses = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Course Service-Search ", e.Message);
                return new SearchCourseResponse(false, "عملیات خواندن با موفقیت انجام شد", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Course Service-Search ", e.Message);
                return new SearchCourseResponse(false, "عملیات خواندن با موفقیت انجام شد", e.Message.ToString());
            }
        }
    }
}
