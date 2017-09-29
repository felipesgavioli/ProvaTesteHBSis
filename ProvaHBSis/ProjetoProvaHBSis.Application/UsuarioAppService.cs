

using System.Collections.Generic;
using ProvaHBSis.Application.Interface;
using ProvaHBSis.Domain.Entities;
using ProvaHBSis.Domain.Interfaces.Services;
using System;

namespace ProvaHBSis.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public bool VerificaUsuario(string nome, string senha)
        {
            try
            {
                Usuario user = this.Get(e => e.Nome.Equals(nome) && e.Senha.Equals(senha));
                if (user == null)
                    return false;
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro para consultar usuário ou senha.");
            }
        }
       
    }
}
