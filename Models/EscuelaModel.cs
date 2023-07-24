using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using Grupo1MVC.Models.CoreEscuela.Entidades;

namespace Grupo1MVC.Models
{

    public class EscuelaModel : ObjetoEscuelaBaseModel
    {
        public int AñoDeCreación { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public string Dirección { get; set; }

        public TiposEscuelaModel TipoEscuela { get; set; }
        public List<CursoModel> Cursos { get; set; }

        public EscuelaModel(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);

        public EscuelaModel(string nombre, int año,
                       TiposEscuelaModel tipo,
                       string pais = "", string ciudad = "") : base()
        {
            (Nombre, AñoDeCreación) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public EscuelaModel()
        {

        }
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
    }
}


