namespace FinancialApi.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AlteredAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}