using Grupo1MVC.Models.CoreEscuela.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Grupo1MVC.Models
{
   

    
        public class CursoModel : ObjetoEscuelaBaseModel
        {
        [Required]
            public override string Nombre { get; set; }
            public TiposJornadaModel Jornada { get; set; }
            public List<AsignaturaModel> Asignaturas { get; set; }
            public List<AlumnoModel> Alumnos { get; set; }

            public string Dirección { get; set; }

            public string EscuelaId { get; set; }
            public EscuelaModel Escuela { get; set; }


            
        }
    
}
