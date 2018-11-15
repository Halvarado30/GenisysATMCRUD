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
    class TarjetaCredito
    {
        // Propiedades
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal monto { get; set; }
        public decimal limite { get; set; }
        public int idCliente { get; set; }
    }
}
