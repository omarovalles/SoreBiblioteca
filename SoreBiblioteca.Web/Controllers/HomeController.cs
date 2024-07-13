using Microsoft.AspNetCore.Mvc;
using SoreBiblioteca.Web.Models;
using System.Diagnostics;

namespace SoreBiblioteca.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LibrosPage()
        {
            return View("/Views/Libros/LibrosPage.cshtml");
        }

        public IActionResult Index()
        {
            return View("/Views/Home/Index.cshtml");
        }

        public IActionResult PrestamosDisp()
        {
            return View("/Views/Clientes/Index.cshtml");
        }

        public IActionResult ProveedoresPage()
        {
            return View("/Views/Proveedores/ProveedoresPage.cshtml");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
