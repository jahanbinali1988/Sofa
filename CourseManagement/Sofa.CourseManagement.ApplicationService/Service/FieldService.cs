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
    public class FieldService : IFieldService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public FieldService(IUnitOfWork unitOfWork, IBusControl busControl, ILogger logger)//
        {
            this._unitOfWork = unitOfWork;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddFieldResponse AddField(AddFieldRequest request)
        {
            try
            {
                request.Validate();

                var field = Field.CreateInstance(request.Title, request.IsActive, request.InstituteId);
                this._unitOfWork.fieldRepository.Add(field);
                this._unitOfWork.Commit();

                return new AddFieldResponse(true, "ثبت با موفقیت انجام شد", null, field.Id);
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Field Service-Add Field ", e.Message);
                return new AddFieldResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), Guid.Empty);
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Field Service-Add Field ", e.Message);
                return new AddFieldResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString(), Guid.Empty);
            }
        }

        public GetFieldByIdResponse Get(GetFieldByIdRequest request)
        {
            try
            {
                request.Validate();

                var institute = this._unitOfWork.fieldRepository.Get(request.FieldId);
                var result = institute.Convert();
                return new GetFieldByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Field = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Field Service-Get Field ", e.Message);
                return new GetFieldByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Field Service-Get Field ", e.Message);
                return new GetFieldByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
