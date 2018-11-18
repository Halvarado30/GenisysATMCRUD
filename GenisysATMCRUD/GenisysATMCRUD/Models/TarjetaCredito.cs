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
    class TarjetaCredito
    {
        // Propiedades
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal monto { get; set; }
        public decimal limite { get; set; }
        public int idCliente { get; set; }
        public string nuevaDescripcion { get; set; }

        // Métodos
        public static TarjetaCredito ObtenerTarjetaCliente(string Tarjeta, string Cliente)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            string sql = @"DECLARE @codigoCliente INT
                  SET @codigoCliente =(SELECT id FROM ATM.Cliente WHERE nombres=@Cliente);
                  SELECT t.id,t.descripcion,t.monto,t.limite FROM ATM.TarjetaCredito AS t INNER JOIN ATM.CLiente as c
                  ON t.descripcion=@Tarjeta and t.idCliente=@codigoCliente;";
            TarjetaCredito resultado = new TarjetaCredito();

            SqlCommand cmd = conn.EjecutarComando(sql);
            SqlDataReader rdr;

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 100).Value = Cliente;
                    cmd.Parameters.Add("@Tarjeta", SqlDbType.NVarChar, 100).Value = Tarjeta;

                    rdr = cmd.ExecuteReader();
                }

                while (rdr.Read())
                {
                    resultado.id = rdr.GetInt32(0);
                    resultado.descripcion = rdr.GetString(1);
                    resultado.monto = rdr.GetDecimal(2);
                    resultado.limite = rdr.GetDecimal(3);
                }
                return resultado;
            }
            catch (SqlException ex)
            {
                return resultado;
            }
            finally
            {
                // Cerrar la conexión
                conn.CerrarConexion();
            }
        }

        public static List<TarjetaCredito> LeerTodos(string Cliente)
        {
            // Lista una de tipo de clientes
            List<TarjetaCredito> resultados = new List<TarjetaCredito>();

            //instanciamos la conexion
            Conexion conexion = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            string sql = @"DECLARE @codigoCliente INT
                  SET @codigoCliente =(SELECT id FROM ATM.Cliente WHERE nombres=@Cliente);
                  SELECT t.id,t.descripcion,t.monto,t.limite FROM ATM.TarjetaCredito AS t
                  WHERE t.idCliente=@codigoCliente;";

            SqlCommand cmd = conexion.EjecutarComando(sql);

            try
            {
                // Establecer la conexión
                conexion.EstablecerConexion();
                SqlDataReader rdr;
                using (cmd)
                {
                    cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 100).Value = Cliente;
                    rdr = cmd.ExecuteReader();
                }

                //Recorremos los elementos que se encuentra guardados
                // en la lista tipo tarjetaCrédito
                while (rdr.Read())
                {
                    TarjetaCredito tarjeta = new TarjetaCredito();
                    // Asignar los valores de Reader al objeto TarjetaCrédito
                    tarjeta.id = rdr.GetInt32(0);
                    tarjeta.descripcion = rdr.GetString(1);
                    tarjeta.monto = rdr.GetDecimal(2);
                    tarjeta.limite = rdr.GetDecimal(3);

                    // Agregar el Departamento a la List<TarjetaDepartamento>
                    resultados.Add(tarjeta);
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
                conexion.CerrarConexion();
            }
        }

        public static bool InsertarTarjeta(string elcliente, TarjetaCredito latarjeta)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_AgregarTarjeta");

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Definir los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar, 100));
            cmd.Parameters["@descripcion"].Value = latarjeta.descripcion;
                
            cmd.Parameters.Add(new SqlParameter("@monto", SqlDbType.Decimal));
            cmd.Parameters["@monto"].Value = latarjeta.monto;

            cmd.Parameters.Add(new SqlParameter("@limite", SqlDbType.Decimal));
            cmd.Parameters["@limite"].Value = latarjeta.limite;

            cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.NVarChar, 100));
            cmd.Parameters["@cliente"].Value = elcliente;

            try
            {
                // Establecer la conexión
                conn.EstablecerConexion();

                // ejecutamos el comando
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

        public static bool ActualizarTarjeta(string elcliente, TarjetaCredito latarjeta)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_ActualizarTarjeta");

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Definir los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar, 100));
            cmd.Parameters["@descripcion"].Value = latarjeta.descripcion;

            cmd.Parameters.Add(new SqlParameter("@monto", SqlDbType.Decimal));
            cmd.Parameters["@monto"].Value = latarjeta.monto;

            cmd.Parameters.Add(new SqlParameter("@limite", SqlDbType.Decimal));
            cmd.Parameters["@limite"].Value = latarjeta.limite;

            cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.NVarChar, 100));
            cmd.Parameters["@cliente"].Value = elcliente;

            cmd.Parameters.Add(new SqlParameter("@nuevaDescripcion", SqlDbType.NVarChar, 100));
            cmd.Parameters["@nuevaDescripcion"].Value = latarjeta.nuevaDescripcion;

            try
            {
                // Establecer la conexión
                conn.EstablecerConexion();

                // ejecutamos el comando
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

        public static bool EliminarTarjeta(string elcliente, TarjetaCredito latarjeta)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_EliminarTarjeta");

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar, 100));
            cmd.Parameters["@descripcion"].Value = latarjeta.descripcion;

            cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.NVarChar, 100));
            cmd.Parameters["@cliente"].Value = elcliente;

            try
            {
                // Establecer la conexión
                conn.EstablecerConexion();

                // Ejecutar Comando
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalle de la excepción");
                return false;
            }
            finally
            {
                // Cerrar la conexión
                conn.CerrarConexion();
            }
        }
    }
}
