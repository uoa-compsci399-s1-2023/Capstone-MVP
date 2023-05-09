using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Capstone_MVP.Data;
using System.Net.Http.Headers;
using System.Text;
using Capstone_MVP.Model;
using System.Security.Claims;

namespace Capstone_MVP.Handler
{
    public class Capstone_MVPAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ICapstone_MVPRepo rep;

        public Capstone_MVPAuthHandler(
            ICapstone_MVPRepo repository,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            rep = repository;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                Response.Headers.Add("WWW-Authenticate", "Basic");
                return AuthenticateResult.Fail("Authorization header not found.");
            }
            else
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");
                var email = credentials[0];
                var password = credentials[1];

                if (rep.AdminValidLogin(email, password))
                {
                    var claims = new[] { new Claim("admin", email) };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else if (rep.StudentValidLogin(email, password))
                {
                    var claims = new[] { new Claim("student", email) };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else if (rep.VisitorValidLogin(email, password))
                {
                    var claims = new[] { new Claim("visitor", email) };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    Response.Headers.Add("WWW-Authenticate", "Basic");
                    return AuthenticateResult.Fail("userName and password do not match");
                }
            }
        }
    }
}
