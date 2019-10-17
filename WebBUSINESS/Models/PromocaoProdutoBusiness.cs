using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBASE.DTO;
using WebBASE.ViewModel;
using WebBUSINESS.BaseConfiguration;

namespace WebBUSINESS.Models
{
    public class PromocaoProdutoBusiness : BaseBusiness
    {

        public bool CadastrarPromocaoProduto(ViewModelCadastroPromocaoProduto vm_cadastro_promocao_produto)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO promocao_produto 
                                           (id_promocao,
                                            id_produto) 
                                           VALUES 
                                           ('{0}', '{1}')",
                                           vm_cadastro_promocao_produto.cadastro_promocao_produto_id_promocao,
                                           vm_cadastro_promocao_produto.cadastro_promocao_produto_id_produto
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


        public List<PromocaoProduto> GetPromocaoProduto(int promocao_id)
        {
            List<PromocaoProduto> promocao_produto_list = new List<PromocaoProduto>();

            ProdutoBusiness produto_business = new ProdutoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_promocao,
                                            id_produto
                                           FROM promocao_produto
                                           WHERE
                                           id_promocao = '{0}'", promocao_id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    PromocaoProduto promocao_produto = new PromocaoProduto();

                    promocao_produto.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    promocao_produto.id_promocao = (reader["id_promocao"].ToString() != null && reader["id_promocao"].ToString() != string.Empty) ? Int32.Parse(reader["id_promocao"].ToString()) : 0;
                    promocao_produto.id_produto = (reader["id_produto"].ToString() != null && reader["id_produto"].ToString() != string.Empty) ? Int32.Parse(reader["id_produto"].ToString()) : 0;


                    promocao_produto.produto = produto_business.GetProduto(promocao_produto.id_produto);

                    promocao_produto_list.Add(promocao_produto);
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

            return promocao_produto_list;
        }

    }
}