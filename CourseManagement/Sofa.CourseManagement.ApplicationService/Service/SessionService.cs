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
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public SessionService(IUnitOfWork unitOfWork, IBusControl busControl, ILogger logger)//
        {
            this._unitOfWork = unitOfWork;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddSessionResponse AddSession(AddSessionRequest request)
        {
            try
            {
                request.Validate();

                var session = Session.CreateInstance(request.Title, request.IsActive, request.TermId, request.LessonPlanId);
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
    }
}
