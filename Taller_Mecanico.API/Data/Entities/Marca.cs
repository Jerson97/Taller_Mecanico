using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Data.Entities
{
    public class Marca
    {
        public int Id { get; set; }
        [Display(Name = "Tipo de Marca")]
        [MaxLength(50, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Descripcion { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
