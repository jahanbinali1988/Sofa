using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.Lesson;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonDomainService _lessonDomainRepository;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;
        public LessonService(IUnitOfWork unitOfWork, ILessonDomainService lessonDomainRepository, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._lessonDomainRepository = lessonDomainRepository;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddLessonResponse AddLesson(AddLessonRequest request)
        {
            try
            {
                request.Validate();

                this._lessonDomainRepository.CanAdd(request.Title);
                var lesson = Lesson.DefaultFactory(request.Title, request.Order, request.LessonPlanId, request.IsActive);

                this._unitOfWork.lessonRepository.Add(lesson);
                this._unitOfWork.Commit();

                this._busControl.Publish<RegisterLessonEvent>(new RegisterLessonEvent() {
                    Id = lesson.Id,
                    IsActive = lesson.IsActive,
                    Description = "Created in CourseManagement Module",
                    LessonPlanId = lesson.LessonPlanId,
                    Order = lesson.Order,
                    Title = lesson.Title
                });

                return new AddLessonResponse(true, "ثبت با موفقیت انجام شد", "", lesson.Id);
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Lesson Service-Add Lesson ", e.Message);
                return new AddLessonResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), new Guid());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Lesson Service-Add Lesson ", e.Message);
                return new AddLessonResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), new Guid());
            }
        }

        public GetLessonByIdResponse Get(GetLessonByIdRequest request)
        {
            try
            {
                request.Validate();

                var lesson = this._unitOfWork.lessonRepository.Get(request.LessonId);
                return new GetLessonByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Lesson = lesson.Convert() };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Lesson Service-Get Lesson ", e.Message);
                return new GetLessonByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Lesson Service-Get Lesson ", e.Message);
                return new GetLessonByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
