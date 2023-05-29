using System.Collections.Generic;

namespace VendasWebMvc.Models.ViewModels
{
    public class VendedorFormVielModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
