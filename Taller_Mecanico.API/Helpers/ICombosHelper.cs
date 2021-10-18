using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboTipoDocumentos();
        IEnumerable<SelectListItem> GetComboProcedures();
        IEnumerable<SelectListItem> GetComboTipoVehiculo();
        IEnumerable<SelectListItem> GetComboMarcas();
    }
}
