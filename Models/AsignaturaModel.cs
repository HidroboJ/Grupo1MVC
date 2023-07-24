using Grupo1MVC.Models.CoreEscuela.Entidades;

namespace Grupo1MVC.Models
{
        public class AsignaturaModel : ObjetoEscuelaBaseModel
        {
        public string CursoId { get; set; }
        public CursoModel Curso { get; set; }
        public List<EvaluacionModel> Evalaciones { get; set;}

    }
    
}
