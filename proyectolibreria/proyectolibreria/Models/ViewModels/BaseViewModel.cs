using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectolibreria.Models.ViewModels
{
    public class BaseViewModel
    {
        public int articulosCount = 0;
        public int facturasCount = 0;
        public int sucursalesCount = 0;

        public static BaseViewModel BaseContador;

        EurekaDBEntities db = new EurekaDBEntities();

        public static BaseViewModel Iniciar()
        {
            BaseContador = new BaseViewModel();
            BaseContador.Contar();
            return BaseContador;
        }

        public void Contar()
        {
            articulosCount = db.Articulos.Count();
            //facturasCount = db.Facturas.Count();
            sucursalesCount = db.Sucursales.Count();
        }
    }
}