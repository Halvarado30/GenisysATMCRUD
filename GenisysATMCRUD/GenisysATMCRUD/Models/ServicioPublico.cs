using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Agregar los namespaces necesarios
using System.Data;
using System.Data.SqlClient;

namespace GenisysATM.Models
{
    class ServicioPublico
    {
        // Propiedades
        public int id { get; set; }
        public string descripcion { get; set; }
        public string correccion { get; set; }

        // Constructores
        public ServicioPublico() { }

        // Métodos
        /// <summary>
        /// Método que obtendra la información contenida en la tabla ServicioPublico
        /// </summary>
        public static ServicioPublico obtenerServicio(string descripcion)
        {
            Conexion conexion = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            string sql;
            ServicioPublico resultado = new ServicioPublico();

            // Consulta SQL
            sql = @"SELECT *
                    FROM ATM.ServicioPublico
                    WHERE descripcion = @descripcion";

            SqlCommand cmd = conexion.EjecutarComando(sql);
            SqlDataReader rdr;

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 100).Value = descripcion;

                    rdr = cmd.ExecuteReader();
                }

                while (rdr.Read())
                {
                    resultado.id = rdr.GetInt32(0);
                    resultado.descripcion = rdr.GetString(1);
                }
                return resultado;
            }
            catch (SqlException ex)
            {
                return resultado;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


        public static List<ServicioPublico> Leer()
        {
            // Lista tipo ServicioPublico
            List<ServicioPublico> resultado = new List<ServicioPublico>();

            // Iniciamos Conexión
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            string sql = @"SELECT * FROM
                            ATM.ServicioPublico";
            SqlCommand cmd = conn.EjecutarComando(sql);

            try
            {
                // Iniciar la conexión
                conn.EstablecerConexion();

                // Ejecutamos el comando
                SqlDataReader rdr = cmd.ExecuteReader();

                // Se recorre los datos que se encuentran registrados
                while (rdr.Read())
                {
                    ServicioPublico Serv = new ServicioPublico();
                    // Asignar los valores al datareader
                    Serv.id = rdr.GetInt32(0);
                    Serv.descripcion = rdr.GetString(1);

                    // Agregar los datos a la lista
                    resultado.Add(Serv);
                }
                return resultado;
            }
            catch (SqlException)
            {
                return resultado;
            }
            finally
            {
                // Cerrar la conexión
                conn.CerrarConexion();
            }
        }
        /// <summary>
        /// Se encarga de almacenar un nuevo registro de 
        /// servicio público en la base de datos
        /// </summary>
        public static bool InsertaServP(ServicioPublico elservicio)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_AgregarServicioPublico");

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Se definen los parámetros requeridos
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar, 100));
            cmd.Parameters["@descripcion"].Value = elservicio.descripcion;

            try
            {
                // Se establece la conexión
                conn.EstablecerConexion();

                // Se ejecuta el comando
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Errors[0].ToString());
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de la excepción");
                return false;
            }
            finally
            {
                conn.CerrarConexion();
            }
        }

        ///<summary>
        /// Método encargado de actualizar los datos de los ServiciosPublicos
        /// </summary>
        public static bool ActualizarServicioPublico(ServicioPublico elservicio)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_ActualizarServicioPublico");

            // Definir el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros requeridos
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar, 100));
            cmd.Parameters["@descripcion"].Value = elservicio.correccion;

            cmd.Parameters.Add(new SqlParameter("@correccion", SqlDbType.NVarChar, 100));
            cmd.Parameters["@correccion"].Value = elservicio.descripcion;

            try
            {
                // Establecer la conexión
                conn.EstablecerConexion();

                // Ejecutar el comando
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Errors[0].ToString());
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de la excepción");
                return false;
            }
            finally
            {
                // Cerrar la conexión
                conn.CerrarConexion();
            }
        }
        
        public static bool EliminarServicioPublico(ServicioPublico elservicio)
        {
            // Definir la conexión
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");

            // Se envia el comando
            SqlCommand cmd = conn.EjecutarComando("sp_EliminarServicioPublico");
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar, 100));
            cmd.Parameters["@descripcion"].Value = elservicio.descripcion;

            try
            {
                // Establecer Conexión
                conn.EstablecerConexion();

                // Ejecutar comando
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de la excepción");
                return false;
            }
            finally
            {
                conn.CerrarConexion();
            }
        }
    }
}
