using Grupo1MVC.DatosDB;
using Grupo1MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grupo1MVC.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()

        {
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
