using System;

namespace VendasWebMvc.Services.Exception
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string menssage) : base(menssage)
        {

        }
    }
}
