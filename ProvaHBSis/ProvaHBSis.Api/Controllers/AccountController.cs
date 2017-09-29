using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProvaHBSis.Application.Interface;
using ProvaHBSis.Domain.Entities;
using System.Security.Principal;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Text;

namespace ProvaHBSis.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AccountController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPut]
        public HttpResponseMessage Register(Usuario usuario)
        {
            try
            {
                _usuarioAppService.Add(usuario);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public HttpResponseMessage Login(Usuario usuario)
        {
            try
            {
                if (!_usuarioAppService.VerificaUsuario(usuario.Nome, usuario.Senha))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
      
    }
}
