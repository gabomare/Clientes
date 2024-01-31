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

                    var result = conn.QueryFirstOrDefault<int>("ActualizarCliente", parameters, commandType: CommandType.StoredProcedure);
                    ok = result == 1;
                }

            }
            catch (Exception ex)
            {

            }

            return ok;
        }

        public async Task<RespuestaSesion> ValidarSesion(string Usuario, string Clave)
        {
            RespuestaSesion sesion = new RespuestaSesion();
            bool ok = false;
            try
            {

                using (var conn = new SqlConnection(cadenaBD))
                {
                    conn.Open();

                    var parameters = new
                    {
                        Usuario = Usuario,
                        Clave = Clave,
                    };

                    sesion = conn.QueryFirstOrDefault<RespuestaSesion>("ValidarSesion", parameters, commandType: CommandType.StoredProcedure);
                    
                }

            }
            catch (Exception ex)
            {

            }

            return sesion;
        }
    }
}
