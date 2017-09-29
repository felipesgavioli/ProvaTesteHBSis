using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using ProvaHBSis.Domain.Entities;
using Microsoft.Owin.Security.OAuth;
using ProvaHBSis.Application.Interface;

namespace ProvaHBSis.Api
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public SimpleAuthorizationServerProvider(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                Usuario user = _usuarioAppService.GetAll().Where(el => el.Nome == context.UserName && el.Senha == context.Password).FirstOrDefault();
                if (user == null)
                {
                    context.SetError("invalid_grant", "Usuário ou Senha inválidos.");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Nome));

                var roles = new List<string>();
                roles.Add("User");

                foreach (var item in roles)
                    identity.AddClaim(new Claim(ClaimTypes.Role, item));

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}
