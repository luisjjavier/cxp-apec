using ApecAxP.Enums;

namespace ApecAxP.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonType PersonType { get; set; }
        public string Identification { get; set; }
        public float Balance { get; set; }
        public bool State { get; set; }
    }
}
