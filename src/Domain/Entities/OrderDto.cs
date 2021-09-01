using System.Collections.Generic;

namespace Insurance.Domain.Entities
{
    public record OrderDto
    {
        public List<InsuranceDto> InsuranceDtos { get; set; }

        public float TotalOrderInsuranceCost { get; set; }
    }
}
