using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using senai.peoples.WebApi.Domains;
using senai.peoples.WebApi.Interfaces;
using senai.peoples.WebApi.Repository;

namespace senai.peoples.WebApi.Controller
{
     [Produces("application/json")]

     [Route("api/[controller]")]

     [ApiController]
     
     public class FuncionarioController: ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public List<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDomain nfuncionario)
        {
            _funcionarioRepository.CadastrarFuncionario(nfuncionario);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Esse funcionario não foi encontrado");
            }

          return Ok(funcionarioBuscado);
        }

        [HttpPut]
        public IActionResult PutIdCorpo(FuncionarioDomain funcionarioAtualizado)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarId(funcionarioAtualizado.id_funcionario);

            if (funcionarioBuscado != null)
            {
                try
                {
                    _funcionarioRepository.AtualizarFuncionarioCad(funcionarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }

            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionário não encontrado",
                        erro = true
                    }
                );
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
        {

            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarId(id);

          
            if (funcionarioBuscado == null)
            {

                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionário não encontrado",
                            erro = true
                        }
                    );
            }

           
            try
            {
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _funcionarioRepository.DeletarFuncionario(id);

            return Ok("Funcionario excluido");
        }
     }
















}