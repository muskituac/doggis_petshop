using MySql.Data.MySqlClient;
using System.Configuration;


namespace WebBUSINESS.BaseConfiguration
{
    public class BaseBusiness
    {
        public MySqlConnection connection;
        public MySqlCommand command;

        public BaseBusiness()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyContext"].ConnectionString;
            this.connection = new MySqlConnection(connectionString);
            this.command = new MySqlCommand();
            this.command.Connection = this.connection;
        }
    }
}