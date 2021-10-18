using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller_Mecanico.API.Data;

namespace Taller_Mecanico.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboMarcas()
        {
            List<SelectListItem> lista = _context.Marcas.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            lista.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una marca...]",
                Value = "0"
            });

            return lista;
        }

        public IEnumerable<SelectListItem> GetComboProcedures()
        {
            List<SelectListItem> lista = _context.Procedures.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            lista.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una procedimiento...]",
                Value = "0"
            });

            return lista;
        }

        public IEnumerable<SelectListItem> GetComboTipoDocumentos()
        {
            List<SelectListItem> lista = _context.TipoDocumentos.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            lista.Insert(0, new SelectListItem
            {
                Text = "Seleccione una tipo de documento...",
                Value = "0"
            });

            return lista;
        }

        public IEnumerable<SelectListItem> GetComboTipoVehiculo()
        {
            List<SelectListItem> lista = _context.TipoVehiculos.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            lista.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una tipo de vehiculo...]",
                Value = "0"
            });

            return lista;
        }
    }
}
