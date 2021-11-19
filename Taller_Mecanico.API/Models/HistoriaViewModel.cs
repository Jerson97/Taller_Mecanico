﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Models
{
    public class HistoriaViewModel
    {
        public int VehiculoId { get; set; }
        [Display(Name = "Kilometraje")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Kilometraje { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Obesersacion { get; set; }
    }
}
