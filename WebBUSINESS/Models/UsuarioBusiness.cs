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
    public class UsuarioBusiness : BaseBusiness
    {

        public bool CadastrarUsuario(ViewModelCadastroUsuario vm_cadastro_usuario)
        {
            bool retorno = false;

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"INSERT INTO usuario 
                                           (nome,
                                            usuario_tipo,
                                            login,
                                            senha,
                                            ultimo_acesso,
                                            ultima_alteracao,
                                            responsavel) 
                                           VALUES 
                                           ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                           vm_cadastro_usuario.cadastro_usuario_nome,
                                           vm_cadastro_usuario.cadastro_usuario_usuario_tipo,
                                           vm_cadastro_usuario.cadastro_usuario_login,
                                           vm_cadastro_usuario.cadastro_usuario_senha,
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_usuario.cadastro_usuario_ultimo_acesso.ToString()),
                                           BASE_CORE.ConvertDateBrToMySql(vm_cadastro_usuario.cadastro_usuario_ultima_alteracao.ToString()),
                                           vm_cadastro_usuario.cadastro_usuario_responsavel
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

        public Usuario GetUsuario(int usuario_id)
        {
            Usuario usuario = new Usuario();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                                            id,
                                                            nome,
                                                            usuario_tipo,
                                                            login,
                                                            senha,
                                                            ultimo_acesso,
                                                            ultima_alteracao,
                                                            responsavel
                                                           FROM usuario
                                                           WHERE 
                                                            id = '{0}'",
                                                           usuario_id);
                MySqlDataReader reader = command.ExecuteReader();

                int count = 0;

                while (reader.Read())//Enquanto existir dados no select
                {
                    usuario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    usuario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    usuario.usuario_tipo = (reader["usuario_tipo"].ToString() != null && reader["usuario_tipo"].ToString() != string.Empty) ? Int32.Parse(reader["usuario_tipo"].ToString()) : 0;
                    usuario.login = (reader["login"].ToString() != null && reader["login"].ToString() != string.Empty) ? reader["login"].ToString() : "";
                    usuario.senha = (reader["senha"].ToString() != null && reader["senha"].ToString() != string.Empty) ? reader["senha"].ToString() : "";
                    usuario.ultimo_acesso = (reader["ultimo_acesso"].ToString() != null && reader["ultimo_acesso"].ToString() != string.Empty) ? DateTime.Parse(reader["ultimo_acesso"].ToString()) : new DateTime();
                    usuario.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    usuario.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";
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

            return usuario;
        }

        public Usuario GetUsuario(string usuario_senha, string usuario_login)
        {
            Usuario usuario = new Usuario();

            try
            {
                this.connection.Open();

                this.command.CommandText = string.Format(@"SELECT 
                                                            id,
                                                            nome,
                                                            usuario_tipo,
                                                            login,
                                                            senha,
                                                            ultimo_acesso,
                                                            ultima_alteracao,
                                                            responsavel
                                                           FROM usuario
                                                           WHERE 
                                                            senha = '{0}' and login = '{1}' limit 1",
                                                           usuario_senha,
                                                           usuario_login);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    usuario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    usuario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    usuario.usuario_tipo = (reader["usuario_tipo"].ToString() != null && reader["usuario_tipo"].ToString() != string.Empty) ? Int32.Parse(reader["usuario_tipo"].ToString()) : 0;
                    usuario.login = (reader["login"].ToString() != null && reader["login"].ToString() != string.Empty) ? reader["login"].ToString() : "";
                    usuario.senha = (reader["senha"].ToString() != null && reader["senha"].ToString() != string.Empty) ? reader["senha"].ToString() : "";
                    usuario.ultimo_acesso = (reader["ultimo_acesso"].ToString() != null && reader["ultimo_acesso"].ToString() != string.Empty) ? DateTime.Parse(reader["ultimo_acesso"].ToString()) : new DateTime();
                    usuario.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    usuario.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";
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

            return usuario;
        }

        public List<Usuario> GetAllUsuarios()
        {
            List<Usuario> usuarios_list = new List<Usuario>();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            nome
                                           FROM usuario";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Usuario usuario = new Usuario();

                    usuario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    usuario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";

                    usuarios_list.Add(usuario);
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

            return usuarios_list;
        }

        public List<Usuario> GetAllUsuariosDetalhados()
        {
            List<Usuario> usuarios_list = new List<Usuario>();

            try
            {
                this.connection.Open();

                this.command.CommandText = @"SELECT 
                                            id,
                                            nome,
                                            usuario_tipo,
                                            login,
                                            senha,
                                            ultimo_acesso,
                                            ultima_alteracao,
                                            responsavel
                                           FROM usuario ORDER BY nome";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//Enquanto existir dados no select
                {
                    Usuario usuario = new Usuario();

                    usuario.id = (reader["id"].ToString() != null && reader["id"].ToString() != string.Empty) ? Int32.Parse(reader["id"].ToString()) : 0;
                    usuario.nome = (reader["nome"].ToString() != null && reader["nome"].ToString() != string.Empty) ? reader["nome"].ToString() : "";
                    usuario.usuario_tipo = (reader["usuario_tipo"].ToString() != null && reader["usuario_tipo"].ToString() != string.Empty) ? Int32.Parse(reader["usuario_tipo"].ToString()) : 0;
                    usuario.login = (reader["login"].ToString() != null && reader["login"].ToString() != string.Empty) ? reader["login"].ToString() : "";
                    usuario.senha = (reader["senha"].ToString() != null && reader["senha"].ToString() != string.Empty) ? reader["senha"].ToString() : "";
                    usuario.ultimo_acesso = (reader["ultimo_acesso"].ToString() != null && reader["ultimo_acesso"].ToString() != string.Empty) ? DateTime.Parse(reader["ultimo_acesso"].ToString()) : new DateTime();
                    usuario.ultima_alteracao = (reader["ultima_alteracao"].ToString() != null && reader["ultima_alteracao"].ToString() != string.Empty) ? DateTime.Parse(reader["ultima_alteracao"].ToString()) : new DateTime();
                    usuario.responsavel = (reader["responsavel"].ToString() != null && reader["responsavel"].ToString() != string.Empty) ? reader["responsavel"].ToString() : "";

                    usuarios_list.Add(usuario);
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

            return usuarios_list;
        }
    }
}