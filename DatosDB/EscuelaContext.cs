using Grupo1MVC.Models;
using Grupo1MVC.Models.CoreEscuela.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Grupo1MVC.DatosDB
{
    public class EscuelaContext : DbContext
    {
        public DbSet<EscuelaModel> Escuelas { get; set; }
        public DbSet<AlumnoModel> Alumnos { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<AsignaturaModel> Asignaturas { get; set; }
        public DbSet<EvaluacionesModel> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Sembrando datos de Escuela Model
            var EscuelaModel = new EscuelaModel();
            EscuelaModel.Nombre = "ITQ";
            EscuelaModel.Id = Guid.NewGuid().ToString();
            EscuelaModel.AñoDeCreación = 1984;
            EscuelaModel.Pais = "Ecuador";
            EscuelaModel.Ciudad = "Quito";
            EscuelaModel.Dirección = "Av. Ulloa y Diego de Atienza";
            EscuelaModel.TipoEscuela = TiposEscuelaModel.Secundaria;

            //Cargar Cursos de la escuela
            var cursos = CargarCursos(EscuelaModel);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            modelBuilder.Entity<EscuelaModel>().HasData(EscuelaModel);
            modelBuilder.Entity<CursoModel>().HasData(cursos.ToArray());
            modelBuilder.Entity<AsignaturaModel>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<AlumnoModel>().HasData(alumnos.ToArray());

        }

        private List<AlumnoModel> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new AlumnoModel { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private List<AlumnoModel> CargarAlumnos(List<CursoModel> cursos)
        {
            var listaAlumnos = new List<AlumnoModel>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

        private static List<AsignaturaModel> CargarAsignaturas(List<CursoModel> cursos)
        {
            var listaCompleta = new List<AsignaturaModel>();
            foreach (var curso in cursos)
            {
                var tmpList = new List<AsignaturaModel> {
                            new AsignaturaModel{
                                Id = Guid.NewGuid().ToString(),
                                CursoId = curso.Id,
                                Nombre="Matemáticas"} ,
                            new AsignaturaModel{
                                Id = Guid.NewGuid().ToString(),
                                CursoId = curso.Id,
                                Nombre="Educación Física"},
                            new AsignaturaModel{
                                Id = Guid.NewGuid().ToString(),
                                CursoId = curso.Id,
                                Nombre="Castellano"},
                            new AsignaturaModel{
                                Id = Guid.NewGuid().ToString(),
                                CursoId = curso.Id,
                                Nombre="Ciencias Naturales"},
                            new AsignaturaModel{
                                Id = Guid.NewGuid().ToString(),
                                CursoId = curso.Id,
                                Nombre="Programación"}

                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }

            return listaCompleta;
        }

        private static List<CursoModel> CargarCursos(EscuelaModel escuela)
        {
            return new List<CursoModel>(){
                        new CursoModel() {
                            Id = Guid.NewGuid().ToString(),
                            EscuelaId = escuela.Id,
                            Nombre = "101",
                            Jornada = TiposJornadaModel.Mañana,
                            Dirección= "Quito Sur"},
                        new CursoModel() {Id = Guid.NewGuid().ToString(),
                            EscuelaId  = escuela.Id, Nombre = "201", Jornada = TiposJornadaModel.Mañana, Dirección= "Quito Sur"},
                        new CursoModel   {Id = Guid.NewGuid().ToString(), EscuelaId  = escuela.Id, Nombre = "301", Jornada = TiposJornadaModel.Mañana, Dirección= "Quito Sur"} ,
                        new CursoModel() {Id = Guid.NewGuid().ToString(), EscuelaId  = escuela.Id, Nombre = "401", Jornada = TiposJornadaModel.Tarde , Dirección= "Quito Sur"},
                        new CursoModel() {Id = Guid.NewGuid().ToString(), EscuelaId  = escuela.Id, Nombre = "501", Jornada = TiposJornadaModel.Tarde, Dirección= "Quito Sur"},
            };
        }

        private List<AlumnoModel> GenerarAlumnosAlAzar(
            CursoModel curso,
            int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new AlumnoModel
                               {
                                   CursoId = curso.Id,
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }
    }
}