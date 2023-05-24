using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers
{
    public class PessoasController : Controller
    {
        public IActionResult ListaPessoas()
        {

            List<Pessoa> p = new List<Pessoa>();
            p.Add(new Pessoa { Nome = "Lucas"});
            p.Add(new Pessoa { Nome = "Rafael"});
           
            return View(p);
        }
    }
}
