namespace Grupo1MVC.Models
{
    

    namespace CoreEscuela.Entidades
    {
        public class EvaluacionesModel
        {
            public string Id { get; private set; }
            public string Nombre { get; set; }

            public AlumnoModel Alumno { get; set; }
            public AsignaturaModel Asignatura { get; set; }

            public float Nota { get; set; }

            public EvaluacionesModel() => Id = Guid.NewGuid().ToString();
        }
    }
}
