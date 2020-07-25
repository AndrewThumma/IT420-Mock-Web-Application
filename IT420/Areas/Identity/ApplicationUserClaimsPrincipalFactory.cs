using IT420.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IT420.Areas.Identity
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserProfile>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<UserProfile> userManager, IOptions<IdentityOptions> options )
            : base (userManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserProfile user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("firstName", user.firstName.ToString()));
            identity.AddClaim(new Claim("lastName", user.lastName.ToString()));
            identity.AddClaim(new Claim("IsExpert", user.IsExpert.ToString()));
            identity.AddClaim(new Claim("IsAdmin", user.IsAdmin.ToString()));
            return identity;
        }
    }
}
