using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ControleDePatrimonios.DAO
{
    public class MarcaDAO
    {
        public string Listar()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            SqlConnection connection = new SqlConnection();

                return "Esse texto veio da MarcaDAO";
        }
    }
}
