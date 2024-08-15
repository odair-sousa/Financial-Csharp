namespace FinancialApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string NeighborHood { get; set; }
        public string Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ZipCode { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? AlteredAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CityId { get; set; }
        public int? PeopleId { get; set; }
    }
}