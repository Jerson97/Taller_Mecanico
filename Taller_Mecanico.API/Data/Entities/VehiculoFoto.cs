using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Data.Entities
{
    public class VehiculoFoto
    {
        public int Id { get; set; }

        //[JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehiculo Vehiculo { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:5001/imagenes/no-image.png"
            : $"https://ramireztaller.blob.core.windows.net/vehiculo/{ImageId}";
    }
}
