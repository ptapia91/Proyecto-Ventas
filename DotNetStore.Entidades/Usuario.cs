using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.Entidades
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Rol Rol { get; set; }
    }
}
