using Sofa.Identity.Repository;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.Identity.ApplicationService
{
    public class ProfileService : IProfileService
    {
        readonly IEfUnitOfWork efUnitOfWork;
        readonly IDapperUnitOfWork dapperUnitOfWork;
        readonly ILogger logger;
        public ProfileService(IEfUnitOfWork efUnitOfWork, IDapperUnitOfWork dapperUnitOfWork, ILogger logger)
        {
            this.efUnitOfWork = efUnitOfWork;
            this.dapperUnitOfWork = dapperUnitOfWork;
            this.logger = logger;
        }

        public GetCurrentUserInfoResponse GetCurrentUserInfo(GetCurrentUserInfoRequest request)
        {
            try
            {
                request.Validate().ThrowIfNotValid(true);
                var user = dapperUnitOfWork.Users.Get(request.CommanderID);

                if (user == null)
                    throw new ValidationException("کاربر با این شناسه یافت نشد.");

                return new GetCurrentUserInfoResponse(true, "") { UserProfile = user.ToInfoViewModel() };
            }
            catch (ValidationException mex)
            {
                logger.Exception(mex, "ProfileService.GetCurrentUserInfo");
                logger.Information("{@a}", request);
                return new GetCurrentUserInfoResponse(false, mex.Message);
            }
            catch (BusinessException bex)
            {
                logger.Exception(bex, "ProfileService.GetCurrentUserInfo");
                logger.Information("{@a}", request);
                return new GetCurrentUserInfoResponse(false, bex.Message);
            }
            catch (Exception ex)
            {
                logger.Exception(ex, "ProfileService.GetCurrentUserInfo");
                logger.Information("{@a}", request);
                return new GetCurrentUserInfoResponse(false, "به دلیل بروز خطا امکان بازیابی اطلاعات وجود ندارد.");
            }
        }
    }
}
