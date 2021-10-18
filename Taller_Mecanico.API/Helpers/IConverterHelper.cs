using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data.Entities;
using Taller_Mecanico.API.Models;

namespace Taller_Mecanico.API.Helpers
{
    public interface IConverterHelper
    {
        Task<Usuario> toUsuarioAsync(UsuarioViewModel model, Guid imageId, bool isNew);

        UsuarioViewModel toUsuarioViewModel(Usuario usuario);
    }
}
