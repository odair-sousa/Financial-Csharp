namespace FinancialApi.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public string? RG { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AlteredAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}