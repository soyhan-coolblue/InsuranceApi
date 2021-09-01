using System.Collections.Generic;
using Insurance.Application.Common.Interfaces;
using Insurance.Application.Insurance.Implementations;

namespace Insurance.Application
{
    public class ProductInsuranceBuilder: IProductInsuranceBuilder
    {
        private readonly List<IProductInsurance> _insuranceCalculates;
        public ProductInsuranceBuilder()
        {
            _insuranceCalculates = new List<IProductInsurance>();
        }
        public List<IProductInsurance> GetBusinessRules()
        {
            return _insuranceCalculates;
        }
        public void ApplyBusinessRules()
        {
            _insuranceCalculates.Add(new ProductLessThan500());
            _insuranceCalculates.Add(new ProductBetween500To2000());
            _insuranceCalculates.Add(new ProductLaptopAndSmartphones());
            _insuranceCalculates.Add(new ProductLessThan500());
            _insuranceCalculates.Add(new ProductMoreThan2000());
        }
    }
}