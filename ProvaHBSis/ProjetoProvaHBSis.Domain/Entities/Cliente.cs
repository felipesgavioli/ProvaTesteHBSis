using System;
using System.Collections.Generic;

namespace ProvaHBSis.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        //foi usado string por causa do tamanho do cnpj
        public string CpfCnpj { get; set; }
        public long Telefone { get; set; }        
    }
}
