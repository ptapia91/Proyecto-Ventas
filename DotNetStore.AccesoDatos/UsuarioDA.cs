using DotNetStore.Entidades;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.AccesoDatos
{
    public class UsuarioDA : IDisposable
    {
        DotNetStoreContext _context;
        UserStore<IdentityUser> userStore;
        RoleStore<IdentityRole> rolStore;
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> rolManager;

        public UsuarioDA()
        {
            _context = new DotNetStoreContext();
            userStore = new UserStore<IdentityUser>(_context);
            rolStore = new RoleStore<IdentityRole>(_context);

            //AD -> productStore = new ProductoDA();
            //LN -> productoManager = new ProductoManager(productoStore);

            userManager = new UserManager<IdentityUser>(userStore);
            rolManager = new RoleManager<IdentityRole>(rolStore);
        }

        public IEnumerable<Usuario> SeleccionarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            foreach (var user in userManager.Users.ToList())
            {
                var nombreRol = userManager.GetRoles(user.Id).SingleOrDefault();
                var role = nombreRol != null ? rolManager.FindByName(nombreRol) : null;

                usuarios.Add(new Usuario
                {
                    Id = user.Id,
                    Nombre = user.UserName,
                    Email = user.Email,
                    Rol = role != null ? new Rol { Id = role.Id, Nombre = role.Name } : null
                });
            }
            return usuarios;
        }


        /// <summary>
        /// Autentica un usuario
        /// </summary>
        /// <param name="nombreUsuario">email del usuario</param>
        /// <param name="password">clave del usuario</param>
        /// <returns>Usuario validado</returns>
        public Usuario Validar(string nombreUsuario, string password)
        {
            var user = userManager.Find(nombreUsuario, password);
            if (user == null)
                return null;
            var usuario = new Usuario { Id = user.Id, Nombre = user.UserName, Email = user.Email };
            return usuario;
        }

        public Usuario Seleccionar(string idUsuario)
        {
            var user = userManager.FindById(idUsuario);
            var nombreRol = userManager.GetRoles(user.Id).SingleOrDefault();
            var role = nombreRol != null ? rolManager.FindByName(nombreRol) : null;

            var usuario = new Usuario
            {
                Id = user.Id,
                Nombre = user.UserName,
                Email = user.Email,
                Rol = role != null ? new Rol { Id = role.Id, Nombre = role.Name } : null
            };
            return usuario;
        }

        /// <summary>
        /// Crea un usuario en el sistema
        /// </summary>
        /// <param name="userName">Email del usuario</param>
        /// <param name="password">Clave del usuario</param>
        /// <param name="idRol">ID del rol del usuario</param>
        /// <returns>TRUE: para casos exitosos</returns>
        public bool Insertar(string userName, string password, string idRol)
        {
            //Creamos un IdentityUser de Identity.EntityFramework
            var user = new IdentityUser() { UserName = userName, Email = userName };
            //Guardamos el usuario en la BD
            IdentityResult resultUsuario = userManager.Create(user, password);
            //Si el usuario fue creado satisfactoriamente
            if (resultUsuario.Succeeded)
            {
                //Buscamos el objeto Role DE Identity en la BD
                var rol = rolManager.FindById(idRol);
                //Asociamos el rol al usuario creado
                IdentityResult resultRol = userManager.AddToRole(user.Id, rol.Name);
                //En caso haya algun un problema en la asociacion, lanzamos una excepcion
                if (!resultRol.Succeeded)
                {
                    if (resultRol.Errors.Count() > 0)
                        throw new Exception(resultRol.Errors.FirstOrDefault());
                }
            }
            else
            {
                //Si el usuario no fue creado, lanzamos una excepcion
                if (resultUsuario.Errors.Count() > 0)
                    throw new Exception(resultUsuario.Errors.FirstOrDefault());
            }
            //Retornamos TRUE si todo ha ido bien
            return true;
        }

        public bool Actualizar(Usuario usuario)
        {
            IdentityUser user = userManager.FindById(usuario.Id);
            user.Email = usuario.Email;
            user.UserName = usuario.Nombre;
            IdentityResult resultUsuario = userManager.Update(user);
            if (resultUsuario.Succeeded)
            {
                //string rolActual = ObtenerRolPorUsuarioId(usuario.Id);
                string rolActual = userManager.GetRoles(usuario.Id).FirstOrDefault();
                if (rolActual != usuario.Rol.Nombre)
                {
                    var rolesAnteriores = userManager.GetRoles(usuario.Id);
                    foreach (var rolAnterior in rolesAnteriores)
                    {
                        userManager.RemoveFromRole(usuario.Id, rolAnterior);
                    }
                    IdentityResult resultRol = userManager.AddToRole(usuario.Id, usuario.Rol.Nombre);
                    if (!resultRol.Succeeded)
                        throw new Exception(resultRol.Errors.FirstOrDefault());
                }
            }
            else
            {
                if (resultUsuario.Errors.Count() > 0)
                    throw new Exception(resultUsuario.Errors.FirstOrDefault());
            }
            return true;
        }

        public ClaimsIdentity CrearIdentidad(Usuario usuario)
        {
            var user = userManager.FindById(usuario.Id);
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public bool Eliminar(string idUsuario)
        {
            var user = userManager.FindById(idUsuario);
            var result = userManager.Delete(user);
            if (result.Errors.Count() > 0)
                throw new Exception(result.Errors.FirstOrDefault());
            return result.Succeeded;
        }

        public IEnumerable<Rol> SeleccionarRoles()
        {
            var roles = new List<Rol>();
            foreach (var rol in rolManager.Roles)
            {
                roles.Add(new Rol { Id = rol.Id, Nombre = rol.Name });
            }
            return roles;
        }

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }
    }
}
