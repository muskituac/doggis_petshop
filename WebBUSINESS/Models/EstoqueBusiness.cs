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
    public class EstoqueBusiness : BaseBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm_entrada_estoque"></param>
        /// <returns></returns>
        public bool Entrada(ViewModelEntradaEstoque vm_entrada_estoque)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO estoque_entrada 
                                           (id_produto, quantidade, data, ultima_alteracao, responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}')",
                                           vm_entrada_estoque.entrada_estoque_id_produto,
                                           vm_entrada_estoque.entrada_estoque_quantidade,
                                           BASE_CORE.ConvertDateBrToMySql(vm_entrada_estoque.entrada_estoque_data.ToString()),
                                           BASE_CORE.ConvertDateBrToMySql(vm_entrada_estoque.entrada_estoque_ultima_alteracao.ToString()),
                                           vm_entrada_estoque.entrada_estoque_responsavel
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

        /// <summary>
        /// Método para buscar todos as entradas de produtos no estoque
        /// </summary>
        /// <returns></returns>
        public List<EstoqueEntrada> GetAllEntradas()
        {
            List<EstoqueEntrada> estoque_entrada_list = new List<EstoqueEntrada>();

            ProdutoBusiness produto_business = new ProdutoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id, id_produto, quantidade, data, ultima_alteracao, responsavel
                                           FROM estoque_entrada";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    EstoqueEntrada estoque_entrada = new EstoqueEntrada();

                    estoque_entrada.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    estoque_entrada.produto_id = (reader["id_produto"].ToString() != null && reader["id_produto"].ToString() != string.Empty) ? Int32.Parse(reader["id_produto"].ToString()) : 0;
                    estoque_entrada.quantidade = (reader["quantidade"].ToString() != null && reader["quantidade"].ToString() != string.Empty) ? Int32.Parse(reader["quantidade"].ToString()) : 0;
                    estoque_entrada.data = (reader["data"].ToString() != null && reader["data"].ToString() != string.Empty) ? DateTime.Parse(reader["data"].ToString()) : new DateTime();
                    estoque_entrada.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    estoque_entrada.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    estoque_entrada.produto = produto_business.GetProduto(estoque_entrada.produto_id);

                    estoque_entrada_list.Add(estoque_entrada);
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

            return estoque_entrada_list;
        }
    }
}