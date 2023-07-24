namespace Grupo1MVC.Models
{
    

    namespace CoreEscuela.Entidades
    {
        public class EvaluacionModel : ObjetoEscuelaBaseModel
        {
            public AlumnoModel Alumno { get; set; }
            public string AlumnoId { get; set; }
            public AsignaturaModel Asignatura { get; set; }
            public string AsignaturaId { get; set; }
            public float Nota { get; set; }

            public override string ToString()
            {
                return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
            }
        }
    }

}
