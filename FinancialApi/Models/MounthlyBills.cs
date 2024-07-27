namespace FinancialApi
{
    public class MonthlyBills
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Entries { get; set; }
        public decimal? Exits { get; set; }
        public DateTime DueDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateOnly? AlteredAt { get; set; }
        public DateOnly? DeletedAt { get; set; }
    }
}