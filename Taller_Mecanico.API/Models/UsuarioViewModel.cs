using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data.Entities;
using Taller_Mecanico.Common.Enumeracion;

namespace Taller_Mecanico.API.Models
{
    public class UsuarioViewModel 
    {
        public string Id { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes introducir un email valido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Apellidos { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo{0} es obligatorio")]
        public string Documento { get; set; }

        [Display(Name = "Dirreccion")]
        [MaxLength(100, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(20, ErrorMessage = "El campo {0} no peude tener más de {1} carácteres.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Foto")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Tipo de documento")]
        [Range(1, int.MaxValue, ErrorMessage ="Debes seleccionar un tipo de documento.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public int TipoDocumentoId { get; set; }

        public IEnumerable<SelectListItem> TipoDocumentos { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty // Si el guid no tiene nada entonces me mostrara como imagen que no tiene imagen
            ? $"https://localhost:5001/imagenes/no-image.png"
            : $"https://ramireztaller.blob.core.windows.net/usuario/{ImageId}";

    }
}
