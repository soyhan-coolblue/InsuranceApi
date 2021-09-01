using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Entities
{
    public record ProductType
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public bool CanBeInsured { get; init; }
    }
}
