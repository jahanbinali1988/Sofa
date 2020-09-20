using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.LessonPlan;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Enum;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class LessonPlanService : ILessonPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonPlanDomainService _lessonPlanDomainService;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;
        public LessonPlanService(IUnitOfWork unitOfWork, ILessonPlanDomainService lessonPlanDomainService, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._lessonPlanDomainService = lessonPlanDomainService;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddLessonPlanResponse AddLessonPlan(AddLessonPlanRequest request)
        {
            try
            {
                request.Validate();

                var lessonPlan = LessonPlan.DefaultFactory((LevelEnum)request.Level, request.IsActive);

                this._unitOfWork.lessonPlanRepository.Add(lessonPlan);
                this._unitOfWork.Commit();

                _busControl.Publish<RegisterLessonPlanEvent>(new RegisterLessonPlanEvent() {
                    Description = "Created in CourseManagement Module",
                    Id = lessonPlan.Id,
                    IsActive = lessonPlan.IsActive,
                    Level = (short)lessonPlan.Level
                });
                return new AddLessonPlanResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = lessonPlan.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-LessonPlan Service-Add LessonPlan ", e.Message);
                return new AddLessonPlanResponse(false, e.Message);
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-LessonPlan Service-Add LessonPlan ", e.Message);
                return new AddLessonPlanResponse(false, e.Message);
            }
        }

        public GetLessonPlanByIdResponse Get(GetLessonPlanByIdRequest request)
        {
            try
            {
                request.Validate();

                var lessonPlan = this._unitOfWork.lessonPlanRepository.Get(request.LessonPlanId);
                return new GetLessonPlanByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { LessonPlan = lessonPlan.Convert() };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-LessonPlan Service-Get LessonPlan ", e.Message);
                return new GetLessonPlanByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-LessonPlan Service-Get LessonPlan ", e.Message);
                return new GetLessonPlanByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
