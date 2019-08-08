using ApecAxP.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApecAxP.Models
{
    public sealed class Provider
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Name { get; set; }

        [DisplayName("Tipo de persona")]
        [Required(ErrorMessage = "Campo Requerido")]
        public PersonType PersonType { get; set; }

        [DisplayName("Identificación")]
        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "La cedula debe contener 11 digitos")]
        public string Identification { get; set; }

        [DisplayName("Balance")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Currency)]
        public float Balance { get; set; }

        [DisplayName("Estado")]
        public bool State { get; set; }
    }
}
