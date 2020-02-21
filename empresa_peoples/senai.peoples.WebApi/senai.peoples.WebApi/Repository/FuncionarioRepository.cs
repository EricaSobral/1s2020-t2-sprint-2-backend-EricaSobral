using senai.peoples.WebApi.Domains;
using senai.peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.peoples.WebApi.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public string stringConexao = "DataSource=DEV14\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public void AtualizarFuncionarioCad(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string queryUpdate = "UPDATE Funcionario SET Nome = @Nome WHERE id_funcionario = @ID";

     
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.id_funcionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                                       
                    con.Open();
                                 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Funcionario SET Nome = @Nome WHERE id_funcionario = @ID";


                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.id_funcionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarId(int id)
        {
         
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT id_funcionario, Nome FROM Funcionario WHERE id_funcionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                          
                            id_funcionario = Convert.ToInt32(rdr["id_funcionario"]),

                            Nome = rdr["Nome"].ToString()
                        };

                        return funcionario;
                    }

                    return null;
                }
            }
        }

        public void CadastrarFuncionario(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionario (Nome) VALUES (@Nome)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeletarFuncionario(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
              string queryDelete = "DELETE FROM Funcionarios WHERE id_funcionario = @ID";

               using (SqlCommand cmd = new SqlCommand(queryDelete, con))
               {
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();

                cmd.ExecuteNonQuery();
               }
            }
        }

        List<FuncionarioDomain> IFuncionarioRepository.Listar()
        {
            List<FuncionarioDomain> funcionario = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idfuncionario, Nome from Funcionario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionarios= new FuncionarioDomain
                        {
                            id_funcionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString()
                        };

                        funcionario.Add(funcionarios);
                    }
                }
            }

            return funcionario;
        }
    }
 }

