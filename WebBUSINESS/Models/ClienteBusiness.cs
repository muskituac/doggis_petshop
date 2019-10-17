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
    public class ClienteBusiness : BaseBusiness
    {

        public bool CadastrarCliente(ViewModelCadastroCliente vm_cadastro_cliente)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO cliente 
                                           (nome,
                                            identidade,
                                            cpf,
                                            endereco,
                                            email,
                                            autorizacao,
                                            ultima_alteracao,
                                            responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                                           vm_cadastro_cliente.cadastro_cliente_nome,
                                           vm_cadastro_cliente.cadastro_cliente_identidade,
                                           vm_cadastro_cliente.cadastro_cliente_cpf,
                                           vm_cadastro_cliente.cadastro_cliente_endereco,
                                           vm_cadastro_cliente.cadastro_cliente_email,
                                           vm_cadastro_cliente.cadastro_cliente_autorizacao,
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_cliente.cadastro_cliente_ultima_alteracao.ToString()),
                                           vm_cadastro_cliente.cadastro_cliente_responsavel
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

        
        public List<Cliente> GetAllClientes()
        {
            List<Cliente> clientes_list = new List<Cliente>();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            nome,
                                            identidade,
                                            cpf,
                                            endereco,
                                            email,
                                            autorizacao,
                                            ultima_alteracao,
                                            responsavel
                                           FROM cliente";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Cliente cliente = new Cliente();

                    cliente.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    cliente.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    cliente.identidade = (reader["identidade"].ToString() != null && reader["identidade"].ToString() != string.Empty) ? reader["identidade"].ToString() : "";
                    cliente.cpf = (reader["cpf"].ToString() != null && reader["cpf"].ToString() != string.Empty) ? reader["cpf"].ToString() : "";
                    cliente.endereco = (reader["endereco"].ToString() != null && reader["endereco"].ToString() != string.Empty) ? reader["endereco"].ToString() : "";
                    cliente.email = (reader["email"].ToString() != null && reader["email"].ToString() != string.Empty) ? reader["email"].ToString() : "";
                    cliente.autorizacao = (reader["autorizacao"].ToString() != null && reader["autorizacao"].ToString() != string.Empty) ? reader["autorizacao"].ToString() : "";
                    cliente.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    cliente.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    clientes_list.Add(cliente);
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

            return clientes_list;
        }

        
        public Cliente GetCliente(int cliente_id)
        {
            Cliente cliente = new Cliente();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            nome,
                                            identidade,
                                            cpf,
                                            endereco,
                                            email,
                                            autorizacao,
                                            ultima_alteracao,
                                            responsavel
                                           FROM cliente
                                           WHERE
                                           id = '{0}'", cliente_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    cliente.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    cliente.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    cliente.identidade = (reader["identidade"].ToString() != null && reader["identidade"].ToString() != string.Empty) ? reader["identidade"].ToString() : "";
                    cliente.cpf = (reader["cpf"].ToString() != null && reader["cpf"].ToString() != string.Empty) ? reader["cpf"].ToString() : "";
                    cliente.endereco = (reader["endereco"].ToString() != null && reader["endereco"].ToString() != string.Empty) ? reader["endereco"].ToString() : "";
                    cliente.email = (reader["email"].ToString() != null && reader["email"].ToString() != string.Empty) ? reader["email"].ToString() : "";
                    cliente.autorizacao = (reader["autorizacao"].ToString() != null && reader["autorizacao"].ToString() != string.Empty) ? reader["autorizacao"].ToString() : "";
                    cliente.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    cliente.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";
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

            return cliente;
        }

    }
}