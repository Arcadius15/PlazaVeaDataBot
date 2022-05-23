using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlazaVea.Clases
{
    public class Producto
    {
        public string nombreProducto { get; set; }
        public decimal precioReg { get; set; }
        public decimal precioOferta { get; set; }
        public string proveedor { get; set; }
        public string categoria { get; set; }
        public string subcategoria { get; set; }
        public string tipo { get; set; }
        public string subtipo { get; set; }
        public string url { get; set; }
        public string imagenUrl { get; set; }
    }
}
