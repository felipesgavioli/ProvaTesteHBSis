

using System.Collections.Generic;
using System.Linq;
using ProvaHBSis.Domain.Entities;
using ProvaHBSis.Domain.Interfaces.Repositories;
using ProvaHBSis.Domain.Interfaces.Services;

namespace ProvaHBSis.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository =usuarioRepository;
        }
    }
}
