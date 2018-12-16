using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace Emptor.WebAPI.OAuth.Providers
{
    public class sAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            identity.AddClaim(new Claim("userId", "1"));

            context.Validated(identity);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
        }
    }
}