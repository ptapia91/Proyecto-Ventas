using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetStore.Entidades;
using DotNetStore.LogicaNegocio;
using DotNetStore.WebAPI.Models;
using System.Web.Http.Description;

namespace DotNetStore.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        ProductoLN _logicaNegocio = new ProductoLN();

        //GET: api/products
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var products = _logicaNegocio.SeleccionarTodos()
                .Select(p => new Product {
                    ProductID = p.ProductoID,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    CategoriaID = p.CategoriaID,
                    CategoriaNombre = p.Categoria.Nombre
                });
            return products;
        }

        //GET: api/products/5
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            var producto = _logicaNegocio.Seleccionar(id);
            if (producto == null)
            {
                return NotFound();
            }
            var product = new Product {
                ProductID = producto.ProductoID,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                CategoriaID = producto.CategoriaID,
                CategoriaNombre = producto.Categoria.Nombre
            };
            return Ok(product);
        }

        //POST: api/products
        [HttpPost]
        public IHttpActionResult PostProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var producto = new Producto {
                Nombre = product.Nombre,
                Precio = product.Precio,
                CategoriaID = product.CategoriaID
            };

            if (_logicaNegocio.Insertar(producto) > 0)
            {
                return Ok();//200
            }
            else
            {
                return InternalServerError();//500
            }
        }

        //PUT: api/products
        [HttpPut]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (product == null || id != product.ProductID)
            {
                return BadRequest();
            }
            var producto = new Producto
            {
                ProductoID = product.ProductID,
                Nombre = product.Nombre,
                Precio = product.Precio,
                CategoriaID = product.CategoriaID
            };

            if (_logicaNegocio.Actualizar(producto))
            {
                return Ok();//200
            }
            else
            {
                return InternalServerError();//500
            }
        }

        //DELETE api/products/5
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            if (_logicaNegocio.Seleccionar(id) == null)
                return NotFound();

            if (_logicaNegocio.Eliminar(id))
                return Ok();
            else
                return InternalServerError();
        }
    }
}
