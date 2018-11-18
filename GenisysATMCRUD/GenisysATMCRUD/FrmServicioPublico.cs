using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Se agregan los namespace necesarios
using GenisysATM.Models;

namespace GenisysATMCRUD
{
    public partial class FrmServicioPublico : Form
    {
        public FrmServicioPublico()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Se procede a verificar que el campo no esté vacio
            if (txtdescripcion.Text == "")
            {
                MessageBox.Show("El campo de descripción no debe de estar vacio");
            }
            else
            {
                // Se procede a instanciar la Clase de ServicioPublico
                ServicioPublico nServP = new ServicioPublico();
                nServP.descripcion = txtdescripcion.Text;

                // Se verifica si se han insertado los datos
                if (ServicioPublico.InsertaServP(nServP))
                {
                    MessageBox.Show("Se ha ingresado el dato correctamente");
                    txtdescripcion.Text = "";
                    txtdescripcion.Focus();
                }
                else
                {
                    MessageBox.Show("Hay un problema en la inserción del dato");
                }
            }
        }
        
        private void datos()
        {
            // Se obtiene la lista de todos los Servicios publicos en la tabla
            List<ServicioPublico> ListaServicios = ServicioPublico.Leer();

            // Limpiar el listbox
            lstServicioPub.Items.Clear();

            // Verificar si existe algún ServicioPublico
            if (ListaServicios.Any())
            {
                ListaServicios.ForEach(servicio => lstServicioPub.Items.Add(servicio.descripcion));
            }
            else
            {
                lstServicioPub.Items.Add("No hay datos");
            }
        }

        private void FrmServicioPublico_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            txtdescripcion.Text = "";
            datos();
        }
    }
}
