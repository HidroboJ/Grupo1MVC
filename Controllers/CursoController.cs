using Grupo1MVC.DatosDB;
using Grupo1MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grupo1MVC.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()
        {
            var CursoModel = _context.Cursos.FirstOrDefault();
            return View(CursoModel);
        }
        
        public IActionResult Create()
        {
            
           return View();

        }
        [HttpPost]
        public IActionResult Create(CursoModel curso)
        {
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.SingleOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Add(curso);
                _context.SaveChanges();
                return View();

            }
            else
            {
                return View();

            }
            

        }

        [Route("Curso/Index/")]
        [Route("Curso/Index/{idCurso}")]
        public IActionResult Index(string idCurso)
        {
            if (!string.IsNullOrEmpty(idCurso))
            {
                var CursoModel = from cur in _context.Cursos
                                      where cur.Id == idCurso
                                      select cur;
                return View(CursoModel.SingleOrDefault());
            }
            else
            {
                var ListaCursos = _context.Cursos.ToList();
                return View("MultiCurso", ListaCursos);
            }


        }
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult MultiIndex()
        {
            var ListaCursos = _context.Asignaturas.ToList();
            return View("MultiCurso", ListaCursos);
        }
    }
}
