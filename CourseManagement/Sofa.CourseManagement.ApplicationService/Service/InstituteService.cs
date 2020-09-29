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
                var institute = Institute.CreateInstance(null, request.Title, request.IsActive, request.Code);
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

        public GetInstituteByIdResponse Get(GetInstituteByIdRequest request)
        {
            try
            {
                request.Validate();

                var institute = this._unitOfWork.instituteRepository.Get(request.InstituteId);
                var result = institute.Convert();
                return new GetInstituteByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Institute =  result};
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
    }
}
