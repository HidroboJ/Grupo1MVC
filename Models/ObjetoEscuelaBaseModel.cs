using System.ComponentModel.DataAnnotations;

namespace Grupo1MVC.Models
{
    

    
        public abstract class ObjetoEscuelaBaseModel
        {
            public string Id { get; set; }
        
            public virtual string Nombre { get; set; }

            public ObjetoEscuelaBaseModel()
            {
                Id = Guid.NewGuid().ToString();
            }

            public override string ToString()
            {
                return $"{Nombre},{Id}";
            }
        }
    
}
