﻿using MassTransit;
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
        private readonly IFieldDomainService _fieldDomainService;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public FieldService(IUnitOfWork unitOfWork, IFieldDomainService fieldDomainService, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._fieldDomainService = fieldDomainService;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddFieldResponse AddField(AddFieldRequest request)
        {
            try
            {
                request.Validate();
                _fieldDomainService.CanAdd(request.Title);

                var field = Field.CreateInstance(null, request.Title, request.IsActive, request.InstituteId);
                this._unitOfWork.fieldRepository.Add(field);
                this._unitOfWork.Commit();

                return new AddFieldResponse(true, "ثبت با موفقیت انجام شد", null) { NewRecordedId = field.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Field Service-Add Field ", e.Message);
                return new AddFieldResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Field Service-Add Field ", e.Message);
                return new AddFieldResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public DeleteFieldResponse Delete(DeleteFieldRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.fieldRepository.SafeDelete(request.Id);
                this._unitOfWork.Commit();

                return new DeleteFieldResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Field Service-Delete Field ", e.Message);
                return new DeleteFieldResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Field Service-Delete Field ", e.Message);
                return new DeleteFieldResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
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

        public GetAllFieldResponse GetAll(GetAllFieldRequest request)
        {
            try
            {
                request.Validate();

                var fields = this._unitOfWork.fieldRepository.GetAll();
                var result = fields.Convert();
                return new GetAllFieldResponse(true, "دریافت اطلاعات با موفقیت انجام شد") { Fields = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Field Service-GetAll Field ", e.Message);
                return new GetAllFieldResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Field Service-GetAll Field ", e.Message);
                return new GetAllFieldResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdateFieldResponse Update(UpdateFieldRequest request)
        {
            try
            {
                request.Validate();

                var field = Field.CreateInstance(request.Id, request.Title, request.IsActive, request.InstituteId);
                this._unitOfWork.fieldRepository.Update(field);
                this._unitOfWork.Commit();

                return new UpdateFieldResponse(true, "به روز رسانی با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Field Service-Update Field ", e.Message);
                return new UpdateFieldResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Field Service-Update Field ", e.Message);
                return new UpdateFieldResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
