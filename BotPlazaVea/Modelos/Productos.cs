using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlazaVea.Modelos
{
    public class Productos
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string nombreProducto { get; set; }
        [Required]
        public decimal precioReg { get; set; }
        [Required]
        public decimal precioOferta { get; set; }
        [Required]
        public string proveedor { get; set; }
        [Required]
        public string categoria { get; set; }
        [Required]
        public string subcategoria { get; set; }
        [Required]
        public string tipo { get; set; }
        [Required]
        public string subtipo { get; set; }
        [Required]
        public string imagenUrl { get; set; }


        public int idUrl { get; set; }
        public Urls Url { get; set; }
    }
}
