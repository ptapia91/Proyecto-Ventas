using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.MVCWeb.ViewModels
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal precio { get; set; }
        public string Categoria { get; set; }
    }
}
