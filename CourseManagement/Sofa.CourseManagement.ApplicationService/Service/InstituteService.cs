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
    public class InstituteService : IInstituteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInstituteDomainService _instituteDomainService;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public InstituteService(IUnitOfWork unitOfWork, IInstituteDomainService instituteDomainService, IBusControl busControl, ILogger logger)//
        {
            this._unitOfWork = unitOfWork;
            this._instituteDomainService = instituteDomainService;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddInstituteResponse AddInstitute(AddInstituteRequest request)
        {
            try
            {
                request.Validate();

                this._instituteDomainService.CanAdd(request.Title);
                var institute = Institute.CreateInstance(null, request.Title, request.IsActive, request.Code, request.WebsiteUrl, request.Description);
                var address = request.Address.Convert();
                institute.AssignAddress(address);
                this._unitOfWork.instituteRepository.Add(institute);
                this._unitOfWork.Commit();

                return new AddInstituteResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = institute.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Institute Service-Add Institute ", e.Message);
                return new AddInstituteResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Institute Service-Add Institute ", e.Message);
                return new AddInstituteResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public DeleteInstituteResponse Delete(DeleteInstituteRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.instituteRepository.SafeDelete(request.Id);
                this._unitOfWork.Commit();

                return new DeleteInstituteResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Institute Service-Delete Institute ", e.Message);
                return new DeleteInstituteResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Institute Service-Delete Institute ", e.Message);
                return new DeleteInstituteResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetInstituteByIdResponse Get(GetInstituteByIdRequest request)
        {
            try
            {
                request.Validate();

                var institute = this._unitOfWork.instituteRepository.Get(request.InstituteId);
                var result = institute.Convert();
                return new GetInstituteByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Institute = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Institute Service-Get Institute ", e.Message);
                return new GetInstituteByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Institute Service-Get Institute ", e.Message);
                return new GetInstituteByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetAllInstituteResponse GetAll(GetAllInstituteRequest request)
        {
            try
            {
                request.Validate();

                var institutes = this._unitOfWork.instituteRepository.GetAll();
                var result = institutes.Convert();
                return new GetAllInstituteResponse(true, "دریافت اطلاعات با موفقیت انجام شد") { Institutes = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Institute Service-GetAll Institute ", e.Message);
                return new GetAllInstituteResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Institute Service-GetAll Institute ", e.Message);
                return new GetAllInstituteResponse(false, "دریافت اطلاعات با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdateInstituteResponse Update(UpdateInstituteRequest request)
        {
            try
            {
                request.Validate();

                var institute = Institute.CreateInstance(request.Id, request.Title, request.IsActive, request.Code, request.WebsiteUrl, request.Description);
                this._unitOfWork.instituteRepository.Update(institute);
                this._unitOfWork.Commit();

                return new UpdateInstituteResponse(true, "به روز رسانی با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Institute Service-Update Institute ", e.Message);
                return new UpdateInstituteResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Institute Service-Update Institute ", e.Message);
                return new UpdateInstituteResponse(false, "به روز رسانی با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}
