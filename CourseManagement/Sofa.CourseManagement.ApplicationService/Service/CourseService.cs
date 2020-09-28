using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public CourseService(IUnitOfWork unitOfWork, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddCourseResponse AddCourse(AddCourseRequest request)
        {
            try
            {
                request.Validate();

                var course = Course.CreateInstance(request.Title, request.AgeRange, request.IsActive, request.FieldId);
                this._unitOfWork.courseRepository.Add(course);
                this._unitOfWork.Commit();

                return new AddCourseResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = course.Id};
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
    }
}
