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

        private string stringConexao = "Data Source=.\\SQLEXPRESS; initial catalog=M_Peoples; Integrated Security=True;";

        public void AtualizarFuncionarioCad(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string queryUpdate = "UPDATE Funcionario SET Nome = @Nome, Sobrenome = @Sobrenome WHERE id_funcionario = @ID";

     
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.id_funcionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    con.Open();
                                 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Funcionario SET Nome = @Nome, " + "Sobrenome = @Sobrenome WHERE id_funcionario = @ID";


                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarId(int id)
        {
         
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT id_funcionario, Nome, Sobrenome FROM Funcionario WHERE id_funcionario = @ID";

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

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr ["Sobrenome"].ToString()
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
                string queryInsert = "INSERT INTO Funcionario (Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeletarFuncionario(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
              string queryDelete = "DELETE FROM Funcionario WHERE id_funcionario = @ID";

               using (SqlCommand cmd = new SqlCommand(queryDelete, con))
               {
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();

                cmd.ExecuteNonQuery();
               }
            }
        }

         public List<FuncionarioDomain> Listar()
            {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT id_funcionario, Nome, Sobrenome from Funcionario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario= new FuncionarioDomain
                        {
                            id_funcionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr ["Sobrenome"].ToString(),
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

     
    }
 }

