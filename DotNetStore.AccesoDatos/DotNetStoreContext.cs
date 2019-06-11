using DotNetStore.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.AccesoDatos
{
    public class DotNetStoreContext : IdentityDbContext
    {
        public DotNetStoreContext() : base("MiDBConexion")
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
