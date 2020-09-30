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

        public DeleteSessionResponse Delete(DeleteSessionRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.sessionRepository.Remove(request.Id);
                this._unitOfWork.Commit();

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
    }
}
