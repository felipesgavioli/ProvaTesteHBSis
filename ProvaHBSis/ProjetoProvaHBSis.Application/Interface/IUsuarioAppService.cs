
using System.Collections.Generic;
using ProvaHBSis.Domain.Entities;

namespace ProvaHBSis.Application.Interface
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        bool VerificaUsuario(string nome, string senha);
    }
}
