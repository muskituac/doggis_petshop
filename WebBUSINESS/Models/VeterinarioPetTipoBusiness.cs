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
    public class VeterinarioPetTipoBusiness : BaseBusiness
    {

        public bool CadastrarVeterinarioPetTipo(ViewModelCadastroVeterinarioPetTipo vm_cadastro_veterinario_pet_tipo)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO veterinario_pet_tipo 
                                           (id_veterinario,
                                            id_pet_tipo) 
                                           VALUES 
                                           ('{0}', '{1}')",
                                           vm_cadastro_veterinario_pet_tipo.cadastro_veterinario_pet_tipo_id_veterinario,
                                           vm_cadastro_veterinario_pet_tipo.cadastro_veterinario_pet_tipo_id_pet_tipo
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


        public List<VeterinarioPetTipo> GetVeterinarioPetTipo(int veterinario_id)
        {
            List<VeterinarioPetTipo> veterinario_pet_tipo_list = new List<VeterinarioPetTipo>();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                            id,
                                            id_veterinario,
                                            id_pet_tipo
                                           FROM veterinario_pet_tipo
                                           WHERE
                                           id_veterinario = '{0}'", veterinario_id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    VeterinarioPetTipo veterinario_pet_tipo = new VeterinarioPetTipo();

                    veterinario_pet_tipo.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    veterinario_pet_tipo.id_veterinario = (reader["id_veterinario"].ToString() != null && reader["id_veterinario"].ToString() != string.Empty) ? Int32.Parse(reader["id_veterinario"].ToString()) : 0;
                    veterinario_pet_tipo.id_pet_tipo = (reader["id_pet_tipo"].ToString() != null && reader["id_pet_tipo"].ToString() != string.Empty) ? Int32.Parse(reader["id_pet_tipo"].ToString()) : 0;

                    veterinario_pet_tipo_list.Add(veterinario_pet_tipo);
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

            return veterinario_pet_tipo_list;
        }

    }
}