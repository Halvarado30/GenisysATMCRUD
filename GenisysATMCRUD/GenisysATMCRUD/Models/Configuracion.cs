using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Agregar los namespaces necesarios
using System.Data;
using System.Data.SqlClient;

namespace GenisysATM.Models
{
    class Configuracion
    {
        // Propiedades
        public int id { get; set; }
        public string appKey { get; set; }
        public string valor { get; set; }
        public string descripcion { get; set; }

        // Constructores
        public Configuracion() { }

        // Métodos
        public static string ObtenerConfiguracion(string key)
        {
            string valor = "";
            SqlDataReader rdr;
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando(@"SELECT valor 
                                                    FROM ATM.Configuracion 
                                                    WHERE appKey = @key");

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@key", SqlDbType.NVarChar, 50).Value = key;

                    rdr = cmd.ExecuteReader();
                }

                while (rdr.Read())
                {
                    valor = rdr.GetString(0);
                }

                return valor;
            }
            catch (SqlException ex)
            {
                return "Clave no válida";
            }
            finally
            {
                conn.CerrarConexion();
            }
        }
    }
}
