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
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            txtValor.Text = "";
            lstconfiguracion.Items.Clear();
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            Datos();
            txtnombre.Focus();
        }

        public void Datos()
        {
            List<Configuracion> listaC = Configuracion.LeerTodos();

            lstconfiguracion.Items.Clear();

            // Verificar que haya un registro
            if (listaC.Any())
            {
                listaC.ForEach(config => lstconfiguracion.Items.Add(config.appKey));
            }
            else
            {
                lstconfiguracion.Items.Add("No hay Datos");
            }
        }
        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        /// <summary>
        /// Encargado de iniciar el proceso de inserción de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text=="" || txtdescripcion.Text =="" || txtValor.Text == "")
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                // Instanciar clase Configuración
                Configuracion config = new Configuracion();
                config.appKey = txtnombre.Text;
                config.descripcion = txtdescripcion.Text;
                config.valor = txtValor.Text;

                if (Configuracion.AgregarConfiguracion(config))
                {
                    MessageBox.Show("Configuración almacenada de manera exitosa");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("ERROR: Error en la inserción");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

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
