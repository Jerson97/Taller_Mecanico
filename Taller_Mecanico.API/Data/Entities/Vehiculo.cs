using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Data.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de vehículo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public TipoVehiculo TipoVehiculo { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Marca Marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1900, 3000, ErrorMessage = "Valor de módelo no válido.")]
        public int Modelo { get; set; }

        [Display(Name = "Placa")]
        [RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage = "Formato de placa incorrecto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Placa { get; set; }

        [Display(Name = "Línea")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Linea { get; set; }

        [Display(Name = "Color")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Color { get; set; }

        [Display(Name = "Propietario")]
        //[JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Usuario Usuario { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        public ICollection<VehiculoFoto> VehiculoFotos { get; set; }


        [Display(Name = "# Fotos")]
        public int VehiculoFotoCount => VehiculoFotos == null ? 0 : VehiculoFotos.Count;

        [Display(Name = "Foto")]
        public string ImageFullPath => VehiculoFotos == null || VehiculoFotos.Count == 0
            ? $"https://localhost:5001/imagenes/no-image.png"
            : VehiculoFotos.FirstOrDefault().ImageFullPath;

        public ICollection<Historial> Historias { get; set; }

        [Display(Name = "# Historias")]
        public int HistoriasCount => Historias == null ? 0 : Historias.Count;
    }
}

