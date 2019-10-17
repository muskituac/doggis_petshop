using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBASE.DTO;
using WebBASE.ViewModel;
using WebBUSINESS.Base;
using WebBUSINESS.BaseConfiguration;

namespace WebBUSINESS.Models
{
    public class FuncionarioBusiness : BaseBusiness
    {

        public bool CadastrarFuncionario(ViewModelCadastroFuncionario vm_cadastro_funcionario)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO funcionario 
                                           (nome,
                                            id_usuario) 
                                           VALUES 
                                           ('{0}', '{1}')",
                                           vm_cadastro_funcionario.cadastro_funcionario_nome,
                                           vm_cadastro_funcionario.cadastro_funcionario_id_usuario                                           
                                           );
                int insert_retorno = command.ExecuteNonQuery();

                if (insert_retorno > 0)
                {
                    retorno = true;
                }


                this.connection.Close();
            }
            catch (Exception ex)
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return retorno;
        }


        public List<Funcionario> GetAllFuncionarios()
        {
            List<Funcionario>  funcionario_list = new List<Funcionario>();

            UsuarioBusiness usuario_business = new UsuarioBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            nome,
                                            id_usuario
                                           FROM funcionario ORDER BY nome";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    funcionario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    funcionario.id_usuario = (reader["id_usuario"].ToString() != null && reader["id_usuario"].ToString() != string.Empty) ? Int32.Parse(reader["id_usuario"].ToString()) : 0;

                    funcionario.usuario = usuario_business.GetUsuario(funcionario.id_usuario);

                    funcionario_list.Add(funcionario);
                }


                this.connection.Close();
            }
            catch (Exception ex)
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return funcionario_list;
        }


        public Funcionario GetFuncionario(int funcionario_id)
        {
            Funcionario funcionario = new Funcionario();

            UsuarioBusiness usuario_business = new UsuarioBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            nome,
                                            id_usuario
                                           FROM funcionario
                                           WHERE
                                           id = '{0}'", funcionario_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    funcionario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    funcionario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    funcionario.id_usuario = (reader["id_usuario"].ToString() != null && reader["id_usuario"].ToString() != string.Empty) ? Int32.Parse(reader["id_usuario"].ToString()) : 0;

                    funcionario.usuario = usuario_business.GetUsuario(funcionario.id_usuario);
                }


                this.connection.Close();
            }
            catch (Exception ex)
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return funcionario;
        }
    }
}