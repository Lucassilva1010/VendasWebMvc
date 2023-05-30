using System;

namespace VendasWebMvc.Services.Exception
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string menssage):base(menssage)
        {

        }
    }
}
