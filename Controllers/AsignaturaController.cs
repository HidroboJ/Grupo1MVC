using Grupo1MVC.DatosDB;
using Grupo1MVC.Models;
using Grupo1MVC.Models.CoreEscuela.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Grupo1MVC.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()
        {
            var AsignaturaModel = _context.Asignaturas.FirstOrDefault();
            return View(AsignaturaModel);
        }

        [Route("Asignatura/Index/")]
        [Route("Asignatura/Index/{idAsignatura}")]
        public IActionResult Index(string idAsignatura)
        {
            if (!string.IsNullOrEmpty(idAsignatura))
            {
                var AsignaturaModel = from asig in _context.Asignaturas
                                      where asig.Id == idAsignatura
                                      select asig;
                return View(AsignaturaModel.SingleOrDefault());
            }
            else
            {
                var ListaAsignatura = _context.Asignaturas.ToList();
                return View("MultiAsignatura", ListaAsignatura);
            }
            
        }
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(AsignaturaModel asignatura)

        {
            var escuela = _context.Escuelas.SingleOrDefault();
            asignatura.CursoId = escuela.Id ;
            _context.Add(asignatura);
            _context.SaveChanges();
            return View();
           /* if (ModelState.IsValid)
            {
                

            }
            else
            {
                return View();

            }*/


        }
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult MultiIndex()
        {
            var ListaAsignatura = _context.Asignaturas.ToList();
            return View("MultiAsignatura",ListaAsignatura);
        }
    }
}
