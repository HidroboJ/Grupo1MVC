using Grupo1MVC.DatosDB;
using Grupo1MVC.Models;
using Grupo1MVC.Models.CoreEscuela.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Grupo1MVC.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()
        { 
            var AlumnoModel = _context.Alumnos.FirstOrDefault();
            return View(AlumnoModel);

        }
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
        [Route("Asignatura/Index/")]
        [Route("Asignatura/Index/{idAlumno}")]
        public IActionResult Index(string idAlumno)
        {
            if (!string.IsNullOrEmpty(idAlumno))
            {
                var AlumnoModel = from asig in _context.Asignaturas
                                      where asig.Id == idAlumno
                                      select asig;
                return View(AlumnoModel.SingleOrDefault());
            }
            else
            {
                var ListaAlumno = _context.Alumnos.ToList();
                return View("MultiAlumno", ListaAlumno);
            }

        }
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(AlumnoModel alumno)

        {
            var escuela = _context.Escuelas.SingleOrDefault();
            alumno.CursoId = escuela.Id;
            _context.Add(alumno);
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

        public IActionResult MultiIndex()
        {
            var ListaAlumno =_context.Alumnos.ToList();
            return View("MultiAlumno",ListaAlumno);
        }
        
    }
    
}

