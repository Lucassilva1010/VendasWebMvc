using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Data;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Services.Exception;

namespace VendasWebMvc.Services
{
    public class VendedorServices
    {
        private readonly VendasWebMvcContext _context;

        public VendedorServices( VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> EncontrarTudo()
        {
            return await _context.Vendedor.ToListAsync();// Isso é uma operação Sincrona,
                                            // pois ela vai no banco e espera o
                                              // branco gerar para poder retornar 
        }
        public async Task Inserir(Vendedor vendedor)
        {
            
            //Inserindo um novo vendedor no banco
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }
        public async Task<Vendedor> EncontraPorId(int id)
        {
            return await _context.Vendedor.Include(obj=> obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoverPorId(int id)
        {
            try
            {

            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
             await _context.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {

                throw new IntegrityException(e.Message);
            }
        }
        public async Task EditarPorId(Vendedor vendedor)
        {
            bool temVendedor = await _context.Vendedor.AnyAsync(x => x.Id == vendedor.Id);
            if (!temVendedor)
            {
                throw new DllNotFoundException("Não esixte esse ID");
            }
            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
          
            
        }

       

    }
}
