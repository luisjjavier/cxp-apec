using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApecAxP.Models
{
    public sealed class PaymentConcept
    {
        public int Id { get; set; }

        [DisplayName("Descripción")]
        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "La descripción no puede tener mas de 100 caracteres")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Description { get; set; }

        [DisplayName("Estado")]
        public bool State { get; set; }
    }
}
