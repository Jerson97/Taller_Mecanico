﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Data.Entities
{
    public class Historial
    {
        public int Id { get; set; }

        [Display(Name = "Vehículo")]
        //[JsonIgnore]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehiculo Vehiculo { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime Fecha { get; set; }

        //[Display(Name = "Fecha")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        //public DateTime FechaLocal => FechaLocal.ToLocalTime();

        [Display(Name = "Kilometraje")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Kilometraje { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Obesersacion { get; set; }

        [Display(Name = "Mecánico")]
        //[JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Usuario Usuario { get; set; }

        public ICollection<Detalle> Detalles { get; set; }

        [Display(Name = "# Detalles")]
        public int DetallesCount => Detalles == null ? 0 : Detalles.Count;

        [Display(Name = "Total Mano de Obra")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public int TotalLabor => Detalles == null ? 0 : Detalles.Sum(x => x.PrecioLabor);

        [Display(Name = "Total Repuestos")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public int TotalRepuestos => Detalles == null ? 0 : Detalles.Sum(x => x.PrecioRepuestos);

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public int Total => Detalles == null ? 0 : Detalles.Sum(x => x.PrecioTotal);
    }
}
