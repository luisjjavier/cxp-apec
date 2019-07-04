using System;

namespace ApecCxP.Models
{
    public class DocumentEntry
    {
        public int Id { get; set; }
        public int BillNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public int Amount { get; set; }
        public DateTime RegisterDate { get; set; }
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
    }
}
