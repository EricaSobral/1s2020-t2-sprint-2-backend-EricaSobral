using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace senai.peoples.WebApi.Controller
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}