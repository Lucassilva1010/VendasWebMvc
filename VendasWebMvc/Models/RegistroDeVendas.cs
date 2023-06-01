using System;
using System.ComponentModel.DataAnnotations;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString ="{0:f2}")]
        public double Quantia { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }


        public RegistroDeVendas()
        {

        }

        public RegistroDeVendas(int id, DateTime data, double quantia, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
