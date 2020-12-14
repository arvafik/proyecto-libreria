using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectolibreria.Models;
using proyectolibreria.Models.ViewModels;

namespace proyectolibreria.Controllers
{
    public class SucursaleController : Controller
    {
        // GET: Sucursales editar ahoritaxd
        public ActionResult Index()
        {
            //Read
            List<ListSucursaleViewModel> lst;

            using (EurekaDBEntities db = new EurekaDBEntities())
            {
                lst = (from x in db.Sucursales
                       select new ListSucursaleViewModel
                       {
                           ID = x.ID,
                           Nombre = x.Nombre,
                           Direccion = x.Direccion
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(SucursaleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EurekaDBEntities db = new EurekaDBEntities())
                    {
                        var xSucursale = new Sucursale();
                        xSucursale.Nombre = model.Nombre;
                        xSucursale.Direccion = model.Direccion;

                        db.Sucursales.Add(xSucursale);
                        db.SaveChanges();
                    }
                    return Redirect("~/Sucursale/");
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
            SucursaleViewModel model = new SucursaleViewModel();
            using (EurekaDBEntities db = new EurekaDBEntities())
            {
                var xSucursale = db.Sucursales.Find(Id);
                model.Nombre = xSucursale.Nombre;
                model.Direccion = xSucursale.Direccion;
  
                model.ID = xSucursale.ID;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(SucursaleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EurekaDBEntities db = new EurekaDBEntities())
                    {
                        var xSucursale = db.Sucursales.Find(model.ID);
                        xSucursale.Nombre = model.Nombre;
                        xSucursale.Direccion = model.Direccion;

                        db.Entry(xSucursale).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Sucursale/");
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

                var xSucursale = db.Sucursales.Find(Id);
                db.Sucursales.Remove(xSucursale);
                db.SaveChanges();
            }
            return Redirect("~/Sucursale/");
        }


    }
}