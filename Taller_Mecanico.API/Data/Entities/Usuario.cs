using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taller_Mecanico.Common.Enumeracion;

namespace Taller_Mecanico.API.Data.Entities
{
    public class Usuario : IdentityUser
    {
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Apellidos { get; set; }

        [Display(Name = "Tipo de Documento")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public TipoDocumento TipoDocumento { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Documento { get; set; }

        [Display(Name = "Dirreccion")]
        [MaxLength(100, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Direccion { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
        ? "/imagenes/no-image.png"
        : $"https://ramirezstaller.blob.core.windows.net/usuario/{ImageId}";

        [Display(Name = "Tipo de Usuario")]
        public TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Usuario")]
        public string NombreCompleto => $"{Nombres} {Apellidos}";

        public ICollection<Vehiculo> Vehiculos { get; set; }

        [Display(Name = "# Vehiculos")]
        public int VehiculosCount => Vehiculos == null ? 0 : Vehiculos.Count;

    }
}
