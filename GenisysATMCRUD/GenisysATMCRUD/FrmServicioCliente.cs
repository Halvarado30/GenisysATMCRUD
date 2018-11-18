using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// namespace necesarios
using GenisysATM.Models;

namespace GenisysATMCRUD
{
    public partial class FrmServicioCliente : Form
    {
        public FrmServicioCliente()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Limpiar()
        {
            txtsaldo.Text = "";
            lstClientes.SelectedIndex = -1;
            lstServiciosP.SelectedIndex = -1;
            lstServiciosC.Items.Clear();
            Datos();
            Datos2();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtsaldo.Text == "" || lstClientes.SelectedIndex == -1 || lstServiciosP.SelectedIndex == -1)
            {
                MessageBox.Show("Hay datos vacios o no seleccionados");
            }
            else
            {
                // Se instancia una variable de tipo ClienteServicio
                ServicioCliente nuevoSC = new ServicioCliente();
                nuevoSC.saldo = Convert.ToDecimal(txtsaldo.Text);
                if (ServicioCliente.AgregarClienteServicio(lstClientes.SelectedItem.ToString(), lstServiciosP.SelectedItem.ToString(), nuevoSC))
                {
                    MessageBox.Show("Registro almacenado con éxito");

                }
            }
        }

        public void Datos()
        {
            // Se obtiene la lista de todos los clientes en la base
            List<Cliente> listacliente = Cliente.LeerTodos();

            lstClientes.Items.Clear();

            // Verificar si existen datos
            if (listacliente.Any())
            {
                listacliente.ForEach(Cliente => lstClientes.Items.Add(Cliente.nombres));
            }
            else
            {
                lstClientes.Items.Add("No hay datos");
            }
        }

        public void Datos2()
        {
            // Se obtiene la lista de todos los clientes en la base
            List<ServicioPublico> listaservicioP = ServicioPublico.Leer(); 

            lstServiciosP.Items.Clear();

            // Verificar si existen datos
            if (listaservicioP.Any())
            {
                listaservicioP.ForEach(servicio => lstServiciosP.Items.Add(servicio.descripcion));
            }
            else
            {
                lstClientes.Items.Add("No hay datos");
            }
        }

        public void Datos3()
        {
            List<ServicioCliente> existente = ServicioCliente.LeerServiciosCliente(lstClientes.SelectedItem.ToString());
            lstServiciosC.Items.Clear();

            if (existente.Any())
            {
                existente.ForEach(client => lstServiciosC.Items.Add(client.detalle));
            }
            else
            {
                lstServiciosC.Items.Add("No hay servicios para el cliente");
            }
        }

        private void lstClientes_Click(object sender, EventArgs e)
        {
            Datos3();
        }

        private void FrmServicioCliente_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void lstServiciosC_Click(object sender, EventArgs e)
        {
            ServicioCliente existente = ServicioCliente.LeerDato(lstServiciosC.SelectedItem.ToString(), lstClientes.SelectedItem.ToString());

            if (existente.saldo != 0)
            {
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                txtsaldo.Text = Convert.ToString(existente.saldo);
            }
            else
            {
                txtsaldo.Text = "Error";
            }
        }
    }
}
