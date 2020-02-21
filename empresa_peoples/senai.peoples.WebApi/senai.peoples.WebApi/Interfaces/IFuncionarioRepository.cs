using senai.peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        void CadastrarFuncionario (FuncionarioDomain funcionario);

        void AtualizarFuncionarioCad(FuncionarioDomain funcionario);

        void DeletarFuncionario(int id);

        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);

        FuncionarioDomain BuscarId(int id);


    }
}
