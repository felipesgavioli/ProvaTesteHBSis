

using System.Collections.Generic;
using System.Linq;
using ProvaHBSis.Domain.Entities;
using ProvaHBSis.Domain.Interfaces.Repositories;
using ProvaHBSis.Domain.Interfaces.Services;

namespace ProvaHBSis.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
