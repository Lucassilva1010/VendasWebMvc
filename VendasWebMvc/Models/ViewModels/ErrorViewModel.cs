using System;

namespace VendasWebMvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string  Menssage { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}