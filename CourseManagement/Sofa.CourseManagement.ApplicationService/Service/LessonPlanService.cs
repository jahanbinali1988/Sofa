using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.LessonPlan;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Enum;
using Sofa.SharedKernel.Log;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class LessonPlanService : ILessonPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonPlanDomainService _lessonPlanDomainService;
        private readonly IBusControl _busControl;
        public LessonPlanService(IUnitOfWork unitOfWork, ILessonPlanDomainService lessonPlanDomainService, IBusControl busControl)
        {
            this._unitOfWork = unitOfWork;
            this._lessonPlanDomainService = lessonPlanDomainService;
            this._busControl = busControl;
        }

        public AddLessonPlanResponse AddLessonPlan(AddLessonPlanRequest request)
        {
            try
            {
                request.Validate();

                this._lessonPlanDomainService.CanAdd(request.Title);
                var lessonPlan = LessonPlan.DefaultFactory(request.Title, (LevelEnum)request.Level, request.IsActive);

                this._unitOfWork.lessonPlanRepository.Add(lessonPlan);
                this._unitOfWork.Commit();

                _busControl.Publish<RegisterLessonPlanEvent>(new RegisterLessonPlanEvent() {
                    Description = "Created in CourseManagement Module",
                    Id = lessonPlan.Id,
                    IsActive = lessonPlan.IsActive,
                    Level = (short)lessonPlan.Level,
                    Title = lessonPlan.Title
                });
                return new AddLessonPlanResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = lessonPlan.Id };
            }
            catch (BusinessException e)
            {
                Logger.Log("BusinessException", "CourseManagement", "LessonPlan", "AddLessonPlan", e.Message);
                return new AddLessonPlanResponse(false, e.Message);
            }
            catch (Exception e)
            {
                Logger.Log("Exception", "CourseManagement", "LessonPlan", "AddLessonPlan", e.Message);
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
                Logger.Log("BusinessException", "CourseManagement", "LessonPlan", "Get", e.Message);
                return new GetLessonPlanByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                Logger.Log("Exception", "CourseManagement", "LessonPlan", "Get", e.Message);
                return new GetLessonPlanByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
