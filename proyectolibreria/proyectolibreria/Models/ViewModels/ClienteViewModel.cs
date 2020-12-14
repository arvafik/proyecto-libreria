using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace proyectolibreria.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
    }
}