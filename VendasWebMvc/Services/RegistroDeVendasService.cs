using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class RegistroDeVendasService
    {
        private readonly VendasWebMvcContext _context;

        public RegistroDeVendasService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task< List<RegistroDeVendas>> EncontrarPorData(DateTime? dataMin, DateTime? dataMax)
        {
            var result = from obj in _context.RegistroDeVendas select obj;
            if (dataMin.HasValue)// se foi informado uma data minima
            {
                result = result.Where(x => x.Data >= dataMin.Value);
            }

            if (dataMax.HasValue)//se foi informado a data maxima
            {
                result = result.Where(x=> x.Data <= dataMax.Value);
            }

            return await result
                .Include(x=> x.Vendedor)
                .Include(x=> x.Vendedor.Departamento)
                .OrderByDescending(x=> x.Data)
                .ToListAsync();
        }
        public async Task<List<IGrouping< Departamento,RegistroDeVendas>>> EncontrarPorGrupo(DateTime? dataMin, DateTime? dataMax)
        {
            var result = from obj in _context.RegistroDeVendas select obj;
            if (dataMin.HasValue)// se foi informado uma data minima
            {
                result = result.Where(x => x.Data >= dataMin.Value);
            }

            if (dataMax.HasValue)//se foi informado a data maxima
            {
                result = result.Where(x => x.Data <= dataMax.Value);
            }

            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x=> x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}
