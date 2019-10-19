using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBUSINESS.Base
{
    public static class BASE_CORE
    {

        public static string ConvertDateBrToMySql(string date_br)
        {
            string date_br_only = date_br.Split(' ')[0];
            string hora_br_only = date_br.Split(' ').Count() > 0 ? date_br.Split(' ')[1] : "";
            string[] date_br_arr = date_br_only.Split('/');

            string date_dia = date_br_arr[0];
            string date_mes = date_br_arr[1];
            string date_ano = date_br_arr[2];

            string date_final_my_sql = date_ano + "-" + date_mes + "-" + date_dia + " " + hora_br_only;

            return date_final_my_sql;
        }

        public static string ConvertDateMySqlToBr(string date_mysql)
        {
            string date_mysql_only = date_mysql.Split('T')[0];
            string hora_mysql_only = date_mysql.Split('T').Count() > 0 ? date_mysql.Split(' ')[1] : "";
            string[] date_mysql_arr = date_mysql_only.Split('-');

            string date_dia = date_mysql_arr[2];
            string date_mes = date_mysql_arr[1];
            string date_ano = date_mysql_arr[0];

            string date_final_br = date_dia + "/" + date_mes + "/" + date_ano + " " + hora_mysql_only;

            return date_final_br;
        }

    }
}