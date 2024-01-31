using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Data
{
    public class Service
    {
        private readonly string cadenaBD;
        public Service(string _cadenaBD) {
            this.cadenaBD = _cadenaBD;
        }
        public async Task<List<Cliente>> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {

                using (var conn = new SqlConnection(cadenaBD))
                {
                    conn.Open();

                    // Utilizando Dapper para ejecutar el procedimiento almacenado y mapear los resultados a la lista de clientes
                    clientes = conn.Query<Cliente>("GetClientes", commandType: CommandType.StoredProcedure).ToList();

                }
                
            }
            catch (Exception ex)
            {

            }

            return clientes;
        }

        public async Task<bool> PutClientes(Cliente cliente)
        {
            bool ok = false;
            try
            {

                using (var conn = new SqlConnection(cadenaBD))
                {
                    conn.Open();

                    var parameters = new
                    {
                        IdCliente = cliente.IdCliente,
                        TipoIdentificacion = cliente.TipoIdentificacion,
                        NumeroIdentificacion = cliente.NumeroIdentificacion,
                        Nombre = cliente.Nombre,
                        Apellido = cliente.Apellido,
                        Telefono = cliente.Telefono
                    };

                    // Utilizando Dapper para ejecutar el procedimiento almacenado y mapear los resultados a la lista de clientes
                    var result = conn.QueryFirstOrDefault<int>("ActualizarCliente", parameters, commandType: CommandType.StoredProcedure);
                    ok = result == 1;
                }

            }
            catch (Exception ex)
            {

            }

            return ok;
        }
    }
}
