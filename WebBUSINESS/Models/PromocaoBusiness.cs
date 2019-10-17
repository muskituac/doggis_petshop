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
    public class PromocaoBusiness : BaseBusiness
    {

        public bool CadastrarPromocao(ViewModelCadastroPromocao vm_cadastro_promocao)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO promocao 
                                           (descricao,
                                            porcentagem,
                                            data_inicio,
                                            data_termino,
                                            ultima_alteracao,
                                            responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'); select last_insert_id()",
                                           vm_cadastro_promocao.cadastro_promocao_descricao,
                                           vm_cadastro_promocao.cadastro_promocao_porcentagem,
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_promocao.cadastro_promocao_data_inicio + " 00:00:00"),
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_promocao.cadastro_promocao_data_termino + " 00:00:00"),
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_promocao.cadastro_promocao_ultima_alteracao),
                                           vm_cadastro_promocao.cadastro_promocao_responsavel
                                           );
                int insert_retorno = Convert.ToInt32(command.ExecuteScalar());

                if (insert_retorno > 0)
                {

                    //Cadastro de promocao de produtos
                    PromocaoProdutoBusiness promocao_produto_business = new PromocaoProdutoBusiness();

                    List<ViewModelCadastroPromocaoProduto> cadastro_promocao_produto_list = new List<ViewModelCadastroPromocaoProduto>();
                    cadastro_promocao_produto_list = vm_cadastro_promocao.cadastro_promocao_promocao_produto_list;

                    for (int i = 0; i < cadastro_promocao_produto_list.Count; i++)
                    {
                        ViewModelCadastroPromocaoProduto vm_cadastro_promocao_produto = new ViewModelCadastroPromocaoProduto();
                        vm_cadastro_promocao_produto = cadastro_promocao_produto_list[i];
                        vm_cadastro_promocao_produto.cadastro_promocao_produto_id_promocao = insert_retorno;

                        promocao_produto_business.CadastrarPromocaoProduto(vm_cadastro_promocao_produto);
                    }

                    //Cadastro de promocao de servicos
                    PromocaoServicoBusiness promocao_servico_business = new PromocaoServicoBusiness();

                    List<ViewModelCadastroPromocaoServico> cadastro_promocao_servico_list = new List<ViewModelCadastroPromocaoServico>();
                    cadastro_promocao_servico_list = vm_cadastro_promocao.cadastro_promocao_promocao_servico_list;

                    for (int i = 0; i < cadastro_promocao_servico_list.Count; i++)
                    {
                        ViewModelCadastroPromocaoServico vm_cadastro_promocao_servico = new ViewModelCadastroPromocaoServico();
                        vm_cadastro_promocao_servico = cadastro_promocao_servico_list[i];
                        vm_cadastro_promocao_servico.cadastro_promocao_servico_id_promocao = insert_retorno;

                        promocao_servico_business.CadastrarPromocaoServico(vm_cadastro_promocao_servico);
                    }


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



        public List<Promocao> GetAllPromocoes()
        {
            List<Promocao> promocoes_list = new List<Promocao>();

            
            PromocaoProdutoBusiness promocao_produto_business = new PromocaoProdutoBusiness();
            PromocaoServicoBusiness promocao_servico_business = new PromocaoServicoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            descricao,
                                            porcentagem,
                                            data_inicio,
                                            data_termino,
                                            ultima_alteracao,
                                            responsavel
                                           FROM promocao";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Promocao promocao = new Promocao();

                    promocao.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    promocao.descricao = (reader["descricao"].ToString() != null && reader["descricao"].ToString() != string.Empty) ? reader["descricao"].ToString() : "";
                    promocao.porcentagem = (reader["porcentagem"].ToString() != null && reader["porcentagem"].ToString() != string.Empty) ? Int32.Parse(reader["porcentagem"].ToString()) : 0;
                    promocao.data_inicio = (reader["data_inicio"].ToString() != null && reader["data_inicio"].ToString() != string.Empty) ? reader["data_inicio"].ToString() : "";
                    promocao.data_termino = (reader["data_termino"].ToString() != null && reader["data_termino"].ToString() != string.Empty) ? reader["data_termino"].ToString() : "";
                    promocao.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? reader["ultima_alteracao"].ToString() : "";
                    promocao.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    promocao.promocao_produto_list = promocao_produto_business.GetPromocaoProduto(promocao.id);
                    promocao.promocao_servico_list = promocao_servico_business.GetPromocaoServico(promocao.id);

                    promocoes_list.Add(promocao);
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

            return promocoes_list;
        }


        public Promocao GetPromocao(int promocao_id)
        {
            Promocao promocao = new Promocao();

            PromocaoProdutoBusiness promocao_produto_business = new PromocaoProdutoBusiness();
            PromocaoServicoBusiness promocao_servico_business = new PromocaoServicoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            descricao,
                                            porcentagem,
                                            data_inicio,
                                            data_termino,
                                            ultima_alteracao,
                                            responsavel
                                           FROM promocao
                                           WHERE
                                           id = '{0}'", promocao_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    promocao.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    promocao.descricao = (reader["descricao"].ToString() != null && reader["descricao"].ToString() != string.Empty) ? reader["descricao"].ToString() : "";
                    promocao.porcentagem = (reader["porcentagem"].ToString() != null && reader["porcentagem"].ToString() != string.Empty) ? Int32.Parse(reader["porcentagem"].ToString()) : 0;
                    promocao.data_inicio = (reader["data_inicio"].ToString() != null && reader["data_inicio"].ToString() != string.Empty) ? reader["data_inicio"].ToString() : "";
                    promocao.data_termino = (reader["data_termino"].ToString() != null && reader["data_termino"].ToString() != string.Empty) ? reader["data_termino"].ToString() : "";
                    promocao.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? reader["ultima_alteracao"].ToString() : "";
                    promocao.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    promocao.promocao_produto_list = promocao_produto_business.GetPromocaoProduto(promocao.id);
                    promocao.promocao_servico_list = promocao_servico_business.GetPromocaoServico(promocao.id);
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

            return promocao;
        }

    }
}