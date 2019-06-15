using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetStore.AccesoDatos;
using DotNetStore.Entidades;

namespace DotNetStore.LogicaNegocio
{
    public class ProductoLN
    {

        ProductoDA _accesoDatos = new ProductoDA();

        public IEnumerable<Categoria> SeleccionarCategorias()
        {
            return _accesoDatos.SeleccionarCategorias();
        }

        public IEnumerable<Estado> SeleccionarEstados()
        {
            return _accesoDatos.SeleccionarEstados();
        }

        public IEnumerable<Producto> SeleccionarTodos()
        {
            return _accesoDatos.SeleccionarTodos();
        }

        public IEnumerable<Producto> SeleccionarTodosPorCategoria(int categoriaID)
        {
            return _accesoDatos.SeleccionarTodosPorCategoria(categoriaID);
        }

        public IEnumerable<Producto> SeleccionarTodosPorFiltro(int categoriaID, DateTime inicioFechaCreacion, DateTime finFechaCreacion)
        {
            return _accesoDatos.SeleccionarTodosPorFiltro(categoriaID, inicioFechaCreacion, finFechaCreacion);
        }

        public Producto Seleccionar(int productoID)
        {
            return _accesoDatos.Seleccionar(productoID);
        }

        public int Insertar(Producto producto)
        {
            producto.FechaCreacion = DateTime.Now;
            producto.FechaEdicion = DateTime.Now;
            return _accesoDatos.Insertar(producto);
        }

        public bool Actualizar(Producto producto)
        {
            producto.FechaEdicion = DateTime.Now;
            return _accesoDatos.Actualizar(producto);
        }

        public bool Eliminar(int productoID)
        {
            return _accesoDatos.Eliminar(productoID);
        }
    }
}
