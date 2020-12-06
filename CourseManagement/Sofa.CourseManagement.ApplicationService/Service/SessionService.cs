using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.Session;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISessionDomainService _sessionDomainService;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public SessionService(IUnitOfWork unitOfWork, ISessionDomainService sessionDomainService, IBusControl busControl, ILogger logger)//
        {
            this._unitOfWork = unitOfWork;
            this._sessionDomainService = sessionDomainService;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddSessionResponse AddSession(AddSessionRequest request)
        {
            try
            {
                request.Validate();

                var session = Session.CreateInstance(null, request.Title, request.IsActive, request.TermId, request.LessonPlanId, request.Description);
                this._unitOfWork.sessionRepository.Add(session);
                this._unitOfWork.Commit();
                _busControl.Publish<RegisterSessionEvent>(new RegisterSessionEvent ()
                {
                    Description = "Created in CourseManagement module",
                    Id = session.Id,
                    IsActive = session.IsActive,
                    IsDeleted = session.IsDeleted,
                    ModifiedDate = session.ModifyDate,
                    CreateDate = session.CreateDate,
                    LessonPlanId = session.LessonPlanId,
                    TermId = session.TermId,
                    Title = session.Title
                });

                return new AddSessionResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = session.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Session Service-Add Session ", e.Message);
                return new AddSessionResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Session Service-Add Session ", e.Message);
                return new AddSessionResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetSessionByIdResponse Get(GetSessionByIdRequest request)
        {
            try
            {
                request.Validate();

                var session = this._unitOfWork.sessionRepository.Get(request.SessionId);
                var result = session.Convert();
                return new GetSessionByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Session = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Session Service-Get Session ", e.Message);
                return new GetSessionByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Session Service-Get Session ", e.Message);
                return new GetSessionByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetAllSessionResponse GetAll(GetAllSessionRequest request)
        {
            try
            {
                request.Validate();

                var term = this._unitOfWork.sessionRepository.GetAll();
                var result = term.Convert();
                return new GetAllSessionResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Sessions = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Session Service-GetAll Session ", e.Message);
                return new GetAllSessionResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Session Service-GetAll Session ", e.Message);
                return new GetAllSessionResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdateSessionResponse Update(UpdateSessionRequest request)
        {
            try
            {
                request.Validate();

                var session = Session.CreateInstance(request.Id, request.Title, request.IsActive, request.LessonPlanId, request.TermId, request.Description);
                this._unitOfWork.sessionRepository.Update(session);
                this._unitOfWork.Commit();
                _busControl.Publish<RegisterSessionEvent>(new RegisterSessionEvent()
                {
                    Description = "Updated in CourseManagement module",
                    Id = session.Id,
                    IsActive = session.IsActive,
                    IsDeleted = session.IsDeleted,
                    ModifiedDate = session.ModifyDate,
                    CreateDate = session.CreateDate,
                    LessonPlanId = session.LessonPlanId,
                    TermId = session.TermId,
                    Title = session.Title
                });

                return new UpdateSessionResponse(true, "ویرایش با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Session Service-Update Session ", e.Message);
                return new UpdateSessionResponse(false, "ویرایش با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Session Service-Update Session ", e.Message);
                return new UpdateSessionResponse(false, "ویرایش با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public DeleteSessionResponse Delete(DeleteSessionRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.sessionRepository.SafeDelete(request.Id);
                this._unitOfWork.Commit();
                this._busControl.Publish<UpdateSessionIsDeletedStatusEvent>(new UpdateSessionIsDeletedStatusEvent()
                {
                    Id = request.Id
                });

                return new DeleteSessionResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Session Service-Delete Session ", e.Message);
                return new DeleteSessionResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Session Service-Delete Session ", e.Message);
                return new DeleteSessionResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public ChangeActiveStatusSessionResponse ChangeActiveStatus(ChangeActiveStatusSessionRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.sessionRepository.ChangeActiveStatus(request.Id);
                this._unitOfWork.Commit();
                this._busControl.Publish<UpdateSessionIsActiveStatusEvent>(new UpdateSessionIsActiveStatusEvent()
                {
                    Id = request.Id
                });

                return new ChangeActiveStatusSessionResponse(true, "به روزرسانی با موفقیت انجام شد.");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Session Service-ChangeActiveStatus ", e.Message);
                return new ChangeActiveStatusSessionResponse(false, "به روزرسانی با موفقیت انجام شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Session Service-ChangeActiveStatus ", e.Message);
                return new ChangeActiveStatusSessionResponse(false, "به روزرسانی با موفقیت انجام شد.", e.Message.ToString());
            }
        }

        public SearchSessionResponse Search(SearchSessionRequest request)
        {
            try
            {
                var sessions = this._unitOfWork.sessionRepository.QueryPage(request.PageIndex, request.PageSize,
                    (c => c.Title.StartsWith(request.Caption)));
                var result = sessions.Convert();
                return new SearchSessionResponse(true, "عملیات خواندن با موفقیت انجام شد") { Sessions = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Session Service-Search ", e.Message);
                return new SearchSessionResponse(false, "عملیات خواندن با موفقیت انجام شد", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Session Service-Search ", e.Message);
                return new SearchSessionResponse(false, "عملیات خواندن با موفقیت انجام شد", e.Message.ToString());
            }
        }
    }
}
