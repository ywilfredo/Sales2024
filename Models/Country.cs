using System.ComponentModel.DataAnnotations;

namespace Sales.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] //datanotatons
        public string Name { get; set; } = null!; //para matar null, quiere decir que no le de importancia a null

        //public List<State>? States { get; set; }

        //[Display(Name = "Departamentos")]
        //public int StatesNumber => States == null ? 0 : States.Count;

       // [Display(Name = "Ciudades")]
        //public int CitiesNumber => States == null ? 0 : States.Sum(s => s.CitiesNumber);
    }
}
