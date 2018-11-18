using System;
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
    public partial class FrmTarjetaCredito : Form
    {
        public FrmTarjetaCredito()
        {
            InitializeComponent();
        }

        private void FrmTarjetaCredito_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar()
        {
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            txtdecripcion.Text = "";
            txtmonto.Text = "";
            txtlimite.Text = "";
            lstClientes.Items.Clear();
            lstTarjetas.Items.Clear();
            Datos();
            txtdecripcion.Focus();
        }

        public void Datos()
        {
            // obtenemos la lista de todos los clientes de la tabla
            List<Cliente> listaCliente = Cliente.LeerTodos();

            // Limpiar el listView
            lstClientes.Items.Clear();

            // Verificar si existen departamentos
            if (listaCliente.Any())
            {
                listaCliente.ForEach(Cliente => lstClientes.Items.Add(Cliente.nombres));
            }
            else
                lstClientes.Items.Add("¡No hay Datos!");
        }

        private void lstClientes_Click(object sender, EventArgs e)
        {
            // obtenemos la lista de todos los clientes de la tabla
            List<TarjetaCredito> listaTarjeta = TarjetaCredito.LeerTodos(lstClientes.SelectedItem.ToString());

            // Limpiar el listView
            lstTarjetas.Items.Clear();

            // Verificar si existen departamentos
            if (listaTarjeta.Any())
            {
                listaTarjeta.ForEach(tarjeta => lstTarjetas.Items.Add(tarjeta.descripcion));
            }
            else
                lstTarjetas.Items.Add("¡Cliente sin Tarjetas!");
        }

        private void lstTarjetas_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;

            TarjetaCredito existe = TarjetaCredito.ObtenerTarjetaCliente(lstTarjetas.SelectedItem.ToString(), lstClientes.SelectedItem.ToString());
            //verificamos si el cliente esta registrado e inhabilitamos el boton guardar
            if (existe.id != 0)
            {
                // deshabilitamos el boton de guardar, dado que ya existe el cliente
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                txtdecripcion.Text = existe.descripcion;
                txtmonto.Text = Convert.ToString(existe.monto);
                txtlimite.Text = Convert.ToString(existe.limite);

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtmonto.Text == "" || txtlimite.Text == "" || txtdecripcion.Text == "" || lstClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Cliente y llenar el resto de los campos");
            }
            else
            {
                // Instancia de Clase TarjetaCredito
                TarjetaCredito tarjeta = new TarjetaCredito();
                tarjeta.monto = Convert.ToDecimal(txtmonto.Text);
                tarjeta.limite = Convert.ToDecimal(txtlimite.Text);
                tarjeta.descripcion = txtdecripcion.Text;

                if (TarjetaCredito.InsertarTarjeta(lstClientes.SelectedItem.ToString(), tarjeta))
                {
                    MessageBox.Show("Registro realizado con éxito");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error, Revise");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtmonto.Text == "" || txtlimite.Text == "" || txtdecripcion.Text == "" || lstClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Cliente y llenar el resto de los campos a editar");
            }
            else
            {
                // Instancia de Clase TarjetaCredito
                TarjetaCredito actualizartarjeta = new TarjetaCredito();
                actualizartarjeta.monto = Convert.ToDecimal(txtmonto.Text);
                actualizartarjeta.limite = Convert.ToDecimal(txtlimite.Text);
                actualizartarjeta.descripcion = lstTarjetas.SelectedItem.ToString();
                actualizartarjeta.nuevaDescripcion = txtdecripcion.Text;

                if (TarjetaCredito.ActualizarTarjeta(lstClientes.SelectedItem.ToString(), actualizartarjeta))
                {
                    MessageBox.Show("Registro actualizado con éxito");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error, Revise");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
