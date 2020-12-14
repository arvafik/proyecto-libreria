using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectolibreria.Models.ViewModels
{
    public class ListFacturaViewModel
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

    }
}