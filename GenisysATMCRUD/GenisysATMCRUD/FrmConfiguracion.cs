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
                    MessageBox.Show("ERROR: Ha ocurrido un problema en la inserción");
                }
            }
        }

        /// <summary>
        /// Se encarga de almacenar los cambios que se hagan dentro de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (lstconfiguracion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Dato de configuración");
            }
            else
            {
                // Se instancia la Clase Configuracion
                Configuracion actConf = new Configuracion();
                actConf.appKey = lstconfiguracion.SelectedItem.ToString();
                actConf.NewappKey = txtnombre.Text;
                actConf.valor = txtValor.Text;
                actConf.descripcion = txtdescripcion.Text;

                if (Configuracion.ActualizarConfiguracion(actConf))
                {
                    MessageBox.Show("Cambios realizados éxitosamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("ERROR: Ha ocurrido un problema en la actualización");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstconfiguracion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Dato de configuración");
            }
            else
            {
                // Se instancia la clase Configuracion
                Configuracion deleteConf = new Configuracion();
                deleteConf.appKey = lstconfiguracion.SelectedItem.ToString();

                if (Configuracion.EliminarConfiguracion(deleteConf))
                {
                    MessageBox.Show("Registro eliminado con éxito");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("ERROR: Ha ocurrido un problema en la eliminación");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstconfiguracion_Click(object sender, EventArgs e)
        {
            Configuracion exist = Configuracion.ObtenerConfiguracion2(lstconfiguracion.SelectedItem.ToString());
            if (exist.id != 0)
            {
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                txtnombre.Text = exist.appKey;
                txtdescripcion.Text = exist.descripcion;
                txtValor.Text = exist.valor;
            }

        }
    }
}
