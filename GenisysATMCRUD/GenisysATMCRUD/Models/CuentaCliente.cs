﻿using System;
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
    class CuentaCliente
    {
        // Propiedades
        public string numero { get; set; }
        public int idCliente { get; set; }
        public decimal saldo { get; set; }
        public string pin { get; set; }
        public string nuevoNumero { get; set; }

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
                    laCuenta.idCliente = Convert.ToInt32(rdr[1]);
                    laCuenta.saldo = rdr.GetDecimal(2);
                    laCuenta.pin = rdr.GetString(3);

                    laCuenta.numero = laCuenta.numero.TrimEnd();
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

        /// <summary>
        /// Lista las cuentas pertenecientes al Cliente
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public static List<CuentaCliente> LeerCuentas(string Nombre)
        {
            // Lista de tipo CuentaCliente
            List<CuentaCliente> resultado = new List<CuentaCliente>();

            // Instanciamos la conexión
            Conexion conn = new Conexion(@"(local)\sqlexpress","GenisysATM_V2");
            string sql = @"DECLARE @codigoCliente INT
                           SET @codigoCliente = (SELECT id FROM ATM.Cliente WHERE nombres=@Cliente);
                           SELECT * FROM ATM.CuentaCliente WHERE idCliente=@codigoCliente;";
            SqlCommand cmd = conn.EjecutarComando(sql);

            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 100).Value = Nombre;
                }

                // Establecer Conexión
                conn.EstablecerConexion();

                // Ejecutar comando con SqlDataReader
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    CuentaCliente cuenta = new CuentaCliente();

                    cuenta.numero = rdr.GetString(0);
                    cuenta.idCliente = rdr.GetInt32(1);
                    cuenta.saldo = rdr.GetDecimal(2);
                    cuenta.pin = rdr.GetString(3);

                    resultado.Add(cuenta);
                }
                return resultado;
            }
            catch (SqlException)
            {
                return resultado;
            }
            finally
            {
                // Cerrar Conexión
                conn.CerrarConexion();
            }
        }

        /// <summary>
        /// Se encarga de almacenar los datos de Cuenta cliente en la base de datos
        /// </summary>
        /// <param name="lacuenta"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static bool AgregarCuenta(CuentaCliente lacuenta, string cliente)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_AgregarCuenta");

            // Definimos el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregamos los parametros correspondientes
            cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.NVarChar, 100));
            cmd.Parameters["@cliente"].Value = cliente;

            cmd.Parameters.Add(new SqlParameter("@saldo", SqlDbType.Decimal));
            cmd.Parameters["@saldo"].Value = lacuenta.saldo;

            cmd.Parameters.Add(new SqlParameter("@pin", SqlDbType.Char, 4));
            cmd.Parameters["@pin"].Value = lacuenta.pin;

            cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.Char, 14));
            cmd.Parameters["@numero"].Value = lacuenta.numero;

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
                MessageBox.Show(ex.Errors[0].ToString());
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalle de excepción");
                return false;
            }
            finally
            {
                // Cerrar Conexión
                conn.CerrarConexion();
            }
        }

        /// <summary>
        /// Se encarga de realizar los cambios realizados en la aplicación
        /// </summary>
        /// <param name="lacuenta"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static bool ActualizarCuenta(CuentaCliente lacuenta, string cliente)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_ActualizarCuentaCliente");

            // Definir el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.NVarChar, 100));
            cmd.Parameters["@cliente"].Value = cliente;

            cmd.Parameters.Add(new SqlParameter("@saldo", SqlDbType.Decimal));
            cmd.Parameters["@saldo"].Value = lacuenta.saldo;

            cmd.Parameters.Add(new SqlParameter("@pin", SqlDbType.Char, 4));
            cmd.Parameters["@pin"].Value = lacuenta.pin;

            cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.Char, 14));
            cmd.Parameters["@numero"].Value = lacuenta.numero;

            cmd.Parameters.Add(new SqlParameter("@nuevoNumero", SqlDbType.Char, 14));
            cmd.Parameters["@nuevoNumero"].Value = lacuenta.nuevoNumero;

            try
            {
                // Establecer Conexión
                conn.EstablecerConexion();

                // Ejecutar Comando
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
                // Cerrar Conexión con el servidor
                conn.CerrarConexion();
            }
        }

        /// <summary>
        /// Se encarga de eliminar el registro de la tabla CuentaCliente
        /// </summary>
        /// <param name="lacuenta"></param>
        /// <returns></returns>
        public static bool EliminarCuenta(CuentaCliente lacuenta)
        {
            Conexion conn = new Conexion(@"(local)\sqlexpress", "GenisysATM_V2");
            SqlCommand cmd = conn.EjecutarComando("sp_EliminarCuenta");

            // Definir el tipo de comando
            cmd.CommandType = CommandType.StoredProcedure;

            // Parámetros necesarios
            cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.Char, 14));
            cmd.Parameters["@numero"].Value = lacuenta.numero;

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
                MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de la excepción");
                return false;
            }
            finally
            {
                // Se cierra la conexión
                conn.CerrarConexion();
            }
        }
    }
}
