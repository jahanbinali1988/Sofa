﻿using MassTransit;
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

                var lessonPlan = LessonPlan.CreateInstance(null, (LevelEnum)request.Level, request.IsActive, string.Empty);
                this._unitOfWork.lessonPlanRepository.Add(lessonPlan);
                this._unitOfWork.Commit();

                _busControl.Publish<RegisterLessonPlanEvent>(new RegisterLessonPlanEvent()
                {
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
                return new AddLessonPlanResponse(false, "ثبت با مشکل مواجه شده است", e.Message);
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-LessonPlan Service-Add LessonPlan ", e.Message);
                return new AddLessonPlanResponse(false, "ثبت با مشکل مواجه شده است", e.Message);
            }
        }

        public DeleteLessonPlanResponse Delete(DeleteLessonPlanRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.lessonPlanRepository.SafeDelete(request.Id);
                this._unitOfWork.Commit();

                return new DeleteLessonPlanResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-LessonPlan Service-Delete LessonPlan ", e.Message);
                return new DeleteLessonPlanResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-LessonPlan Service-Delete LessonPlan ", e.Message);
                return new DeleteLessonPlanResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
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

        public GetAllLessonPlanResponse GetAll(GetAllLessonPlanRequest request)
        {
            try
            {
                request.Validate();

                var lessonPlans = this._unitOfWork.lessonPlanRepository.GetAll();
                var result = lessonPlans.Convert();
                return new GetAllLessonPlanResponse(true, "دریافت اطلاعات با موفقیت انجام شد") { LessonPlans = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-LessonPlan Service-GetAll LessonPlan ", e.Message);
                return new GetAllLessonPlanResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-LessonPlan Service-GetAll LessonPlan ", e.Message);
                return new GetAllLessonPlanResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdateLessonPlanResponse Update(UpdateLessonPlanRequest request)
        {
            try
            {
                request.Validate();

                var lessonPlan = LessonPlan.CreateInstance(request.Id, (LevelEnum)request.Level, request.IsActive, string.Empty);
                this._unitOfWork.lessonPlanRepository.Update(lessonPlan);
                this._unitOfWork.Commit();

                return new UpdateLessonPlanResponse(true, "به روز رسانی با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-LessonPlan Service-Update LessonPlan ", e.Message);
                return new UpdateLessonPlanResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-LessonPlan Service-Update LessonPlan ", e.Message);
                return new UpdateLessonPlanResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
