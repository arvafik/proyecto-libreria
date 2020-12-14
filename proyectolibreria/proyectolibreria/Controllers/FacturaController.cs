using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectolibreria.Models;
using proyectolibreria.Models.ViewModels;

namespace proyectolibreria.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
            List<ListFacturaViewModel> lst;

            using (EurekaLibreriaDBEntities db = new EurekaLibreriaDBEntities())
            {
                lst = (from x in db.Facturas
                       select new ListFacturaViewModel
                       {
                           ID = x.ID,
                           Fecha = x.Fecha,
                           Total = x.Total
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(FacturaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EurekaLibreriaDBEntities db = new EurekaLibreriaDBEntities())
                    {
                        var xFactura = new Factura();
                        xFactura.Fecha = DateTime.Now;
                        xFactura.Total = model.Total;

                        db.Facturas.Add(xFactura);
                        db.SaveChanges();
                    }
                    return Redirect("~/Factura/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}