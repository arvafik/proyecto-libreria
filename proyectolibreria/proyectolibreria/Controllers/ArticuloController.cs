using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectolibreria.Models;
using proyectolibreria.Models.ViewModels;

namespace proyectolibreria.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            //Read
            List<ListArticuloViewModel> lst;

            using (EurekaDBEntities db = new EurekaDBEntities())
            {
                lst = (from x in db.Articulos
                       select new ListArticuloViewModel
                       {
                           Id = x.ID,
                           Nombre = x.Nombre,
                           Descripcion = x.Descripcion,
                           Categoria = x.Categoria,
                           Autor = x.Autor,
                           TotalInventario = x.TotalInventario,
                           Editorial = x.Editorial,
                           Precio = x.Precio
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ArticuloViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EurekaDBEntities db = new EurekaDBEntities())
                    {
                        var oArticulo = new Articulo();
                        oArticulo.Nombre = model.Nombre;
                        oArticulo.Descripcion = model.Descripcion;
                        oArticulo.Categoria = model.Categoria;
                        oArticulo.Autor = model.Autor;
                        oArticulo.TotalInventario = model.TotalInventario;
                        oArticulo.Editorial = model.Editorial;
                        oArticulo.Precio = model.Precio;

                        db.Articulos.Add(oArticulo);
                        db.SaveChanges();
                    }
                    return Redirect("~/Articulo/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            ArticuloViewModel model = new ArticuloViewModel();
            using (EurekaDBEntities db = new EurekaDBEntities())
            {
                var xArticulo = db.Articulos.Find(Id);
                model.Nombre = xArticulo.Nombre;
                model.Descripcion = xArticulo.Descripcion;
                model.Categoria = xArticulo.Categoria;
                model.Autor = xArticulo.Autor;
                model.TotalInventario = xArticulo.TotalInventario;
                model.Editorial = xArticulo.Editorial;
                model.Precio = xArticulo.Precio;
                model.Id = xArticulo.ID;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ArticuloViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EurekaDBEntities db = new EurekaDBEntities())
                    {
                        var oArticulo = db.Articulos.Find(model.Id);
                        oArticulo.Nombre = model.Nombre;
                        oArticulo.Descripcion = model.Descripcion;
                        oArticulo.Categoria = model.Categoria;
                        oArticulo.Autor = model.Autor;
                        oArticulo.TotalInventario = model.TotalInventario;
                        oArticulo.Editorial = model.Editorial;
                        oArticulo.Precio = model.Precio;

                        db.Entry(oArticulo).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Articulo/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (EurekaDBEntities db = new EurekaDBEntities())
            {

                var xArticulo = db.Articulos.Find(Id);
                db.Articulos.Remove(xArticulo);
                db.SaveChanges();
            }
            return Redirect("~/Articulo/");
        }



    }

}