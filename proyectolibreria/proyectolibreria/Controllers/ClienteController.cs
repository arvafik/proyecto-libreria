using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectolibreria.Models;
using proyectolibreria.Models.ViewModels;

namespace proyectolibreria.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            //Read
            List<ListClienteViewModel> lst;
            using (LibreriaDBEntities db = new LibreriaDBEntities())
            {
                lst = (from x in db.Clientes
                       select new ListClienteViewModel
                       {
                           Id = x.ID,
                           Nombre = x.Nombre,
                           Direccion = x.Direccion,
                           Telefono = x.Telefono

                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (LibreriaDBEntities db = new LibreriaDBEntities())
                    {
                        var xCliente = new Cliente();
                        xCliente.Nombre = model.Nombre;
                        xCliente.Direccion = model.Direccion;
                        xCliente.Telefono = model.Telefono;
                        
                        db.Clientes.Add(xCliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
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
            ClienteViewModel model = new ClienteViewModel();
            using (LibreriaDBEntities db = new LibreriaDBEntities())
            {
                var xCliente = db.Clientes.Find(Id);

                model.Nombre = xCliente.Nombre;
                model.Direccion = xCliente.Direccion;
                model.Telefono = xCliente.Telefono;
                model.Id = xCliente.ID;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (LibreriaDBEntities db = new LibreriaDBEntities())
                    {
                        var xCliente = db.Clientes.Find(model.Id);
                        xCliente.Nombre = model.Nombre;
                        xCliente.Direccion = model.Direccion;
                        xCliente.Telefono = model.Telefono;

                        db.Entry(xCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
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
            using (LibreriaDBEntities db = new LibreriaDBEntities())
            {

                var xCliente = db.Clientes.Find(Id);
                db.Clientes.Remove(xCliente);
                db.SaveChanges();
            }
            return Redirect("~/Cliente/");
        }
    }
}