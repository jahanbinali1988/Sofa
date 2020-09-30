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
    public class TermService : ITermService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITermDomainService _termDomainService;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public TermService(IUnitOfWork unitOfWork, ITermDomainService termDomainService, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            _termDomainService = termDomainService;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddTermResponse AddTerm(AddTermRequest request)
        {
            try
            {
                request.Validate();
                _termDomainService.CanAdd(request.Title);

                var term = Term.CreateInstance(null, request.Title, request.IsActive, request.CourseId, request.Description);
                this._unitOfWork.termRepository.Add(term);
                this._unitOfWork.Commit();

                return new AddTermResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = term.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Add Term ", e.Message);
                return new AddTermResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Add Term ", e.Message);
                return new AddTermResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public DeleteTermResponse Delete(DeleteTermRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.termRepository.Remove(request.Id);
                this._unitOfWork.Commit();

                return new DeleteTermResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Delete Term ", e.Message);
                return new DeleteTermResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Delete Term ", e.Message);
                return new DeleteTermResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetTermByIdResponse Get(GetTermByIdRequest request)
        {
            try
            {
                request.Validate();

                var term = this._unitOfWork.termRepository.Get(request.TermId);
                var result = term.Convert();
                return new GetTermByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Term = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Get Term ", e.Message);
                return new GetTermByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Get Term ", e.Message);
                return new GetTermByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetAllTermResponse GetAll(GetAllTermRequest request)
        {
            try
            {
                request.Validate();

                var term = this._unitOfWork.termRepository.GetAll();
                var result = term.Convert();
                return new GetAllTermResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Terms = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-GetAll Term ", e.Message);
                return new GetAllTermResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-GetAll Term ", e.Message);
                return new GetAllTermResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdateTermResponse Update(UpdateTermRequest request)
        {
            try
            {
                request.Validate();

                var term = Term.CreateInstance(request.Id, request.Title, request.IsActive, request.CourseId, request.Description);
                this._unitOfWork.termRepository.Update(term);
                this._unitOfWork.Commit();

                return new UpdateTermResponse(true, "ویرایش با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Update Term ", e.Message);
                return new UpdateTermResponse(false, "ویرایش با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Update Term ", e.Message);
                return new UpdateTermResponse(false, "ویرایش با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
