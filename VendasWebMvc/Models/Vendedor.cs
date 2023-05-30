using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Data de Nascimento")] // Essa propriedade muda o nome das labels 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        [Display (Name = "Salario Base")]
        [DisplayFormat(DataFormatString ="{0:f2}")]
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
