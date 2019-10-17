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
    public class ProdutoBusiness : BaseBusiness
    {
        /// <summary>
        /// Método para registrar novo produto
        /// </summary>
        /// <param name="vm_cadastro_produto"></param>
        /// <returns></returns>
        public bool CadastrarProduto(ViewModelCadastroProduto vm_cadastro_produto)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO produto 
                                           (nome, fabricante, especificacoes, valor_atual, pataz_bonus, pataz_custo, ultima_alteracao, responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                                           vm_cadastro_produto.cadastro_produto_nome,
                                           vm_cadastro_produto.cadastro_produto_fabricante,
                                           vm_cadastro_produto.cadastro_produto_especificacoes,
                                           vm_cadastro_produto.cadastro_produto_valor_atual,
                                           vm_cadastro_produto.cadastro_produto_pataz_bonus,
                                           vm_cadastro_produto.cadastro_produto_pataz_custo,
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_produto.cadastro_produto_ultima_alteracao.ToString()),
                                           vm_cadastro_produto.cadastro_produto_responsavel
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
        /// Método para buscar todos os produtos
        /// </summary>
        /// <returns></returns>
        public List<Produto> GetAllProdutos()
        {
            List<Produto> produtos_list = new List<Produto>();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id, nome, fabricante, especificacoes, valor_atual, pataz_bonus, pataz_custo, ultima_alteracao, responsavel
                                           FROM produto";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Produto produto = new Produto();

                    produto.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    produto.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    produto.fabricante = (reader["fabricante"].ToString() != null && reader["fabricante"].ToString() != string.Empty) ? reader["fabricante"].ToString() : "";
                    produto.especificacoes = (reader["especificacoes"].ToString() != null && reader["especificacoes"].ToString() != string.Empty) ? reader["especificacoes"].ToString() : "";
                    produto.valor_atual = (reader["valor_atual"].ToString() != null && reader["valor_atual"].ToString() != string.Empty) ? Decimal.Parse(reader["valor_atual"].ToString()) : 0;
                    produto.pataz_bonus = (reader["pataz_bonus"].ToString() != null && reader["pataz_bonus"].ToString() != string.Empty) ? Decimal.Parse(reader["pataz_bonus"].ToString()) : 0;
                    produto.pataz_custo = (reader["pataz_custo"].ToString() != null && reader["pataz_custo"].ToString() != string.Empty) ? Decimal.Parse(reader["pataz_custo"].ToString()) : 0;
                    produto.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    produto.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    produtos_list.Add(produto);
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

            return produtos_list;
        }

        /// <summary>
        /// Método para buscar um unico produto pelo id
        /// </summary>
        /// <param name="produto_id"></param>
        /// <returns></returns>
        public Produto GetProduto(int produto_id)
        {
            Produto produto = new Produto();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id, nome, fabricante, especificacoes, valor_atual, pataz_bonus, pataz_custo, ultima_alteracao, responsavel
                                           FROM produto
                                           WHERE
                                           id = '{0}'", produto_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    produto.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    produto.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    produto.fabricante = (reader["fabricante"].ToString() != null && reader["fabricante"].ToString() != string.Empty) ? reader["fabricante"].ToString() : "";
                    produto.especificacoes = (reader["especificacoes"].ToString() != null && reader["especificacoes"].ToString() != string.Empty) ? reader["especificacoes"].ToString() : "";
                    produto.valor_atual = (reader["valor_atual"].ToString() != null && reader["valor_atual"].ToString() != string.Empty) ? Decimal.Parse(reader["valor_atual"].ToString()) : 0;
                    produto.pataz_bonus = (reader["pataz_bonus"].ToString() != null && reader["pataz_bonus"].ToString() != string.Empty) ? Decimal.Parse(reader["pataz_bonus"].ToString()) : 0;
                    produto.pataz_custo = (reader["pataz_custo"].ToString() != null && reader["pataz_custo"].ToString() != string.Empty) ? Decimal.Parse(reader["pataz_custo"].ToString()) : 0;
                    produto.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    produto.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";
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

            return produto;
        }
    }
}