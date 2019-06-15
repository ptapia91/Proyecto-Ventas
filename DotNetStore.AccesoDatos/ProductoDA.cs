using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetStore.Entidades;
using System.Data.Entity;

namespace DotNetStore.AccesoDatos
{
    public class ProductoDA: IDisposable
    {
        //Establecemos la instancia con el contexto EF
        DotNetStoreContext _context = new DotNetStoreContext();

        public IEnumerable<Categoria> SeleccionarCategorias()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Estado> SeleccionarEstados()
        {
            return _context.Estado.ToList();
        }

        public IEnumerable<Producto> SeleccionarTodosPorFiltro(int categoriaID, DateTime inicioFechaCreacion, DateTime finFechaCreacion)
        {
            return _context.Productos
                .Where(p => categoriaID == 0 || p.CategoriaID == categoriaID)
                .Where(p => p.FechaCreacion >= inicioFechaCreacion && p.FechaCreacion < finFechaCreacion)
                .ToList();
        }

        public IEnumerable<Producto> SeleccionarTodosPorCategoria(int categoriaID)
        {
            return _context.Productos
                .Where(p => categoriaID == 0 || p.CategoriaID == categoriaID)
                .ToList();
        }

        public IEnumerable<Producto> SeleccionarTodos()
        {
            return _context.Productos.ToList();
        }

        public Producto Seleccionar(int productoID)
        {
            //TOP 1
            //select * from productos
            //where productoID = @productoID
            return _context.Productos
                .Where(p => p.ProductoID == productoID)
                .SingleOrDefault();
        }

        public int Insertar(Producto producto)
        {
            _context.Productos.Add(producto);
            int resultado = _context.SaveChanges();
            return resultado;
        }

        public bool Actualizar(Producto producto)
        {
            //var productoOLD  = _context.Productos
            //    .Where(p => p.ProductoID == producto.ProductoID)
            //    .SingleOrDefault();

            //productoOLD.Nombre = producto.Nombre;
            //productoOLD.Precio = producto.Precio;
            //..

            //Adjunto el objeto modificado al contexto EF
            _context.Productos.Attach(producto);
            //Establezco el estado del objeto a MODIFICADO
            _context.Entry(producto).State = EntityState.Modified;
            //inidicamos que no se tome en cuenta la propiedad FechaCreacion para
            //los cambios a realizar
            _context.Entry(producto).Property("FechaCreacion").IsModified = false;
            //Guardamos los cambios
            if (_context.SaveChanges() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return (_context.SaveChanges() != 0);
        }

        public bool Eliminar(int productoID)
        {
            //Traemos el objeto a eliminar hacia el contexto de EF
            var producto = _context.Productos.Where(p => p.ProductoID == productoID).SingleOrDefault();

            //Indicamos que el objeto debe ser eliminado
            _context.Productos.Remove(producto);
            //Guardamos los cambios
            return (_context.SaveChanges() != 0);
        }

        public void Dispose()
        {
            //Si existe un contexto de EF instanciado/abierto/creado
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
