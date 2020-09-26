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
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public TermService(IUnitOfWork unitOfWork, IBusControl busControl, ILogger logger)//
        {
            this._unitOfWork = unitOfWork;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddTermResponse AddTerm(AddTermRequest request)
        {
            try
            {
                request.Validate();

                var term = Term.CreateInstance(request.Title, request.IsActive, request.CourseId);
                this._unitOfWork.termRepository.Add(term);
                this._unitOfWork.Commit();

                return new AddTermResponse(true, "ثبت با موفقیت انجام شد", null, term.Id);
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Add Term ", e.Message);
                return new AddTermResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), Guid.Empty);
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Add Term ", e.Message);
                return new AddTermResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), Guid.Empty);
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
    }
}
