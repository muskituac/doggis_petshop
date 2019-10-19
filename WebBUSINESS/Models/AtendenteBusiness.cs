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
    public class AtendenteBusiness : BaseBusiness
    {

        public bool CadastrarAtendente(ViewModelCadastroAtendente vm_cadastro_atendente)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO atendente 
                                           (id_funcionario,
                                            nome) 
                                           VALUES 
                                           ('{0}', '{1}')",
                                           vm_cadastro_atendente.cadastro_atendente_id_funcionario,
                                           vm_cadastro_atendente.cadastro_atendente_nome
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


        public List<Atendente> GetAllAtendentes()
        {
            List<Atendente> atendentes_list = new List<Atendente>();

            FuncionarioBusiness funcionario_business = new FuncionarioBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            id_funcionario,
                                            nome
                                           FROM atendente ORDER BY nome";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Atendente atendente = new Atendente();

                    atendente.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    atendente.id_funcionario = (reader["id_funcionario"].ToString() != null && reader["id_funcionario"].ToString() != string.Empty) ? Int32.Parse(reader["id_funcionario"].ToString()) : 0;
                    atendente.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";

                    atendente.funcionario = funcionario_business.GetFuncionario(atendente.id_funcionario);

                    atendentes_list.Add(atendente);
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

            return atendentes_list;
        }


        public Atendente GetAtendente(int atendente_id)
        {
            Atendente atendente = new Atendente();

            FuncionarioBusiness funcionario_business = new FuncionarioBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_funcionario,
                                            nome
                                           FROM atendente
                                           WHERE
                                           id = '{0}'", atendente_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    atendente.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    atendente.id = (reader["id_funcionario"].ToString() != null && reader["id_funcionario"].ToString() != string.Empty) ? Int32.Parse(reader["id_funcionario"].ToString()) : 0;
                    atendente.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";

                    atendente.funcionario = funcionario_business.GetFuncionario(atendente.id_funcionario);
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

            return atendente;
        }

    }
}