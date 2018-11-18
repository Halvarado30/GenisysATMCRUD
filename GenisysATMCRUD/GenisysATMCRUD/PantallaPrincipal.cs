using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenisysATMCRUD
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmCliente Cliente = new FrmCliente();
            Cliente.ShowDialog();
        }

        private void btnServicioPublico_Click(object sender, EventArgs e)
        {
            FrmServicioPublico ServPu = new FrmServicioPublico();
            ServPu.ShowDialog();
        }

        private void btnServicioClient_Click(object sender, EventArgs e)
        {
            FrmServicioCliente scliente = new FrmServicioCliente();
            scliente.ShowDialog();
        }

        private void btnCuentaCliente_Click(object sender, EventArgs e)
        {
            FrmCuentaCliente cuenta = new FrmCuentaCliente();
            cuenta.ShowDialog();
        }

        private void btnTarjetaCredito_Click(object sender, EventArgs e)
        {
            FrmTarjetaCredito tarjeta = new FrmTarjetaCredito();
            tarjeta.ShowDialog();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            /*FrmConfiguracion Config = new FrmConfiguracion();
            Config.ShowDialog();*/
        }
    }
}
