using System.ComponentModel;

namespace ApecCxP.Models
{
    public class Account
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
