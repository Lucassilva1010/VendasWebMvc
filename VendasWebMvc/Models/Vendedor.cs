using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo Obrigadotrio")]
        [StringLength(70,MinimumLength = 3, ErrorMessage ="O {0} deve contrer no minino {2} letras e no máximo {1}")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Campo Obrigadotrio")]
        public string Email { get; set; }

        [Display(Name ="Data de Nascimento")] // Essa propriedade muda o nome das labels 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo Obrigadotrio")]
        public DateTime DataNascimento { get; set; }
        
        [Display (Name = "Salario Base")]
        [DisplayFormat(DataFormatString ="{0:f2}")]
        [Required(ErrorMessage = "Campo Obrigadotrio")]
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
