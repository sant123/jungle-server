using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JungleBase.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok($"Welcome to ASP.NET 6.0 \n{DateTime.Now}");
        }
    }
}