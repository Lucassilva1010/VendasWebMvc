using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index1()
        {
            List<Departamento> lista = new List<Departamento>();

            lista.Add(new Departamento { Id = 1, Nome = "Eletronicos" });
            lista.Add(new Departamento { Id = 2, Nome = "Eletroportateis" });

            return View(lista);
        } 
        
        public IActionResult Dp()
        {
            List<Departamento> lista = new List<Departamento>();

            lista.Add(new Departamento { Id = 1, Nome = "Eletronicos" });
            lista.Add(new Departamento { Id = 2, Nome = "Eletroportateis" });

            return View(lista);
        }
    }
}
