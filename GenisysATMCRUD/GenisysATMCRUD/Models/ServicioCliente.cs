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
    class ServicioCliente
    {
        // Propiedades
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idServicio { get; set; }
        public decimal saldo { get; set; }
        public string detalle { get; set; }

        // Constructores
        public ServicioCliente() { }

        // Métodos
        /// <summary>
        /// Se encarga de Almacenar los datos en la tabla 
        /// ServicioCliente de la base de datos
        /// </summary>
        /// <param name="elcliente"></param>
        /// <param name="elservicio"></param>
        /// <returns></returns>
        public static bool AgregarClienteServicio(string elcliente, string elservicio, ServicioCliente sc)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress","GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_AgregarServicioCliente");

            // Se define el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Se agregan los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.NVarChar, 100));
            cmd.Parameters["@cliente"].Value = elcliente;

            cmd.Parameters.Add(new SqlParameter("@servicio", SqlDbType.NVarChar, 100));
            cmd.Parameters["@servicio"].Value = elservicio;

            cmd.Parameters.Add(new SqlParameter("@saldo", SqlDbType.Decimal));
            cmd.Parameters["@saldo"].Value = sc.saldo;

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
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalle de la excepción");
                return false;
            }
            finally
            {
                conn.CerrarConexion();
            }

        } 

        /// <summary>
        /// Se encarga de almacenar los cambios realizados
        /// en el servicio de un cliente
        /// </summary>
        /// <param name="elcliente"></param>
        /// <param name="elservicio"></param>
        /// <param name="sc"></param>
        /// <returns></returns>
        public static bool ActualizarClienteServicio(string elcliente, string elservicio, ServicioCliente sc)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_ActualizarServicioCliente");

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregamos los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.NVarChar, 100));
            cmd.Parameters["@cliente"].Value = elcliente;

            cmd.Parameters.Add(new SqlParameter("@servicio", SqlDbType.NVarChar, 100));
            cmd.Parameters["@servicio"].Value  = elservicio;

            cmd.Parameters.Add(new SqlParameter("@saldo", SqlDbType.Decimal));
            cmd.Parameters["@saldo"].Value = sc.saldo;

            try
            {
                // Establecemos la conexión
                conn.EstablecerConexion();

                // Ejecutamos el comando
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

        public static bool EliminarClienteServicio(string elcliente, string elservicio)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_EliminarServicioCliente");

            // Definir el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregamos los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.NVarChar, 100));
            cmd.Parameters["@cliente"].Value = elcliente;

            cmd.Parameters.Add(new SqlParameter("@servicio", SqlDbType.NVarChar, 100));
            cmd.Parameters["@servicio"].Value = elservicio;

            try
            {
                // Establecemos conexión
                conn.EstablecerConexion();

                //  Ejecutar el comando
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de excepción");
                return false;
            }
            finally
            {
                // Cerrar conexión
                conn.CerrarConexion();
            }

        }

        // Se encarga de listar todos los servicios
        // ligados a un cliente que están
        // en la base de datos
        public static List<ServicioCliente>LeerServiciosCliente (string nombre)
        {
            // Se crea una lista de tipo ServicioCliente
            List<ServicioCliente> resultado = new List<ServicioCliente>();

            // Se instancia la conexión
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            string sql = @"DECLARE @codigoCliente INT
                        SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres=@cliente);
                        SELECT sp.descripcion, sc.saldo FROM ATM.ServicioPublico AS sp INNER JOIN ATM.ServicioCliente
                        AS sc ON sc.idServicio=sp.id and sc.idCliente=@codigoCliente;";
            // Enviamos el comando
            SqlCommand cmd = conn.EjecutarComando(sql);

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 100).Value = nombre;
                }

                // Se establece la conexión
                conn.EstablecerConexion();

                SqlDataReader rdr = cmd.ExecuteReader();

                // Se recorre los datos almacenados en la lista
                while (rdr.Read())
                {
                    ServicioCliente Client = new ServicioCliente();
                    Client.detalle = rdr.GetString(0);
                    Client.saldo = rdr.GetDecimal(1);

                    resultado.Add(Client);
                }
                return resultado;
            }
            catch (SqlException)
            {
                return resultado;
            }
            finally
            {
                // se cierra la conexión
                conn.CerrarConexion();
            }
        }

        ///
        public static ServicioCliente LeerDato(string servicio, string cliente)
        {
            // Instancia de una variable tipo ServicioCliente
            ServicioCliente resultado = new ServicioCliente();

            // Instanciar la conexión
            Conexion conn = new Conexion(@"(local)\sqlexpress","GenisysATM_V2");

            string sql = @"DECLARE @codigoServicio INT
                           DECLARE @codigoCliente INT
                           SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres=@Nombre);
                           SET @codigoServicio = (SELECT id FROM ATM.ServicioPublico WHERE descripcion=@Servicio);
                           SELECT sc.id, sc.saldo FROM ATM.ServicioCliente AS sc WHERE sc.idServicio=@codigoServicio AND
                           idCliente=@codigoCliente;";

            SqlCommand cmd = conn.EjecutarComando(sql);

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = cliente;
                    cmd.Parameters.Add("@Servicio", SqlDbType.NVarChar, 100).Value = servicio;
                }

                // Establecer Conexión
                conn.EstablecerConexion();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    resultado.id = rdr.GetInt32(0);
                    resultado.saldo = rdr.GetDecimal(1);
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
    }
}
