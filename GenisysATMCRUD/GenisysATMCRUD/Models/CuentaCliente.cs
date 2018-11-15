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
    class CuentaCliente
    {
        // Propiedades
        public string numero { get; set; }
        public int idCliente { get; set; }
        public decimal saldo { get; set; }
        public string pin { get; set; }

        // Constructores
        public CuentaCliente() { }

        // Métodos
        /// <summary>
        /// Obtiene la información de una cuenta para un cliente.
        /// </summary>
        /// <param name="cuenta">El número de cuenta del cliente</param>
        /// <returns>CuentaCliente el objeto que contiene la información de la cuenta del cliente</returns>
        public static CuentaCliente ObtenerCliente(string cuenta)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            CuentaCliente laCuenta = new CuentaCliente();
            string sql = @"SELECT *
                           FROM ATM.CuentaCliente
                           WHERE numero = @cuenta";

            SqlCommand cmd = conn.EjecutarComando(sql);
            SqlDataReader rdr;

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@cuenta", SqlDbType.Char, 14).Value = cuenta;

                    rdr = cmd.ExecuteReader();
                }

                while (rdr.Read())
                {
                    laCuenta.numero = rdr.GetString(0);
                    laCuenta.idCliente = rdr.GetInt16(1);
                    laCuenta.saldo = rdr.GetDecimal(2);
                    laCuenta.pin = rdr.GetString(3);
                }

                return laCuenta;
            }
            catch (SqlException ex)
            {
                return laCuenta;
            }
            finally
            {
                conn.CerrarConexion();
            }
        }

        /// <summary>
        /// Actualiza el saldo en la cuenta de un cliente. Dicha actualización
        /// solamente toma en cuenta débitos.
        /// </summary>
        /// <param name="cuenta">el número de cuenta del cliente</param>
        /// <param name="debito">el valor a ser debitado del saldo de la cuenta</param>
        /// <returns>true si el débidto pudo ser realizado. false en caso contrario.</returns>
        public static bool ActualizarSaldo(string cuenta, decimal debito)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            CuentaCliente laCuenta = CuentaCliente.ObtenerCliente(cuenta);

            SqlCommand cmd = conn.EjecutarComando("sp_ActualizarSaldoCuenta");

            cmd.CommandType = CommandType.StoredProcedure;

            // Parámetros
            cmd.Parameters.Add(new SqlParameter("cuenta", SqlDbType.Char, 14));
            cmd.Parameters.Add(new SqlParameter("debito", SqlDbType.Decimal));
            cmd.Parameters["cuenta"].Value = laCuenta.numero;
            cmd.Parameters["debito"].Value = debito;

            try
            {
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                conn.CerrarConexion();
            }
        }

        /// <summary>
        /// Actualiza el valor del PIN para la cuenta de un cliente.
        /// </summary>
        /// <param name="laCuenta">número de cuenta del cliente</param>
        /// <param name="pinNuevo">el nuevo valor para el PIN</param>
        /// <returns>true si se actualiza el PIN. false en caso contrario.</returns>
        public static bool ActualizarPin(CuentaCliente laCuenta, string pinNuevo)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");

            SqlCommand cmd = conn.EjecutarComando("sp_ActualizarPin");
            cmd.Parameters.Add(new SqlParameter("cuenta", SqlDbType.Char, 14));
            cmd.Parameters.Add(new SqlParameter("pinActual", SqlDbType.Char, 4));
            cmd.Parameters.Add(new SqlParameter("pinNuevo", SqlDbType.Char, 4));

            cmd.Parameters["cuenta"].Value = laCuenta.numero;
            cmd.Parameters["pinActual"].Value = laCuenta.pin;
            cmd.Parameters["pinNuevo"].Value = pinNuevo;

            try
            {
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                conn.CerrarConexion();
            }
        }
    }
}
