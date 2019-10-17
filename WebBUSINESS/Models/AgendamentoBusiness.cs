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
    public class AgendamentoBusiness : BaseBusiness
    {

        public int CadastrarAgendamento(ViewModelCadastroAgendamento vm_cadastro_agendamento)
        {
            int retorno = 0;

            ServicoBusiness servico_business = new ServicoBusiness();

            Servico servico = servico_business.GetServico(vm_cadastro_agendamento.cadastro_agendamento_id_servico);

            DateTime date_time_inicio = DateTime.Parse(vm_cadastro_agendamento.cadastro_agendamento_data_inicio);

            vm_cadastro_agendamento.cadastro_agendamento_data_termino = date_time_inicio.AddMinutes(servico.tempo).ToString();

            if (this.GetDisponibilidade(vm_cadastro_agendamento))
            {

                try
                {
                    this.connection.Open();

                    this.command.CommandText = string.Format(@"INSERT INTO agendamento 
                                           (id_cliente,
                                            id_pet,
                                            id_servico,
                                            id_funcionario,
                                            data_inicio,
                                            data_termino,
                                            notificacao_enviada,
                                            cancelamento,
                                            ultima_alteracao,
                                            responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                                               vm_cadastro_agendamento.cadastro_agendamento_id_cliente,
                                               vm_cadastro_agendamento.cadastro_agendamento_id_pet,
                                               vm_cadastro_agendamento.cadastro_agendamento_id_servico,
                                               vm_cadastro_agendamento.cadastro_agendamento_id_funcionario,
                                               BASE_CORE.ConvertDateBrToMySql(vm_cadastro_agendamento.cadastro_agendamento_data_inicio),
                                               BASE_CORE.ConvertDateBrToMySql(vm_cadastro_agendamento.cadastro_agendamento_data_termino),
                                               vm_cadastro_agendamento.cadastro_agendamento_notificacao_enviada,
                                               vm_cadastro_agendamento.cadastro_agendamento_cancelamento,
                                               BASE_CORE.ConvertDateBrToMySql(vm_cadastro_agendamento.cadastro_agendamento_ultima_alteracao),
                                               vm_cadastro_agendamento.cadastro_agendamento_responsavel
                                               );
                    int insert_retorno = command.ExecuteNonQuery();

                    if (insert_retorno > 0)
                    {
                        retorno = 1;
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

            }
            else
            {
                retorno = 2;
            }


            return retorno;
        }


        public List<Agendamento> GetAllAgendamentoss()
        {
            List<Agendamento> agendamentos_list = new List<Agendamento>();

            ClienteBusiness cliente_business = new ClienteBusiness();
            PetBusiness pet_business = new PetBusiness();
            ServicoBusiness servico_business = new ServicoBusiness();
            FuncionarioBusiness funcionario_business = new FuncionarioBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            id_cliente,
                                            id_pet,
                                            id_servico,
                                            id_funcionario,
                                            data_inicio,
                                            data_termino,
                                            notificacao_enviada,
                                            cancelamento,
                                            ultima_alteracao,
                                            responsavel
                                           FROM agendamento ORDER BY data_inicio DESC";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Agendamento agendamento = new Agendamento();

                    agendamento.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    agendamento.id_cliente = (reader["id_cliente"].ToString() != null && reader["id_cliente"].ToString() != string.Empty) ? Int32.Parse(reader["id_cliente"].ToString()) : 0;
                    agendamento.id_pet = (reader["id_pet"].ToString() != null && reader["id_pet"].ToString() != string.Empty) ? Int32.Parse(reader["id_pet"].ToString()) : 0;
                    agendamento.id_servico = (reader["id_servico"].ToString() != null && reader["id_servico"].ToString() != string.Empty) ? Int32.Parse(reader["id_servico"].ToString()) : 0;
                    agendamento.id_funcionario = (reader["id_funcionario"].ToString() != null && reader["id_funcionario"].ToString() != string.Empty) ? Int32.Parse(reader["id_funcionario"].ToString()) : 0;
                    agendamento.data_inicio = (reader["data_inicio"].ToString() != null && reader["data_inicio"].ToString() != string.Empty) ? DateTime.Parse(reader["data_inicio"].ToString()) : new DateTime();
                    agendamento.data_termino = (reader["data_termino"].ToString() != null && reader["data_termino"].ToString() != string.Empty) ? DateTime.Parse(reader["data_termino"].ToString()) : new DateTime();
                    agendamento.notificacao_enviada = (reader["notificacao_enviada"].ToString() != null && reader["notificacao_enviada"].ToString() != string.Empty) ? Boolean.Parse(reader["notificacao_enviada"].ToString()) : false;
                    agendamento.cancelamento = (reader["cancelamento"].ToString() != null && reader["cancelamento"].ToString() != string.Empty) ? Boolean.Parse(reader["cancelamento"].ToString()) : false;
                    agendamento.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    agendamento.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    agendamento.data_inicio_br = agendamento.data_inicio.ToString();
                    agendamento.data_termino_br = agendamento.data_termino.ToString();

                    agendamento.cliente = cliente_business.GetCliente(agendamento.id_cliente);
                    agendamento.pet = pet_business.GetPet(agendamento.id_pet);
                    agendamento.servico = servico_business.GetServico(agendamento.id_servico);
                    agendamento.funcionario = funcionario_business.GetFuncionario(agendamento.id_funcionario);

                    agendamentos_list.Add(agendamento);
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

            return agendamentos_list;
        }


        public Agendamento GetAgendamento(int agendamento_id)
        {
            Agendamento agendamento = new Agendamento();

            ClienteBusiness cliente_business = new ClienteBusiness();
            PetBusiness pet_business = new PetBusiness();
            ServicoBusiness servico_business = new ServicoBusiness();
            FuncionarioBusiness funcionario_business = new FuncionarioBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_cliente,
                                            id_pet,
                                            id_servico,
                                            id_funcionario,
                                            data_inicio,
                                            data_termino,
                                            notificacao_enviada,
                                            cancelamento,
                                            ultima_alteracao,
                                            responsavel
                                           FROM agendamento
                                           WHERE
                                           id = '{0}'", agendamento_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    agendamento.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    agendamento.id_cliente = (reader["id_cliente"].ToString() != null && reader["id_cliente"].ToString() != string.Empty) ? Int32.Parse(reader["id_cliente"].ToString()) : 0;
                    agendamento.id_pet = (reader["id_pet"].ToString() != null && reader["id_pet"].ToString() != string.Empty) ? Int32.Parse(reader["id_pet"].ToString()) : 0;
                    agendamento.id_servico = (reader["id_servico"].ToString() != null && reader["id_servico"].ToString() != string.Empty) ? Int32.Parse(reader["id_servico"].ToString()) : 0;
                    agendamento.id_funcionario = (reader["id_funcionario"].ToString() != null && reader["id_funcionario"].ToString() != string.Empty) ? Int32.Parse(reader["id_funcionario"].ToString()) : 0;
                    agendamento.data_inicio = (reader["data_inicio"].ToString() != null && reader["data_inicio"].ToString() != string.Empty) ? DateTime.Parse(reader["data_inicio"].ToString()) : new DateTime();
                    agendamento.data_inicio = (reader["data_termino"].ToString() != null && reader["data_termino"].ToString() != string.Empty) ? DateTime.Parse(reader["data_termino"].ToString()) : new DateTime();
                    agendamento.notificacao_enviada = (reader["notificacao_enviada"].ToString() != null && reader["notificacao_enviada"].ToString() != string.Empty) ? Boolean.Parse(reader["notificacao_enviada"].ToString()) : false;
                    agendamento.cancelamento = (reader["cancelamento"].ToString() != null && reader["cancelamento"].ToString() != string.Empty) ? Boolean.Parse(reader["cancelamento"].ToString()) : false;
                    agendamento.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    agendamento.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    agendamento.data_inicio_br = agendamento.data_inicio.ToString();
                    agendamento.data_termino_br = agendamento.data_termino.ToString();

                    agendamento.cliente = cliente_business.GetCliente(agendamento.id_cliente);
                    agendamento.pet = pet_business.GetPet(agendamento.id_pet);
                    agendamento.servico = servico_business.GetServico(agendamento.id_servico);
                    agendamento.funcionario = funcionario_business.GetFuncionario(agendamento.id_funcionario);
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

            return agendamento;
        }


        private bool GetDisponibilidade(ViewModelCadastroAgendamento vm_cadastro_agendamento)
        {
            bool retorno = true;

            ServicoBusiness servico_business = new ServicoBusiness();

            try
            {

                Servico servico = servico_business.GetServico(vm_cadastro_agendamento.cadastro_agendamento_id_servico);

                DateTime date_time_inicio = DateTime.Parse(vm_cadastro_agendamento.cadastro_agendamento_data_inicio);
                DateTime data_agendamento = date_time_inicio.AddMinutes(servico.tempo);

                this.connection.Open();

                this.command.CommandText = string.Format(@"select
                                                           	COUNT(*) as total,
                                                           	a.*,
                                                            s.*    
                                                           from agendamento a
                                                           	inner join servico s on s.id = a.id_servico
                                                           where
                                                           	('{0}' between a.data_inicio and a.data_termino
                                                            or '{1}' between a.data_inicio and a.data_termino)
                                                            and a.id_funcionario = '{2}'
                                                            and a.cancelamento = 0", 
                                                            BASE_CORE.ConvertDateBrToMySql(date_time_inicio.ToString()),
                                                            BASE_CORE.ConvertDateBrToMySql(data_agendamento.ToString()),
                                                            vm_cadastro_agendamento.cadastro_agendamento_id_funcionario);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    int total = (reader["total"].ToString() != null && reader["total"].ToString() != string.Empty) ? Int32.Parse(reader["total"].ToString()) : 0;

                    if (total > 0)
                    {
                        retorno = false;
                    }

                }


                this.connection.Close();
            }
            catch (Exception ex)
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                {
                    this.connection.Close();
                }

                retorno = false;
            }

            return retorno;
        }

    }
}