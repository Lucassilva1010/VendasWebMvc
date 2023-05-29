using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();


        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionaVenda(RegistroDeVendas registroDeVendas)
        {
            Vendas.Add(registroDeVendas);
        }

        public void RemoverVenda(RegistroDeVendas registroDeVendas)
        {
            Vendas.Remove(registroDeVendas);
        }
        public double TotalVendas(DateTime dataInicia, DateTime dataFinal)
        {
            return Vendas.Where(v => v.Data >= dataInicia && v.Data <= dataFinal).Sum(v=> v.Quantia);
        }
    }
}
