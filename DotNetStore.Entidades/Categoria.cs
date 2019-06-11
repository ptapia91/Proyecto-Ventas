using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.Entidades
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
