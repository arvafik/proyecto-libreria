﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace proyectolibreria.Models.ViewModels
{
    public class FacturaViewModel
    {
        //de la tabla Facturas
        public int ID { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal Total { get; set; }


    }
}