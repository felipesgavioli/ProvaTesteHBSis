

using System.Collections.Generic;
using ProvaHBSis.Application.Interface;
using ProvaHBSis.Domain.Entities;
using ProvaHBSis.Domain.Interfaces.Services;

namespace ProvaHBSis.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public void DeleteCliente(int id)
        {
            var user = this.GetById(id);
            if (user != null)
                this.Remove(user);
        }

    }
}
