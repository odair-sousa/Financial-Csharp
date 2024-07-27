namespace FinancialApi.Models
{
    public class BalancePeriods
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Blocked { get; set; }
        public bool Consolidated { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AlteredAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}