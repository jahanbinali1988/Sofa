using Sofa.Identity.Model;
using Sofa.Identity.Repository;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedSpecs;
using System;

namespace Sofa.Identity.ApplicationService
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IEfUnitOfWork efUnitOfWork;
        readonly IDapperUnitOfWork dapperUnitOfWork;
        readonly ILogger logger;
        public AuthenticationService(IEfUnitOfWork efUnitOfWork, IDapperUnitOfWork dapperUnitOfWork, ILogger logger)
        {
            this.efUnitOfWork = efUnitOfWork;
            this.dapperUnitOfWork = dapperUnitOfWork;
            this.logger = logger;
        }

        public GetUserCredentialValidationStatusResponse GetUserCredentialValidationStatus(GetUserCredentialValidationStatusRequest request)
        {
            try
            {
                //using dapper
                var user = dapperUnitOfWork.Users.GetByUserName(request.UserName);
                //using EF
                //var user = efUnitOfWork._userRepository.GetByUserName(request.UserName);

                EntityIsExistedSpec<User> userExistedSpec = new EntityIsExistedSpec<User>();
                if (!userExistedSpec.IsSatisfiedBy(user))
                    throw new AccessDeniedException("نام کاربری یا کلمه عبور اشتباه است.");

                EntityIsDisableSpec<User> userIsDisableSpec = new EntityIsDisableSpec<User>();
                if (userIsDisableSpec.IsSatisfiedBy(user))
                    throw new AccessDeniedException("نام کاربری یا کلمه عبور اشتباه است.");

                ValidUserPasswordSpec validUserPasswordSpec = new ValidUserPasswordSpec(request.Password);
                if (!validUserPasswordSpec.IsSatisfiedBy(user))
                    throw new AccessDeniedException("نام کاربری یا کلمه عبور اشتباه است.");

                return new GetUserCredentialValidationStatusResponse(true, "مشخصات ورود به حساب کاربری معتبر است.") { CredentialIsValid = true, UserTitle = user.UserTitle, UserId = user.Id, UserRole = user.Role.ToString() };
            }
            catch (AccessDeniedException ex)
            {
                logger.Exception(ex, "مشخصات ورود به حساب کاربری معتبر نمی‌باشد.");
                return new GetUserCredentialValidationStatusResponse(false, "مشخصات ورود به حساب کاربری معتبر نمی‌باشد.", ex.Message);
            }
            catch (Exception ex)
            {
                logger.Exception(ex, ex.Message);
                return new GetUserCredentialValidationStatusResponse(false, "به دلیل بروز خطا امکان تایید مشخصات ورود به حساب کاربری وجود ندارد. لطفا مجددا تلاش کنید.");
            }

        }
    }
}
