using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Data
{
    public class SeedingService
    {
        private VendasWebMvcContext _context;

        public SeedingService( VendasWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamentoo.Any() ||
                _context.Vendedor.Any() ||
                _context.RegistroDeVendas.Any())
            {
                return;// Isso testa se o banco de dados está povoado, se tiver ele já para a aplicação
            }
            Departamento d1 = new Departamento(1,"Informática");
            Departamento d2 = new Departamento(2,"Vesturario");
            Departamento d3 = new Departamento(3,"Brinquedos");
            Departamento d4 = new Departamento(4,"Agro");

            Vendedor v1 = new Vendedor(1,"Lucas","lucas@.com", new DateTime(1989,09,27),22000.00,d1);
            Vendedor v2 = new Vendedor(2,"Anastacia","anastaci@.com", new DateTime(2000,03,11),2185.00,d2);
            Vendedor v3 = new Vendedor(3,"Antonella","antonella@.com", new DateTime(2019,10,28),1500.00,d3);
            Vendedor v4 = new Vendedor(4,"Clotildes","clotildes@.com", new DateTime(1990,8,10),2100.56,d2);
            Vendedor v5 = new Vendedor(5,"Idelmar","idelmar@.com", new DateTime(1980,02,19),2230.33,d1);
            Vendedor v6 = new Vendedor(6,"Marcos","marcos@.com", new DateTime(1990,06,15),1300.16,d4);

            RegistroDeVendas r1 = new RegistroDeVendas(1,new DateTime(2023,01,03),10000.00,StatusVenda.Faturado,v1);
            RegistroDeVendas r2 = new RegistroDeVendas(2,new DateTime(2023,01,15),1000.00,StatusVenda.Faturado,v2);
            RegistroDeVendas r3 = new RegistroDeVendas(3,new DateTime(2023,02,06),5600.00,StatusVenda.Pendente,v3);
            RegistroDeVendas r4 = new RegistroDeVendas(4,new DateTime(2023,02,25),565.00,StatusVenda.Faturado,v4);
            RegistroDeVendas r5 = new RegistroDeVendas(5,new DateTime(2023,03,01),3200.00,StatusVenda.Faturado,v4);
            RegistroDeVendas r6 = new RegistroDeVendas(6,new DateTime(2023,03,30),1650.00,StatusVenda.Pendente,v3);
            RegistroDeVendas r7 = new RegistroDeVendas(7,new DateTime(2023,04,12),2500.00,StatusVenda.cancelado,v2);
            RegistroDeVendas r8 = new RegistroDeVendas(8,new DateTime(2023,04,15),8640.00,StatusVenda.Faturado,v2);
            RegistroDeVendas r9 = new RegistroDeVendas(9,new DateTime(2023,05,16),700.00,StatusVenda.Pendente,v3);
            RegistroDeVendas r10 = new RegistroDeVendas(10,new DateTime(2023,05,18),941.00,StatusVenda.Faturado,v1);
            RegistroDeVendas r11 = new RegistroDeVendas(11,new DateTime(2023,05,26),120.00,StatusVenda.Faturado,v4);
            RegistroDeVendas r12 = new RegistroDeVendas(12,new DateTime(2023,05,27),333.00,StatusVenda.cancelado,v3);

            //Adicionando no Banco para ser povoado

            _context.Departamentoo.AddRange(d1,d2,d3,d4);
            _context.Vendedor.AddRange(v1,v2,v3,v4,v5,v6);
            _context.RegistroDeVendas.AddRange(r1,r2,r3,r4,r5,r6,r7,r8,r9,r10,r11,r12);

            _context.SaveChanges();
        }
    }
}
