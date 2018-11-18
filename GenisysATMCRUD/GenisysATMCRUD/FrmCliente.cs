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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Instancia de la Clase Cliente
            Cliente nuevoCliente = new Cliente();
            nuevoCliente.nombres = txtnombres.Text;
            nuevoCliente.apellidos = txtapellidos.Text;
            nuevoCliente.identidad = txtidentidad.Text;
            nuevoCliente.direccion = txtdireccion.Text;
            nuevoCliente.telefono = txttelefono.Text;
            nuevoCliente.celular = txtcelular.Text;

            if (Cliente.InsertarCliente(nuevoCliente))
            {
                MessageBox.Show("Se han agregado los datos con éxito");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un problema en la inserción de los datos");
            }
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtidentidad.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcelular.Text = "";
            lstClientes.ResetText();
            txtnombres.Focus();
        }

        private void lstCliente_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnAgregar.Enabled = false;
            Cliente elCliente = new Cliente();
            elCliente = Cliente.ObtenerCliente2(lstClientes.SelectedItem.ToString());

            txtnombres.Text = elCliente.nombres;
            txtapellidos.Text = elCliente.apellidos;
            txtidentidad.Text = elCliente.identidad;
            txtdireccion.Text = elCliente.direccion;
            txttelefono.Text = elCliente.telefono;
            txtcelular.Text = elCliente.celular;
        }

        private void FrmCliente_Load_1(object sender, EventArgs e)
        {
            datos();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        public void datos()
        {
            // cargamos los datos al listbox
            Cliente nuevo = new Cliente();

            // Creamos la lista
            List<Cliente> lista = Cliente.ListarClienteTodos();

            // Limpiar el listBox
            lstClientes.Items.Clear();

            if (lista.Any())
            {
                lista.ForEach(cliente => lstClientes.Items.Add(cliente.nombres.ToString()));
            }
            else
            {
                lstClientes.Items.Add("No hay registros");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //instanciamos de la clase cliente
            Cliente nuevoCliente = new Cliente();
            nuevoCliente.nombres = txtnombres.Text;
            nuevoCliente.apellidos = txtapellidos.Text;
            nuevoCliente.identidad = txtidentidad.Text;
            nuevoCliente.direccion = txtdireccion.Text;
            nuevoCliente.telefono = txttelefono.Text;
            nuevoCliente.celular = txtcelular.Text;

            if (Cliente.ActualizarCliente(nuevoCliente))
            {
                MessageBox.Show("Se ha actualizado el nuevo cliente", "Control de clientes", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("ha ocurrido un  error en la actualización", "Control de clientes", MessageBoxButtons.OK);
            }
            btnAgregar.Enabled = true;
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtidentidad.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcelular.Text = "";
            txtnombres.Focus();
            lstClientes.Refresh();
        }

        private void txtidentidad_Leave(object sender, EventArgs e)
        {
            if (txtidentidad.Text == "")
            {
                btnActualizar.Enabled = false;
                btnAgregar.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Instanciar la clase cliente
            Cliente Eliminado = new Cliente();
            Eliminado.nombres = txtnombres.Text;
            Eliminado.identidad = txtidentidad.Text;

            // Verificamos que el método EliminarCliente funcione
            if (Cliente.EliminarCliente(Eliminado))
            {
                MessageBox.Show("El registro del cliente ha sido eliminado con éxito");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con el procedimiento");
            }
            btnAgregar.Enabled = true;
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtidentidad.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcelular.Text = "";
            txtnombres.Focus();
            lstClientes.Refresh();
        }
    }
}















