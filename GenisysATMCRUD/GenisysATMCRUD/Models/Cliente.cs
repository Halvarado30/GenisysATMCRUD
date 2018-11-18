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
    class Cliente
    {
        // Propiedades
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identidad { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }

        // Métodos
        /// <summary>
        /// Obtiene un cliente desde la tabla ATM.Cliente
        /// </summary>
        /// <param name="identidad">La identidad del cliente (13 caracteres)</param>
        /// <returns>Un objeto de tipo Cliente.</returns>
        public static Cliente ObtenerCliente(string identidad)
        {
            Conexion conexion = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            string sql;
            Cliente resultado = new Cliente();

            // Query SQL
            sql = @"SELECT *
                    FROM ATM.Cliente
                    WHERE identidad = @identidad";

            SqlCommand cmd = conexion.EjecutarComando(sql);
            SqlDataReader rdr;

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@identidad", SqlDbType.Char, 13).Value = identidad;

                    rdr = cmd.ExecuteReader();
                }

                while (rdr.Read())
                {
                    resultado.id = Convert.ToInt16(rdr[0]);
                    resultado.nombres = rdr.GetString(1);
                    resultado.apellidos = rdr.GetString(2);
                    resultado.identidad = rdr.GetString(3);
                    resultado.direccion = rdr.GetString(4);
                    resultado.telefono = rdr.GetString(5);
                    resultado.celular = rdr.GetString(6);

                    // Remover espacios
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

        /// <summary>
        /// Método para la inserción de datos
        /// </summary>
        public static bool InsertarCliente(Cliente nuevoCliente)
        {
            Conexion conexion = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conexion.EjecutarComando("sp_insertarCliente");

            // Establecer el comando como un Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;


            // Parámetros del Stored Procedure
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 100));
            cmd.Parameters["@nombre"].Value = nuevoCliente.nombres;
            cmd.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar, 100));
            cmd.Parameters["@apellido"].Value = nuevoCliente.apellidos;
            cmd.Parameters.Add(new SqlParameter("@identidad", SqlDbType.Char, 13));
            cmd.Parameters["@identidad"].Value = nuevoCliente.identidad;
            cmd.Parameters.Add(new SqlParameter("@direccion", SqlDbType.NVarChar, 2000));
            cmd.Parameters["@direccion"].Value = nuevoCliente.direccion;
            cmd.Parameters.Add(new SqlParameter("@telefono", SqlDbType.Char, 9));
            cmd.Parameters["@telefono"].Value = nuevoCliente.telefono;
            cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.Char, 9));
            cmd.Parameters["@celular"].Value = nuevoCliente.celular;

            // intentamos ejecutar el procedimiento
            try
            {
                conexion.EstablecerConexion();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
               // MessageBox.Show(ex.StackTrace);

                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }

        }

        public  static bool ActualizarCliente(Cliente elCliente)
        {
            // estabecer conexion
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");

            //define el comando
            SqlCommand cmd = conn.EjecutarComando("sp_ActualizarCliente");

            //definir tipo comando
            cmd.CommandType = CommandType.StoredProcedure;

            // agregar los parametros necesarios

            cmd.Parameters.Add(new SqlParameter("@identidad", SqlDbType.Char, 13));
            cmd.Parameters["@identidad"].Value = elCliente.identidad;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 100));
            cmd.Parameters["@nombre"].Value = elCliente.nombres;
            cmd.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar, 100));
            cmd.Parameters["@apellido"].Value = elCliente.apellidos;
            cmd.Parameters.Add(new SqlParameter("@direccion", SqlDbType.NVarChar, 2000));
            cmd.Parameters["@direccion"].Value = elCliente.direccion;
            cmd.Parameters.Add(new SqlParameter("@telefono", SqlDbType.Char, 9));
            cmd.Parameters["@telefono"].Value = elCliente.telefono;
            cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.Char, 9));
            cmd.Parameters["@celular"].Value = elCliente.celular;

            // verificamos si el cliente yatiene un registro
            Cliente verifica = new Cliente();
            verifica = Cliente.ObtenerCliente(elCliente.identidad);

            
                try
                {
                if (verifica.id == 0 || verifica.identidad == "")
                {
                    MessageBox.Show("El cliente no existe, revise");
                    return false;
                }
                else
                {
                    conn.EstablecerConexion();
                    cmd.ExecuteNonQuery();
                    return true;
                }
               
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

        // método que se encarga de listar todos los elementos de 
        // la tabla cliente

        public static List<Cliente> ListarClienteTodos()
        {
            // declarmos la lista de tipo cliente
            List<Cliente> losClientes = new List<Cliente>();

            // Establecemos la conexión
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");

            // especificamos el query de consulta.
            string sql = "SELECT * FROM ATM.Cliente";

            //Especificamos el comando y el tipo de comando
           SqlCommand cmd = conn.EjecutarComando(sql);

            try
            {
                // establecemos la conexión
                conn.EstablecerConexion();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cliente elCliente = new Cliente();
                    elCliente.id = Convert.ToInt16(rdr[0]);
                    elCliente.nombres = rdr.GetString(1);
                    elCliente.apellidos = rdr.GetString(2);
                    elCliente.identidad = rdr.GetString(3);
                    elCliente.direccion = rdr.GetString(4);
                    elCliente.telefono = rdr.GetString(5);
                    elCliente.celular = rdr.GetString(6);

                    // agregamos los datos a la lista
                    losClientes.Add(elCliente);
                }
                return losClientes;

            }
            catch (Exception)
            {

                return losClientes;
            }
            finally
            {
                conn.CerrarConexion();
            }
            
            
        }

        // Método que se encargará de obtener los datos de los clientes
        // basandose en el parametro de nombre.

        public static Cliente ObtenerCliente2(string nombress)
        {
            Conexion conexion = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            string sql;
            Cliente resultado = new Cliente();

            // Query SQL
            sql = @"SELECT *
                    FROM ATM.Cliente
                    WHERE nombres = @nombre";

            SqlCommand cmd = conexion.EjecutarComando(sql);
            SqlDataReader rdr;

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = nombress;

                    rdr = cmd.ExecuteReader();
                }

                while (rdr.Read())
                {
                    resultado.id = Convert.ToInt16(rdr[0]);
                    resultado.nombres = rdr.GetString(1);
                    resultado.apellidos = rdr.GetString(2);
                    resultado.identidad = rdr.GetString(3);
                    resultado.direccion = rdr.GetString(4);
                    resultado.telefono = rdr.GetString(5);
                    resultado.celular = rdr.GetString(6);
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

        // Método Eliminar Cliente
        public static bool EliminarCliente(Cliente elcliente)
        {
            // Establecer conexión
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");

            // Definir el comando
            SqlCommand cmd = conn.EjecutarComando("sp_EliminarCliente");

            // Definir tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@identidad", SqlDbType.Char, 13));
            cmd.Parameters["@identidad"].Value = elcliente.identidad;

            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 100));
            cmd.Parameters["@nombre"].Value = elcliente.nombres;

            // verificamos si el cliente yatiene un registro
            Cliente verifica = new Cliente();
            verifica = Cliente.ObtenerCliente(elcliente.identidad);


            try
            {
                    conn.EstablecerConexion();
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
                // Cerramos la conexión
                conn.CerrarConexion();
            }
        }
    }
}
