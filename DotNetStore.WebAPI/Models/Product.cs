using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.WebAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaID { get; set; }
        public string CategoriaNombre { get; set; }

    }
}
