using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int id_funcionario { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
