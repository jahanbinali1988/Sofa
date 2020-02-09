using System;
using System.Linq;
using System.Security.Claims;

namespace Sofa.Web
{
    public static class ClaimExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            Claim userIdClaim = user.Claims.Where(c => c.Type == "sub").FirstOrDefault();

            if (userIdClaim == null)
                return Guid.Empty;

            return Guid.Parse(userIdClaim.Value);
        }
    }
}
