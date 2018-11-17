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
        }

        // En el caso de querer rellenar los campos mediante 
        // la inserción de la identidad
        private void txtidentidad_Leave(object sender, EventArgs e)
        {
            Cliente elCliente = new Cliente();
            elCliente = Cliente.ObtenerCliente(txtidentidad.Text);

            txtnombres.Text = elCliente.nombres;
            txtapellidos.Text = elCliente.apellidos;
            btnActualizar.Enabled = true;
            btnAgregar.Enabled = false;
        }

        private void lstCliente_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = true;
            btnAgregar.Enabled = false;
            Cliente elCliente = new Cliente();
            elCliente = Cliente.ObtenerCliente2(lstClientes.SelectedItem.ToString());

            txtnombres.Text = elCliente.nombres;
            txtapellidos.Text = elCliente.apellidos;
        }

        private void FrmCliente_Load_1(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = true;
            // cargamos los datos al listbox
            Cliente nuevo = new Cliente();

            // Creamos la lista
            List<Cliente> lista = Cliente.ListarClienteTodos();
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
        }
    }
}















