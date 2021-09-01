using Insurance.Application.Common.Interfaces;
using Insurance.Application.Insurance.Implementations;
using System.Collections.Generic;

namespace Insurance.Application
{
    public class OrderBuilder : IOrderBuilder
    {
        private readonly List<IOrderInsurance> _insuranceCalculateOrders;
        public OrderBuilder()
        {
            _insuranceCalculateOrders = new List<IOrderInsurance>();
        }
        public List<IOrderInsurance> GetBusinessRules()
        {
            return _insuranceCalculateOrders;
        }

        public void ApplyBusinessRules()
        {
            _insuranceCalculateOrders.Add(new HasDigiCam());
        }
    }
}
