namespace FinancialApi.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? IbgeCode { get; set; }
        public bool Deleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? AlteredAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int StateId { get; set; }
    }
}