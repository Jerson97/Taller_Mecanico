using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Data.Entities
{
    public class Detalle
    {
        public int Id { get; set; }

        //[JsonIgnore]
        [Display(Name = "Historia")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Historial Historial { get; set; }

        [Display(Name = "Procedimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Procedure Procedure { get; set; }

        [Display(Name = "Precio Mano de Obra")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int PrecioLabor { get; set; }

        [Display(Name = "Precio Repuestos")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int PrecioRepuestos { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public int PrecioTotal => PrecioLabor + PrecioRepuestos;

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }
    }
}
