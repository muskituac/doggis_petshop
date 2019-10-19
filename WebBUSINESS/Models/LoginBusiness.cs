using MySql.Data.MySqlClient;
using System;
using WebBASE.DTO;
using WebBASE.ViewModel;
using WebBUSINESS.BaseConfiguration;

namespace WebBUSINESS.Models
{
    public class LoginBusiness:BaseBusiness
    {
        public Usuario FazerLogin(ViewModelLogin vm_login)
        {
            Usuario usuario = new Usuario();

            try
            {
                UsuarioBusiness usuario_business = new UsuarioBusiness();
                usuario = usuario_business.GetUsuario(vm_login.LoginSenha, vm_login.LoginUsuario);
            }
            catch(Exception ex)
            {
                if (this.connection.State == System.Data.ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return usuario;
        }

        
    }
}