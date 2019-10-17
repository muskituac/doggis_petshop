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
    public class VeterinarioBusiness : BaseBusiness
    {

        public bool CadastrarVeterinario(ViewModelCadastroVeterinario vm_cadastro_veterinario)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO veterinario 
                                           (id_funcionario,
                                            nome,
                                            cpf,
                                            identidade,
                                            registro,
                                            ultima_alteracao,
                                            responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'); select last_insert_id()",
                                           vm_cadastro_veterinario.cadastro_veterinario_id_funcionario,
                                           vm_cadastro_veterinario.cadastro_veterinario_nome,
                                           vm_cadastro_veterinario.cadastro_veterinario_cpf,
                                           vm_cadastro_veterinario.cadastro_veterinario_identidade,
                                           vm_cadastro_veterinario.cadastro_veterinario_registro,
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_veterinario.cadastro_veterinario_ultima_alteracao.ToString()),
                                           vm_cadastro_veterinario.cadastro_veterinario_responsavel
                                           );
                int insert_retorno = Convert.ToInt32(command.ExecuteScalar());

                if (insert_retorno > 0)
                {

                    VeterinarioPetTipoBusiness veterinario_pet_tipo_business = new VeterinarioPetTipoBusiness();

                    List<ViewModelCadastroVeterinarioPetTipo> cadastro_veterinario_pet_tipo_list = new List<ViewModelCadastroVeterinarioPetTipo>();
                    cadastro_veterinario_pet_tipo_list = vm_cadastro_veterinario.cadastro_veterinario_pet_tipo_list;

                    for (int i = 0; i < cadastro_veterinario_pet_tipo_list.Count; i++)
                    {
                        ViewModelCadastroVeterinarioPetTipo vm_cadastro_veterinario_pet_tipo = new ViewModelCadastroVeterinarioPetTipo();
                        vm_cadastro_veterinario_pet_tipo = cadastro_veterinario_pet_tipo_list[i];
                        vm_cadastro_veterinario_pet_tipo.cadastro_veterinario_pet_tipo_id_veterinario = insert_retorno;

                        veterinario_pet_tipo_business.CadastrarVeterinarioPetTipo(vm_cadastro_veterinario_pet_tipo);
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

        

        public List<Veterinario> GetAllVeterinarios()
        {
            List<Veterinario> veterinarios_list = new List<Veterinario>();

            FuncionarioBusiness funcionario_business = new FuncionarioBusiness();
            VeterinarioPetTipoBusiness veterinario_pet_tipo_business = new VeterinarioPetTipoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            id_funcionario,
                                            nome,
                                            cpf,
                                            identidade,
                                            registro,
                                            ultima_alteracao,
                                            responsavel
                                           FROM veterinario";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Veterinario veterinario = new Veterinario();

                    veterinario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    veterinario.id_funcionario = (reader["id_funcionario"].ToString() != null && reader["id_funcionario"].ToString() != string.Empty) ? Int32.Parse(reader["id_funcionario"].ToString()) : 0;
                    veterinario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    veterinario.cpf = (reader["cpf"].ToString() != null && reader["cpf"].ToString() != string.Empty) ? reader["cpf"].ToString() : "";
                    veterinario.identidade = (reader["identidade"].ToString() != null && reader["identidade"].ToString() != string.Empty) ? reader["identidade"].ToString() : "";
                    veterinario.registro = (reader["registro"].ToString() != null && reader["registro"].ToString() != string.Empty) ? reader["registro"].ToString() : "";
                    veterinario.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    veterinario.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    veterinario.veterinario_pet_tipo_list = veterinario_pet_tipo_business.GetVeterinarioPetTipo(veterinario.id);
                    veterinario.funcionario = funcionario_business.GetFuncionario(veterinario.id_funcionario);

                    veterinarios_list.Add(veterinario);
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

            return veterinarios_list;
        }


        public Veterinario GetVeterinario(int veterinario_id)
        {
            Veterinario veterinario = new Veterinario();

            FuncionarioBusiness funcionario_business = new FuncionarioBusiness();
            VeterinarioPetTipoBusiness veterinario_pet_tipo_business = new VeterinarioPetTipoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_funcionario,
                                            nome,
                                            cpf,
                                            identidade,
                                            registro,
                                            ultima_alteracao,
                                            responsavel
                                           FROM veterinario
                                           WHERE
                                           id = '{0}'", veterinario_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    veterinario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    veterinario.id_funcionario = (reader["id_funcionario"].ToString() != null && reader["id_funcionario"].ToString() != string.Empty) ? Int32.Parse(reader["id_funcionario"].ToString()) : 0;
                    veterinario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    veterinario.cpf = (reader["cpf"].ToString() != null && reader["cpf"].ToString() != string.Empty) ? reader["cpf"].ToString() : "";
                    veterinario.identidade = (reader["identidade"].ToString() != null && reader["identidade"].ToString() != string.Empty) ? reader["identidade"].ToString() : "";
                    veterinario.registro = (reader["endereco"].ToString() != null && reader["endereco"].ToString() != string.Empty) ? reader["endereco"].ToString() : "";
                    veterinario.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    veterinario.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    veterinario.veterinario_pet_tipo_list = veterinario_pet_tipo_business.GetVeterinarioPetTipo(veterinario.id);
                    veterinario.funcionario = funcionario_business.GetFuncionario(veterinario.id_funcionario);
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

            return veterinario;
        }

        public List<Veterinario> GetAllVeterinariosByPetTipo(int pet_tipo_id)
        {
            List<Veterinario> veterinarios_list = new List<Veterinario>();

            FuncionarioBusiness funcionario_business = new FuncionarioBusiness();
            VeterinarioPetTipoBusiness veterinario_pet_tipo_business = new VeterinarioPetTipoBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                             	v.id,
                                                v.id_funcionario,
                                                v.nome,
                                                v.cpf,
                                                v.identidade,
                                                v.registro,
                                                v.ultima_alteracao,
                                                v.responsavel 
                                             FROM veterinario v
                                             	inner join veterinario_pet_tipo vpt on vpt.id_veterinario = v.id    
                                             WHERE
                                             	vpt.id_pet_tipo = '{0}'
                                             ORDER BY v.nome", pet_tipo_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Veterinario veterinario = new Veterinario();

                    veterinario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    veterinario.id_funcionario = (reader["id_funcionario"].ToString() != null && reader["id_funcionario"].ToString() != string.Empty) ? Int32.Parse(reader["id_funcionario"].ToString()) : 0;
                    veterinario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    veterinario.cpf = (reader["cpf"].ToString() != null && reader["cpf"].ToString() != string.Empty) ? reader["cpf"].ToString() : "";
                    veterinario.identidade = (reader["identidade"].ToString() != null && reader["identidade"].ToString() != string.Empty) ? reader["identidade"].ToString() : "";
                    veterinario.registro = (reader["registro"].ToString() != null && reader["registro"].ToString() != string.Empty) ? reader["registro"].ToString() : "";
                    veterinario.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    veterinario.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    veterinario.veterinario_pet_tipo_list = veterinario_pet_tipo_business.GetVeterinarioPetTipo(veterinario.id);
                    veterinario.funcionario = funcionario_business.GetFuncionario(veterinario.id_funcionario);

                    veterinarios_list.Add(veterinario);
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

            return veterinarios_list;
        }

    }
}