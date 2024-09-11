using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp04
{
    internal class Producto
    {
        public int idproducto { get; set; }
        public string nombreProducto { get; set; }
        public decimal precioUnidad { get; set; }

        public string cantidadPorUnidad { get; set; }
        public string categoriaProducto { get; set; }
    }
}
