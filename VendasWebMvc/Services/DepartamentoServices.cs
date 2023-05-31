using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class DepartamentoServices
    {
        private readonly VendasWebMvcContext _context;

        public DepartamentoServices(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> EncontraTodosDepartamentos()
        {
            return await _context.Departamentoo.OrderBy(x => x.Nome).ToListAsync();
        }
    }


}
