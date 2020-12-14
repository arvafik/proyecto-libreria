using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectolibreria.Models.ViewModels
{
    //No es realmente un viewmodel, esto sigue siendo mvc solo que no supe que otro nombre ponerle
    public class BaseViewModel
    {
        public int articulosCount = 0;
        public int facturasCount = 0;
        public int sucursalesCount = 0;

        public static BaseViewModel BaseContador;

        EurekaLibreriaDBEntities db = new EurekaLibreriaDBEntities();

        public void Contar()
        {
            articulosCount = db.Articulos.Count();
            facturasCount = db.Facturas.Count();
            sucursalesCount = db.Sucursales.Count();
        }        
        
        public static BaseViewModel Iniciar()
        {
            BaseContador = new BaseViewModel();
            BaseContador.Contar();
            return BaseContador;
        }

    }
}