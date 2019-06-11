using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.MVCWeb.ViewModels
{
    public class ProductoViewModel
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
    }
}
