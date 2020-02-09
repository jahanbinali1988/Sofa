using Sofa.Identity.ApplicationService;
using IdentityModel;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sofa.Identity.WebAPI
{
    public class CustomUserOwnedPasswordValidator : IResourceOwnerPasswordValidator
    {
        readonly IAuthenticationService authenticationService;
        public CustomUserOwnedPasswordValidator(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            GetUserCredentialValidationStatusRequest request = new GetUserCredentialValidationStatusRequest() { UserName = context.UserName, Password = context.Password };

            var response = authenticationService.GetUserCredentialValidationStatus(request);

            if (response.CredentialIsValid)
            {
                IList<Claim> claims = new List<Claim>{
                    new Claim("userId",response.UserId.ToString()),
                    new Claim("userTitle", response.UserTitle)
                };
                context.Result = new GrantValidationResult(response.UserId.ToString(), OidcConstants.AuthenticationMethods.Password, DateTime.Now, claims);

            }

            return Task.CompletedTask;
        }
    }
}
