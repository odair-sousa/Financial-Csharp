namespace FinancialApi.Models
{
    public class State
    {
        public int Id { get; set; }
        public string UF { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AlteredAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}