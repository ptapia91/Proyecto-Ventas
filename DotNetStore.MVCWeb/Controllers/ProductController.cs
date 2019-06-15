using DotNetStore.Entidades;
using DotNetStore.LogicaNegocio;
using DotNetStore.MVCWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetStore.MVCWeb.Controllers
{
    public class ProductController : Controller
    {
        ProductoLN _logicaNegocio = new ProductoLN();

        // GET: Product
        //[OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            try
            {
                //throw new Exception("Excepcion de prueba");

                var products = _logicaNegocio.SeleccionarTodos();
                return View(products);
            }
            catch (Exception ex)
            {
                ViewBag.DescripcionError = ex.Message;
                return View("Error");
            }            
        }

        public ActionResult IndexJsonHolaMundo()
        {
            return Json("Hola Mundo", JsonRequestBehavior.AllowGet);
        }

        public ActionResult IndexAjax()
        {
            return View("IndexJsonProductos");
        }
        public ActionResult IndexJsonProductos()
        {
            var productos = _logicaNegocio.SeleccionarTodos()
                .Select( p => new ProductoViewModel {
                    ProductoID = p.ProductoID,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Categoria = p.Categoria.Nombre
                });

            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = _logicaNegocio.SeleccionarCategorias();
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create2(Producto producto)
        {
            //var producto = new Producto();
            //producto.Nombre = Request.Form["nombreProducto"];
            //producto.Precio = Convert.ToDecimal(Request.Form["Precio"].ToString());
            //producto.CategoriaID = Convert.ToInt32(Request.Form["CategoriaID"].ToString());


            if (ModelState.IsValid)
            {
                if (_logicaNegocio.Insertar(producto) > 0)
                    //Si el producto fue creado, se redirige el flujo a la accion INDEX
                    return RedirectToAction("Index");
                else
                    //Retorno la misma vista pero con el objecto Producto 
                    return View(producto);
            }
            else
                return View(producto);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _logicaNegocio.Seleccionar(id);
            ViewBag.Categorias = _logicaNegocio.SeleccionarCategorias();
            ViewBag.Estado = _logicaNegocio.SeleccionarEstados();
            return View(product);
        }

        [ActionName("Details2")]
        public ActionResult Details(int id)
        {
            var product = _logicaNegocio.Seleccionar(id);
            //ViewBag.Categorias = _logicaNegocio.SeleccionarCategorias();
            return View(product);
        }

        [ActionName("Details")]
        public ActionResult Detailsvm(int id)
        {            
            var product = _logicaNegocio.Seleccionar(id);
            var model = new ProductCategoryViewModel {
                ID = product.ProductoID,
                Nombre = product.Nombre,
                precio = product.Precio,
                Categoria = product.Categoria.Nombre
            };
            //return View(product);
            return View("Detailsvm",model);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (_logicaNegocio.Actualizar(producto))
                {
                    //Si el producto fue actualizado, se redirige el flujo a la accion INDEX
                    return RedirectToAction("Index");
                }
                //Sino, retorno la misma vista pero con el objecto Producto 
                return View(producto);
            }
            else
                return View(producto);

        }

        //GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (_logicaNegocio.Eliminar(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}