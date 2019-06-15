namespace DotNetStore.AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DotNetStore.Entidades;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetStore.AccesoDatos.DotNetStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DotNetStore.AccesoDatos.DotNetStoreContext context)
        {
            context.Categorias.AddOrUpdate(c => c.Nombre,
                 new Categoria { Nombre = "Categoria 4" },
                 new Categoria { Nombre = "Categoria 5" },
                 new Categoria { Nombre = "Categoria 6" });

            context.Productos.AddOrUpdate(p => p.Nombre,
                new Producto { Nombre = "Producto 4", FechaCreacion = DateTime.Now, FechaEdicion = DateTime.Now, Precio = 120.00M, CategoriaID = 4 },
                new Producto { Nombre = "Producto 5", FechaCreacion = DateTime.Now, FechaEdicion = DateTime.Now, Precio = 80.00M, CategoriaID = 5},
                new Producto { Nombre = "Producto 6", FechaCreacion = DateTime.Now, FechaEdicion = DateTime.Now, Precio = 250.00M, CategoriaID = 6 });

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Administrador" },
                new IdentityRole { Name = "Supervisor" },
                new IdentityRole { Name = "Vendedor" });

            if (!context.Users.Any())
            {
                var userStore = new UserStore<IdentityUser>(context);
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = new IdentityUser()
                {
                    UserName = "admin2@dotnetstore.com",
                    Email = "admin2@dotnetstore.com"
                };
                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, "Supervisor");
            }
        }
    }
}
