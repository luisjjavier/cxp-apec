using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApecAxP.Models
{
    public sealed class DocumentEntry
    {
        public int Id { get; set; }

        [DisplayName("Numero de Factura")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El numero de factura debe ser mayor que 1")]
        public int BillNumber { get; set; }

        [DisplayName("Fecha de Documento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime DocumentDate { get; set; }

        [DisplayName("Monto")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Campo Requerido")]
        public int Amount { get; set; }

        [DisplayName("Fecha de Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime RegisterDate { get; set; }

        [DisplayName("Provedor")]
        public Provider Provider { get; set; }

        [DisplayName("Provedor")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int ProviderId { get; set; }
    }
}
