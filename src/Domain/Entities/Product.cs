namespace Insurance.Domain.Entities
{
    public record Product
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int SalesPrice { get; init; }
        public int ProductTypeId { get; init; }
    }
}
