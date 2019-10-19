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
    public class ServicoBusiness : BaseBusiness
    {

        public bool CadastrarServico(ViewModelCadastroServico vm_cadastro_servico)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO servico 
                                           (tipo_executante,
                                            nome,
                                            descricao,
                                            valor_atual,
                                            tempo,
                                            pataz_bonus,
                                            pataz_custo,
                                            ultima_alteracao,
                                            responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}'); select last_insert_id()",
                                           vm_cadastro_servico.cadastro_servico_tipo_executante,
                                           vm_cadastro_servico.cadastro_servico_nome,
                                           vm_cadastro_servico.cadastro_servico_descricao,
                                           vm_cadastro_servico.cadastro_servico_valor_atual,
                                           vm_cadastro_servico.cadastro_servico_tempo,
                                           vm_cadastro_servico.cadastro_servico_pataz_bonus,
                                           vm_cadastro_servico.cadastro_servico_pataz_custo,
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_servico.cadastro_servico_ultima_alteracao.ToString()),
                                           vm_cadastro_servico.cadastro_servico_responsavel
                                           );
                int insert_retorno = Convert.ToInt32(command.ExecuteScalar());

                if (insert_retorno > 0)
                {

                    ServicoProdutoBusiness servico_produto_business = new ServicoProdutoBusiness();

                    List<ViewModelCadastroServicoProduto> cadastro_servico_produto_list = new List<ViewModelCadastroServicoProduto>();
                    cadastro_servico_produto_list = vm_cadastro_servico.cadastro_servico_produto_list;

                    for (int i = 0; i < cadastro_servico_produto_list.Count; i++)
                    {
                        ViewModelCadastroServicoProduto vm_cadastro_servico_produto = new ViewModelCadastroServicoProduto();
                        vm_cadastro_servico_produto = cadastro_servico_produto_list[i];
                        vm_cadastro_servico_produto.cadastro_servico_produto_id_servico = insert_retorno;
                        vm_cadastro_servico_produto.cadastro_servico_produto_ultima_alteracao = vm_cadastro_servico.cadastro_servico_ultima_alteracao;
                        vm_cadastro_servico_produto.cadastro_servico_produto_responsavel = vm_cadastro_servico.cadastro_servico_responsavel;

                        servico_produto_business.CadastrarServicoProduto(vm_cadastro_servico_produto);
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


        public List<Servico> GetAllServicos()
        {
            List<Servico> servicos_list = new List<Servico>();

            ServicoProdutoBusiness servico_produto_business = new ServicoProdutoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            tipo_executante,
                                            nome,
                                            descricao,
                                            valor_atual,
                                            tempo,
                                            pataz_bonus,
                                            pataz_custo,
                                            ultima_alteracao,
                                            responsavel
                                           FROM servico";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Servico servico = new Servico();

                    servico.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    servico.tipo_executante = (reader["tipo_executante"].ToString() != null && reader["tipo_executante"].ToString() != string.Empty) ? Int32.Parse(reader["tipo_executante"].ToString()) : 0;
                    servico.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    servico.descricao = (reader["descricao"].ToString() != null && reader["descricao"].ToString() != string.Empty) ? reader["descricao"].ToString() : "";
                    servico.valor_atual = (reader["valor_atual"].ToString() != null && reader["valor_atual"].ToString() != string.Empty) ? Decimal.Parse(reader["valor_atual"].ToString()) : 0;
                    servico.tempo = (reader["tempo"].ToString() != null && reader["tempo"].ToString() != string.Empty) ? Int32.Parse(reader["tempo"].ToString()) : 0;
                    servico.pataz_bonus = (reader["pataz_bonus"].ToString() != null && reader["pataz_bonus"].ToString() != string.Empty) ? Int32.Parse(reader["pataz_bonus"].ToString()) : 0;
                    servico.pataz_custo = (reader["pataz_custo"].ToString() != null && reader["pataz_custo"].ToString() != string.Empty) ? Int32.Parse(reader["pataz_custo"].ToString()) : 0;
                    servico.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    servico.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    servico.servico_produto_list = servico_produto_business.GetServicoProduto(servico.id);

                    servicos_list.Add(servico);
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

            return servicos_list;
        }


        public Servico GetServico(int servico_id)
        {
            Servico servico = new Servico();

            FuncionarioBusiness funcionario_business = new FuncionarioBusiness();
            ServicoProdutoBusiness servico_produto_business = new ServicoProdutoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            tipo_executante,
                                            nome,
                                            descricao,
                                            valor_atual,
                                            tempo,
                                            pataz_bonus,
                                            pataz_custo,
                                            ultima_alteracao,
                                            responsavel
                                           FROM servico
                                           WHERE
                                           id = '{0}'", servico_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    servico.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    servico.tipo_executante = (reader["tipo_executante"].ToString() != null && reader["tipo_executante"].ToString() != string.Empty) ? Int32.Parse(reader["tipo_executante"].ToString()) : 0;
                    servico.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    servico.descricao = (reader["descricao"].ToString() != null && reader["descricao"].ToString() != string.Empty) ? reader["descricao"].ToString() : "";
                    servico.valor_atual = (reader["valor_atual"].ToString() != null && reader["valor_atual"].ToString() != string.Empty) ? Decimal.Parse(reader["valor_atual"].ToString()) : 0;
                    servico.tempo = (reader["tempo"].ToString() != null && reader["tempo"].ToString() != string.Empty) ? Int32.Parse(reader["tempo"].ToString()) : 0;
                    servico.pataz_bonus = (reader["pataz_bonus"].ToString() != null && reader["pataz_bonus"].ToString() != string.Empty) ? Int32.Parse(reader["pataz_bonus"].ToString()) : 0;
                    servico.pataz_custo = (reader["pataz_custo"].ToString() != null && reader["pataz_custo"].ToString() != string.Empty) ? Int32.Parse(reader["pataz_custo"].ToString()) : 0;
                    servico.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    servico.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    servico.servico_produto_list = servico_produto_business.GetServicoProduto(servico.id);
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

            return servico;
        }

    }
}