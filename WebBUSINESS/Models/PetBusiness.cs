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
    public class PetBusiness : BaseBusiness
    {

        public bool CadastrarPet(ViewModelCadastroPet vm_cadastro_pet)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO pet 
                                           (id_pet_tipo,
                                            id_cliente,
                                            nome,
                                            raca,
                                            porte,
                                            alergias,        
                                            observacao,
                                            autorizacao,
                                            ultima_alteracao,
                                            responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                                           vm_cadastro_pet.cadastro_pet_id_pet_tipo,
                                           vm_cadastro_pet.cadastro_pet_id_cliente,
                                           vm_cadastro_pet.cadastro_pet_nome,
                                           vm_cadastro_pet.cadastro_pet_raca,
                                           vm_cadastro_pet.cadastro_pet_porte,
                                           vm_cadastro_pet.cadastro_pet_alergias,
                                           vm_cadastro_pet.cadastro_pet_observacao,
                                           vm_cadastro_pet.cadastro_pet_autorizacao,
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_pet.cadastro_pet_ultima_alteracao.ToString()),
                                           vm_cadastro_pet.cadastro_pet_responsavel
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
        

        public List<Pet> GetAllPets()
        {
            List<Pet> pets_list = new List<Pet>();

            PetTipoBusiness pet_tipo_business = new PetTipoBusiness();
            ClienteBusiness cliente_business = new ClienteBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            id_pet_tipo,
                                            id_cliente,
                                            nome,
                                            raca,
                                            porte,
                                            alergias,
                                            observacao,
                                            autorizacao,
                                            ultima_alteracao,
                                            responsavel
                                           FROM pet ORDER BY nome";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Pet pet = new Pet();

                    pet.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    pet.id_pet_tipo = (reader["id_pet_tipo"].ToString() != null && reader["id_pet_tipo"].ToString() != string.Empty) ? Int32.Parse(reader["id_pet_tipo"].ToString()) : 0;
                    pet.id_cliente = (reader["id_cliente"].ToString() != null && reader["id_cliente"].ToString() != string.Empty) ? Int32.Parse(reader["id_cliente"].ToString()) : 0;
                    pet.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    pet.raca = (reader["raca"].ToString() != null && reader["raca"].ToString() != string.Empty) ? reader["raca"].ToString() : "";
                    pet.porte = (reader["porte"].ToString() != null && reader["porte"].ToString() != string.Empty) ? reader["porte"].ToString() : "";
                    pet.alergias = (reader["alergias"].ToString() != null && reader["alergias"].ToString() != string.Empty) ? reader["alergias"].ToString() : "";
                    pet.observacao = (reader["observacao"].ToString() != null && reader["observacao"].ToString() != string.Empty) ? reader["observacao"].ToString() : "";
                    pet.autorizacao = (reader["autorizacao"].ToString() != null && reader["autorizacao"].ToString() != string.Empty) ? reader["autorizacao"].ToString() : "";
                    pet.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    pet.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    pet.pet_tipo = pet_tipo_business.GetPetTipo(pet.id_pet_tipo);
                    pet.cliente = cliente_business.GetCliente(pet.id_cliente);

                    pets_list.Add(pet);
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

            return pets_list;
        }

        public Pet GetPet(int pet_id)
        {
            Pet pet = new Pet();

            PetTipoBusiness pet_tipo_business = new PetTipoBusiness();
            ClienteBusiness cliente_business = new ClienteBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_pet_tipo,
                                            id_cliente,
                                            nome,
                                            raca,
                                            porte,
                                            alergias,
                                            observacao,
                                            autorizacao,
                                            ultima_alteracao,
                                            responsavel
                                           FROM pet
                                           WHERE
                                           id = '{0}'", pet_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    pet.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    pet.id_pet_tipo = (reader["id_pet_tipo"].ToString() != null && reader["id_pet_tipo"].ToString() != string.Empty) ? Int32.Parse(reader["id_pet_tipo"].ToString()) : 0;
                    pet.id_cliente = (reader["id_cliente"].ToString() != null && reader["id_cliente"].ToString() != string.Empty) ? Int32.Parse(reader["id_cliente"].ToString()) : 0;
                    pet.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    pet.raca = (reader["raca"].ToString() != null && reader["raca"].ToString() != string.Empty) ? reader["raca"].ToString() : "";
                    pet.porte = (reader["porte"].ToString() != null && reader["porte"].ToString() != string.Empty) ? reader["porte"].ToString() : "";
                    pet.alergias = (reader["alergias"].ToString() != null && reader["alergias"].ToString() != string.Empty) ? reader["alergias"].ToString() : "";
                    pet.observacao = (reader["observacao"].ToString() != null && reader["observacao"].ToString() != string.Empty) ? reader["observacao"].ToString() : "";
                    pet.autorizacao = (reader["autorizacao"].ToString() != null && reader["autorizacao"].ToString() != string.Empty) ? reader["autorizacao"].ToString() : "";
                    pet.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    pet.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    pet.pet_tipo = pet_tipo_business.GetPetTipo(pet.id_pet_tipo);
                    pet.cliente = cliente_business.GetCliente(pet.id_cliente);
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

            return pet;
        }


        public List<Pet> GetPetByCliente(int cliente_id)
        {
            List<Pet> pets_list = new List<Pet>();

            PetTipoBusiness pet_tipo_business = new PetTipoBusiness();
            ClienteBusiness cliente_business = new ClienteBusiness();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_pet_tipo,
                                            id_cliente,
                                            nome,
                                            raca,
                                            porte,
                                            alergias,
                                            observacao,
                                            autorizacao,
                                            ultima_alteracao,
                                            responsavel
                                           FROM pet 
                                           WHERE
                                            id_cliente = '{0}'
                                           ORDER BY nome", cliente_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Pet pet = new Pet();

                    pet.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    pet.id_pet_tipo = (reader["id_pet_tipo"].ToString() != null && reader["id_pet_tipo"].ToString() != string.Empty) ? Int32.Parse(reader["id_pet_tipo"].ToString()) : 0;
                    pet.id_cliente = (reader["id_cliente"].ToString() != null && reader["id_cliente"].ToString() != string.Empty) ? Int32.Parse(reader["id_cliente"].ToString()) : 0;
                    pet.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    pet.raca = (reader["raca"].ToString() != null && reader["raca"].ToString() != string.Empty) ? reader["raca"].ToString() : "";
                    pet.porte = (reader["porte"].ToString() != null && reader["porte"].ToString() != string.Empty) ? reader["porte"].ToString() : "";
                    pet.alergias = (reader["alergias"].ToString() != null && reader["alergias"].ToString() != string.Empty) ? reader["alergias"].ToString() : "";
                    pet.observacao = (reader["observacao"].ToString() != null && reader["observacao"].ToString() != string.Empty) ? reader["observacao"].ToString() : "";
                    pet.autorizacao = (reader["autorizacao"].ToString() != null && reader["autorizacao"].ToString() != string.Empty) ? reader["autorizacao"].ToString() : "";
                    pet.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    pet.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    pet.pet_tipo = pet_tipo_business.GetPetTipo(pet.id_pet_tipo);
                    pet.cliente = cliente_business.GetCliente(pet.id_cliente);

                    pets_list.Add(pet);
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

            return pets_list;
        }

    }
}