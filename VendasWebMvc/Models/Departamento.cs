using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();


        

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public void AdicionaVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalVendasVendedor(DateTime dataincial, DateTime dataFinal)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(dataincial, dataFinal));
        }
    }
}
