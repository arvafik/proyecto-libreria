using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectolibreria.Models.ViewModels
{
    public class ListArticuloViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Autor { get; set; }
        public int TotalInventario { get; set; }
        public string Editorial { get; set; }
        public decimal Precio { get; set; }
    }
}