﻿using System;
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

        public List<Vendedor> EncontrarTudo()
        {
            return _context.Vendedor.ToList();// Isso é uma operação Sincrona,
                                            // pois ela vai no banco e espera o
                                              // branco gerar para poder retornar 
        }
        public void Inserir(Vendedor vendedor)
        {
            
            //Inserindo um novo vendedor no banco
            _context.Add(vendedor);
            _context.SaveChanges();
        }
        public Vendedor EncontraPorId(int id)
        {
            return _context.Vendedor.Include(obj=> obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void RemoverPorId(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
        public void EditarPorId(Vendedor vendedor)
        {
            if (!_context.Vendedor.Any(x=> x.Id == vendedor.Id))
            {
                throw new DllNotFoundException("Não esixte esse ID");
            }
            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
          
            
        }

       

    }
}
