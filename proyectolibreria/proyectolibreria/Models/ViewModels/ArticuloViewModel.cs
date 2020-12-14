using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace proyectolibreria.Models.ViewModels
{
    //No es realmente un viewmodel, esto sigue siendo mvc solo que no supe que otro nombre ponerle
    public class ArticuloViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        [Required]
        [Display(Name = "Autor")]
        public string Autor { get; set; }
        [Required]
        [Display(Name = "TotalInventario")]
        public int TotalInventario { get; set; }
        [Required]
        [Display(Name = "Editorial")]
        public string Editorial { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
    }

}