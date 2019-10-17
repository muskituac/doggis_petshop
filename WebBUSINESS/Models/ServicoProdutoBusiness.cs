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
    public class ServicoProdutoBusiness : BaseBusiness
    {

        public bool CadastrarServicoProduto(ViewModelCadastroServicoProduto vm_cadastro_servico_produto)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO servico_produto 
                                           (id_servico,
                                            id_produto,
                                            quantidade,
                                            ultima_alteracao,
                                            responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}')",
                                           vm_cadastro_servico_produto.cadastro_servico_produto_id_servico,
                                           vm_cadastro_servico_produto.cadastro_servico_produto_id_produto,
                                           vm_cadastro_servico_produto.cadastro_servico_produto_quantidade,
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_servico_produto.cadastro_servico_produto_ultima_alteracao.ToString()),
                                           vm_cadastro_servico_produto.cadastro_servico_produto_responsavel
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


        public List<ServicoProduto> GetServicoProduto(int servico_id)
        {
            List<ServicoProduto> servico_produto_list = new List<ServicoProduto>();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_servico,
                                            id_produto,
                                            quantidade,
                                            ultima_alteracao,
                                            responsavel
                                           FROM servico_produto
                                           WHERE
                                           id_servico = '{0}'", servico_id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    ServicoProduto servico_produto = new ServicoProduto();

                    servico_produto.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    servico_produto.id_servico = (reader["id_servico"].ToString() != null && reader["id_servico"].ToString() != string.Empty) ? Int32.Parse(reader["id_servico"].ToString()) : 0;
                    servico_produto.id_produto = (reader["id_produto"].ToString() != null && reader["id_produto"].ToString() != string.Empty) ? Int32.Parse(reader["id_produto"].ToString()) : 0;
                    servico_produto.quantidade = (reader["quantidade"].ToString() != null && reader["quantidade"].ToString() != string.Empty) ? Int32.Parse(reader["quantidade"].ToString()) : 0;
                    servico_produto.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    servico_produto.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    servico_produto_list.Add(servico_produto);
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

            return servico_produto_list;
        }

    }
}