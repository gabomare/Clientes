using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Conexion : IDisposable
    {

        public SqlConnection con;
        public Conexion(string cadena)
        {
            try
            {

                con = new SqlConnection(cadena);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public SqlConnection GetConexion()
        {
            return con;
        }
        public void Dispose()
        {
            con.Close();
        }
    }
}
