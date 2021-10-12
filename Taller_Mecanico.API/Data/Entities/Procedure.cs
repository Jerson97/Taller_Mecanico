using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Data.Entities
{
    public class Procedure
    {
        public int Id { get; set; }
        [Display(Name = "Procedimiento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public decimal Precio { get; set; }

        public ICollection<Detalle> Detalles { get; set; }
    }
}
