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
    public class PromocaoServicoBusiness : BaseBusiness
    {

        public bool CadastrarPromocaoServico(ViewModelCadastroPromocaoServico vm_cadastro_promocao_servico)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO promocao_servico 
                                           (id_promocao,
                                            id_servico) 
                                           VALUES 
                                           ('{0}', '{1}')",
                                           vm_cadastro_promocao_servico.cadastro_promocao_servico_id_promocao,
                                           vm_cadastro_promocao_servico.cadastro_promocao_servico_id_servico
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


        public List<PromocaoServico> GetPromocaoServico(int promocao_id)
        {
            List<PromocaoServico> promocao_servico_list = new List<PromocaoServico>();

            ServicoBusiness servico_business = new ServicoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_promocao,
                                            id_servico
                                           FROM promocao_servico
                                           WHERE
                                           id_promocao = '{0}'", promocao_id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    PromocaoServico promocao_servico = new PromocaoServico();

                    promocao_servico.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    promocao_servico.id_promocao = (reader["id_promocao"].ToString() != null && reader["id_promocao"].ToString() != string.Empty) ? Int32.Parse(reader["id_promocao"].ToString()) : 0;
                    promocao_servico.id_servico = (reader["id_servico"].ToString() != null && reader["id_servico"].ToString() != string.Empty) ? Int32.Parse(reader["id_servico"].ToString()) : 0;


                    promocao_servico.servico = servico_business.GetServico(promocao_servico.id_servico);

                    promocao_servico_list.Add(promocao_servico);
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

            return promocao_servico_list;
        }

    }
}