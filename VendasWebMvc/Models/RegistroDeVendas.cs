using System;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
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
