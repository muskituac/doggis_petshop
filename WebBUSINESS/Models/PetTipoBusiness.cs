using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBASE.DTO;
using WebBUSINESS.BaseConfiguration;

namespace WebBUSINESS.Models
{
    public class PetTipoBusiness : BaseBusiness
    {
        public List<PetTipo> GetAllPetTipos()
        {
            List<PetTipo> pet_tipo_list = new List<PetTipo>();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            descricao,
                                            ultima_alteracao,
                                            responsavel
                                           FROM pet_tipo
                                           ORDER BY descricao";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    PetTipo pet_tipo = new PetTipo();

                    pet_tipo.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    pet_tipo.descricao = (reader["descricao"].ToString() != null && reader["descricao"].ToString() != string.Empty) ? reader["descricao"].ToString() : "";
                    pet_tipo.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    pet_tipo.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    pet_tipo_list.Add(pet_tipo);
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

            return pet_tipo_list;
        }


        public PetTipo GetPetTipo(int pet_tipo_id)
        {
            PetTipo pet_tipo = new PetTipo();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            descricao,
                                            ultima_alteracao,
                                            responsavel
                                           FROM pet_tipo
                                           WHERE
                                           id = '{0}'", pet_tipo_id);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    pet_tipo.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    pet_tipo.descricao = (reader["descricao"].ToString() != null && reader["descricao"].ToString() != string.Empty) ? reader["descricao"].ToString() : "";
                    pet_tipo.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    pet_tipo.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";
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

            return pet_tipo;
        }
    }
}