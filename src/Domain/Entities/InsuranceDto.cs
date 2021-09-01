using System.Text.Json.Serialization;

namespace Insurance.Domain.Entities
{
    public record InsuranceDto
    {

        public int ProductId { get; set; }
        public float InsuranceValue { get; set; }
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingDefault)]
        public string ProductTypeName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ProductTypeHasInsurance { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public float SalesPrice { get; set; }
    }
}
