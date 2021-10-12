using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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

        //Todo: Fix the image path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty // Si el guid no tiene nada entonces me mostrara como imagen que no tiene imagen
            ? $"https://localhost:5001/.azurewebsites.net/images/noimage.png"
            : $"https://vehiclessalazar.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Tipo de Usuario")]
        public TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Usuario")]
        public string NombreCompleto => $"{Nombres} {Apellidos}";

        public ICollection<Vehiculo> Vehiculos { get; set; }

    }
}
