using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Agregar los namespaces necesarios
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GenisysATM.Models
{
    class Configuracion
    {
        // Propiedades
        public int id { get; set; }
        public string appKey { get; set; }
        public string valor { get; set; }
        public string descripcion { get; set; }
        public string NewappKey { get; set; }

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

        public static Configuracion ObtenerConfiguracion2(string nombre)
        {
            SqlDataReader rdr;
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando(@"SELECT id, appKey, descripcion, valor 
                                                    FROM ATM.Configuracion 
                                                    WHERE appKey = @Nombre");
            Configuracion resultados = new Configuracion();

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@Nombre", SqlDbType.Char, 13).Value = nombre;

                    rdr = cmd.ExecuteReader();
                }

                while (rdr.Read())
                {
                    resultados.id = Convert.ToInt32(rdr[0]);
                    resultados.appKey = rdr.GetString(1);
                    resultados.descripcion = rdr.GetString(2);
                    resultados.valor = rdr.GetString(3);
                }

                return resultados;
            }
            catch (SqlException ex)
            {
                return resultados;
            }
            finally
            {
                conn.CerrarConexion();
            }
            
        }

        /// <summary>
        /// obtiene una lista de todas las configuraciones que se encuentren
        /// disponibles en la tabla
        /// </summary>
        /// <returns></returns>
        public static List<Configuracion> LeerTodos()
        {
            // Lista una de tipo de clientes
            List<Configuracion> resultados = new List<Configuracion>();

            //instanciamos la conexion
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            string sql = @"SELECT id,appKey,valor,descripcion
                    FROM ATM.Configuracion;";

            SqlCommand cmd = conn.EjecutarComando(sql);

            try
            {
                // Establecer la conexión
                conn.EstablecerConexion();

                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    Configuracion config = new Configuracion();
                    // Asignar los valores de Reader al objeto Departamento
                    config.id = Convert.ToInt32(rdr[0]);
                    config.appKey = rdr.GetString(1);
                    config.valor = rdr.GetString(2);
                    config.descripcion = rdr.GetString(3);


                    // Agregar el Departamento a la List<Departamento>
                    resultados.Add(config);
                }

                return resultados;
            }
            catch (SqlException)
            {
                return resultados;
            }
            finally
            {
                // Cerrar la conexión
                conn.CerrarConexion();
            }
        }

        /// <summary>
        /// Se encarga de almacenar los datos de configuracion en la base de datos
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static bool AgregarConfiguracion(Configuracion config)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_AgregarConfiguracion");

            // Definir el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Definir los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NChar, 50));
            cmd.Parameters["@nombre"].Value = config.appKey;

            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NChar, 200));
            cmd.Parameters["@descripcion"].Value = config.descripcion;

            cmd.Parameters.Add(new SqlParameter("@valor", SqlDbType.NChar, 50));
            cmd.Parameters["@valor"].Value = config.valor;

            try
            {
                // Establecer la conexión
                conn.EstablecerConexion();

                // Ejecutar comando
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalle de la excepción: ");
                return false;
            }
            finally
            {
                // Cierre de la conexión
                conn.CerrarConexion();
            }
        }
    }
}
