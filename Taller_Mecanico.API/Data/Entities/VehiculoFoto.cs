using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Taller_Mecanico.API.Data.Entities
{
    public class VehiculoFoto
    {
        public int Id { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehiculo Vehiculo { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? "/imagenes/no-image.png"
            : $"https://ramirezstaller.blob.core.windows.net/vehiculo/{ImageId}";
    }
}
