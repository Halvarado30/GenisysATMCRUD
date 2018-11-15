using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Agregar los namespaces necesarios
using System.Data;
using System.Data.SqlClient;

namespace GenisysATM.Models
{
    class ATM
    {
        // Obtener las configuraciones de uso del ATM
        Configuracion configuracion = new Configuracion();

        private string limiteDolares = Configuracion.ObtenerConfiguracion("MONTOMAXIMODOLARES");
        private string limiteLempiras = Configuracion.ObtenerConfiguracion("MONTOMAXIMOLEMPIRAS");
        private string tasaCambio = Configuracion.ObtenerConfiguracion("TASACAMBIODOLARES");
        private string limitePin = Configuracion.ObtenerConfiguracion("INTENTOSPIN");

        // Variables miembro
        private string numeroTarjeta;
        private string pin;

        protected Cliente elCliente = new Cliente();
        protected CuentaCliente laCuenta = new CuentaCliente();
        protected ServicioCliente losServicios = new ServicioCliente();
        protected TarjetaCredito laTarjeta = new TarjetaCredito();

        // Constructores
        public ATM() { }

        public ATM(string laTarjeta="", string elPin="")
        {
            numeroTarjeta = laTarjeta;
            pin = elPin;
        }

        // Métodos
        public bool VerificarInicio(string laCuenta, string elPin)
        {
            this.laCuenta = CuentaCliente.ObtenerCliente(laCuenta);

            if (this.laCuenta.numero == laCuenta && this.laCuenta.pin == elPin)
                return true;
            else
                return false;
        }
    }
}
