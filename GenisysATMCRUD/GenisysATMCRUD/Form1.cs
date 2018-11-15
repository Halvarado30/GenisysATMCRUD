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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
