
using System.Collections.Generic;
using ProvaHBSis.Domain.Entities;

namespace ProvaHBSis.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        void DeleteCliente(int id);
    }
}
