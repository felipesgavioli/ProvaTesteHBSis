using ProvaHBSis.Application.Interface;
using ProvaHBSis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace ProvaHBSis.Api
{
    public class BasicAuthModule : IHttpModule
    {
        private const string Realm = "AuthService";

        private readonly IUsuarioAppService _usuarioAppService;


        public BasicAuthModule(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static void SetLogedUser(Usuario usuario)
        {
            Usuario usuarioAutenticadoModel = (Usuario)usuario;

            HttpContext.Current.Items.Add("Usuario", usuario);

            //SetPrincipal(new GenericPrincipal(usuarioAutenticadoModel, null));
        }

        private static void AuthenticateUser(string credentials)
        {
            try
            {
                if (HttpContext.Current.User == null)
                {
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    credentials = encoding.GetString(Convert.FromBase64String(credentials));

                    int separator = credentials.IndexOf(':');
                    string name = credentials.Substring(0, separator);
                    string password = credentials.Substring(separator + 1);
                    name = name.Replace(".", "").Replace("-", "").Replace("\\", "");

                    Usuario usuario = new Usuario { Nome = name, Senha = password };

                    if (usuario != null)
                        SetLogedUser(usuario);
                    else
                    {
                        HttpContext.Current.Response.StatusCode = 401;
                    }
                }
                else if (HttpContext.Current.User != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    HttpContext.Current.Response.StatusCode = 401;
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write("Erro para autenticar o usuário.");

            }

            HttpContext.Current.Response.TrySkipIisCustomErrors = true;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            var token = request["token"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);


                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
                else if (authHeaderVal.Scheme.Equals("bearer", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    SetUserData(request.Headers["UserData"]);
                }
            }
            else if (!String.IsNullOrEmpty(token))
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                var userDataToken = encoding.GetString(Convert.FromBase64String(token));
                SetUserData(userDataToken);
            }
            else
            {
                if (HttpContext.Current.Request.Headers["Origin"] != null)
                    HttpContext.Current.Response.Headers["Access-Control-Allow-Origin"] = HttpContext.Current.Request.Headers["Origin"];
            }
        }

        private static void SetUserData(string data)
        {
            Usuario usuarioDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(data);

            if (usuarioDTO != null)
                SetLogedUser(usuarioDTO);
            else
                HttpContext.Current.Response.StatusCode = 400;
        }

        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",
                    string.Format("Basic realm=\"{0}\"", Realm));
            }

            if (HttpContext.Current.Request.Headers["Origin"] != null)
                response.Headers["Access-Control-Allow-Origin"] = HttpContext.Current.Request.Headers["Origin"];

        }
    }

}