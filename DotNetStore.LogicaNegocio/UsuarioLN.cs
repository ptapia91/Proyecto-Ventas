using DotNetStore.AccesoDatos;
using DotNetStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStore.LogicaNegocio
{
    public class UsuarioLN
    {
        UsuarioDA _accesoDatos = new UsuarioDA();

        public IEnumerable<Usuario> SeleccionarTodos()
        {
            return _accesoDatos.SeleccionarTodos();
        }

        public Usuario Validar(string nombreUsuario, string password)
        {
            return _accesoDatos.Validar(nombreUsuario, password);
        }

        public Usuario Seleccionar(string idUsuario)
        {
            return _accesoDatos.Seleccionar(idUsuario);
        }

        public bool Insertar(string nombreUsuario, string password, string idRol)
        {
            return _accesoDatos.Insertar(nombreUsuario, password, idRol);
        }

        public bool Actualizar(Usuario usuario)
        {
            return _accesoDatos.Actualizar(usuario);
        }

        public ClaimsIdentity CrearIdentidad(Usuario usuario)
        {
            return _accesoDatos.CrearIdentidad(usuario);
        }

        public bool Eliminar(string idUsuario)
        {
            return _accesoDatos.Eliminar(idUsuario);
        }

        public IEnumerable<Rol> SeleccionarRoles()
        {
            return _accesoDatos.SeleccionarRoles();
        }
    }
}
