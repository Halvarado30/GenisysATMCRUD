﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenisysATM.Models;

namespace GenisysATMCRUD
{
    public partial class FrmCuentaCliente : Form
    {
        public FrmCuentaCliente()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Datos()
        {
            // Obtener la lista que contiene todos los registro de clientes
            List<Cliente> listacliente = Cliente.LeerTodos();

            // Limpiar el listview
            lstClientes.Items.Clear();

            // Verificar si existe el cliente
            if (listacliente.Any())
            {
                listacliente.ForEach(Cliente => lstClientes.Items.Add(Cliente.nombres));
            }
            else
            {
                lstClientes.Items.Add("No hay registros");
            }
        }

        public void limpiar()
        {
            txtPIN.Text = "";
            txtsaldo.Text = "";
            txtnumero.Text = "";
            txtnumero.Focus();
            lstClientes.SelectedIndex = -1;
            lstClientes.Items.Clear();
            lstCuentas.Items.Clear();
            lstCuentas.SelectedIndex = -1;
            Datos();
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstClientes.SelectedIndex == -1 || txtPIN.Text == "" || txtsaldo.Text == "")
            {
                MessageBox.Show("Debe seleccionar un cliente y llenar el resto de la informacion requerida");
            }
            else
            {
                // Instanciar la clase CuentaCliente
                CuentaCliente nuevaCuenta = new CuentaCliente();
                nuevaCuenta.numero = txtnumero.Text;
                nuevaCuenta.pin = txtPIN.Text;
                nuevaCuenta.saldo = Convert.ToDecimal(txtsaldo.Text);

                if (CuentaCliente.AgregarCuenta(nuevaCuenta, lstClientes.SelectedItem.ToString()))
                {
                    MessageBox.Show("La cuenta se guardó con éxito");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error con los datos ingresados");
                }
            }
        }

        private void lstClientes_Click(object sender, EventArgs e)
        {
            // Obtener la lista de todos los clientes
            List<CuentaCliente> listacuenta = CuentaCliente.LeerCuentas(lstClientes.SelectedItem.ToString());
            lstCuentas.Items.Clear();

            // Verificar si existe un registro
            if (listacuenta.Any())
            {
                listacuenta.ForEach(cliente => lstCuentas.Items.Add(cliente.numero));
            }
            else
            {
                lstCuentas.Items.Add("No hay registros");
            }
        }

        private void lstCuentas_Click(object sender, EventArgs e)
        {
            // Cargar los datos de saldo
            CuentaCliente exist = CuentaCliente.ObtenerCliente(lstCuentas.SelectedItem.ToString());

            if (exist.numero != "")
            {
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                txtnumero.Text = exist.numero;
                txtPIN.Text = exist.pin;
                txtsaldo.Text = Convert.ToString(exist.saldo);
            }
            else
            {
                MessageBox.Show("Error en cargar los datos");
            }
        }

        private void FrmCuentaCliente_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // verificar que los campos esten llenos
            if (txtnumero.Text == "" || txtPIN.Text == "" || txtsaldo.Text == "")
            {
                MessageBox.Show("Debe llenar los detalles de la cuenta");
            }
            else
            {
                // Instanciar la clase CuentaCliente
                CuentaCliente cuenta = new CuentaCliente();
                cuenta.nuevoNumero = txtnumero.Text;
                cuenta.numero = lstCuentas.SelectedItem.ToString();
                cuenta.pin = txtPIN.Text;
                cuenta.saldo = Convert.ToDecimal(txtsaldo.Text);

                if (CuentaCliente.ActualizarCuenta(cuenta, lstClientes.SelectedItem.ToString()))
                {
                    MessageBox.Show("Cuenta Actualiza correctamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error en la actualización");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que el campo necesario para la eliminación
            // no se encuentre en blanco
            if (lstCuentas.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una cuenta");
            }
            else
            {
                // Instancia de la Clase CuentaCliente
                CuentaCliente deleteC = new CuentaCliente();
                deleteC.numero = lstCuentas.SelectedItem.ToString();

                if (CuentaCliente.EliminarCuenta(deleteC))
                {
                    MessageBox.Show("La cuenta se eliminó correctamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error, revise");
                }
            }
        }
    }
}
