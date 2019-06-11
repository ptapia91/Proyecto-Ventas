namespace DotNetStore.AccesoDatos.Migrations
{
    using Entidades;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetStore.AccesoDatos.DotNetStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DotNetStore.AccesoDatos.DotNetStoreContext context)
        {
            try
            {
                context.Categorias.AddOrUpdate(c => c.Nombre,
                      new Categoria { Nombre = "Categoria 1" },
                      new Categoria { Nombre = "Categoria 2" },
                      new Categoria { Nombre = "Categoria 3" });

                context.Productos.AddOrUpdate(p => p.Nombre,
                    new Producto { Nombre = "Producto 1", FechaCreacion = DateTime.Now, FechaEdicion = DateTime.Now, Precio = 120.05M, CategoriaID = 1 },
                    new Producto { Nombre = "Producto 2", FechaCreacion = DateTime.Now, FechaEdicion = DateTime.Now, Precio = 80.05M, CategoriaID = 2 },
                    new Producto { Nombre = "Producto 3", FechaCreacion = DateTime.Now, FechaEdicion = DateTime.Now, Precio = 250.05M, CategoriaID = 3 });

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
                    UserName = "admin@dotnetstore.com",
                    Email = "admin@dotnetstore.com"
                };
                userManager.Create(user, "1234567");
                userManager.AddToRole(user.Id, "Administrador");
            }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var sb = new System.Text.StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new Exception(sb.ToString());
            }
        }
      }
    }

