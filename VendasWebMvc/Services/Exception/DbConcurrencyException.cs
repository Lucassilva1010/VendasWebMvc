﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Services.Exception
{
    public class DbConcurrencyException:ApplicationException
    {
        public DbConcurrencyException(string menssage): base (menssage)
        {

        }
    }
}
