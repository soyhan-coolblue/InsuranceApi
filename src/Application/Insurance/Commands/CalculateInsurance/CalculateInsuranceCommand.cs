using Insurance.Application.Common.Interfaces;
using Insurance.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Application.Insurance.Commands.CalculateInsurance
{
    public record CalculateInsuranceCommand : IRequest<OrderDto>
    {
        public List<int> ProductIds { get; set; }
    }

    public class CalculateInsuranceCommandHandler : IRequestHandler<CalculateInsuranceCommand, OrderDto>
    {
        private readonly IProductApi _productApi;
        private readonly IProductInsuranceBuilder _productInsuranceBuilder;
        private readonly IOrderBuilder _orderBuilder;

        private List<IProductInsurance> _insuranceCalculates;
        private List<IOrderInsurance> _insuranceCalculateOrders;
        readonly List<Product> products = new();
        List<ProductType> productTypes = new();
        public CalculateInsuranceCommandHandler(IProductApi productApi, IProductInsuranceBuilder productInsuranceBuilder, IOrderBuilder orderBuilder)
        {
            _productApi = productApi;
            _productInsuranceBuilder = productInsuranceBuilder;
            _insuranceCalculates = _productInsuranceBuilder.GetBusinessRules();
            _productInsuranceBuilder.ApplyBusinessRules();
            _orderBuilder = orderBuilder;
            _insuranceCalculateOrders = _orderBuilder.GetBusinessRules();
            _orderBuilder.ApplyBusinessRules();
        }

        public async Task<OrderDto> Handle(CalculateInsuranceCommand request, CancellationToken cancellationToken)
        {
            request.ProductIds.ForEach(async p => products.Add(await _productApi.GetProduct(p)));
            productTypes = await _productApi.GetProductsTypes();

            float insuranceValue = 0;
            var insurances = new List<InsuranceDto>();
            foreach (var product in products)
            {
                var insurance = new InsuranceDto
                {
                    ProductId = product.Id,
                    ProductTypeName = product.Name,
                    SalesPrice = product.SalesPrice
                };
                foreach (var productType in productTypes.Where(productType => product.ProductTypeId == productType.Id))
                {
                    insurance.ProductTypeName = productType.Name;
                    insurance.ProductTypeHasInsurance = productType.CanBeInsured;
                }
                insuranceValue += CalculateInsurance(insurance);
                insurances.Add(insurance);
            }

            insuranceValue += CalculateInsurance(insurances);

            return new OrderDto()
            {
                InsuranceDtos = insurances,
                TotalOrderInsuranceCost = insuranceValue
            };
        }

        private float CalculateInsurance(InsuranceDto insurance)
        {
            float insuranceValue = 0;
            foreach (IProductInsurance insuranceCalculate in _insuranceCalculates)
            {
                insuranceValue += insuranceCalculate.CalculateInsurance(insurance);
            }

            return insuranceValue;
        }
        private float CalculateInsurance(List<InsuranceDto> insurance)
        {
            float insuranceValue = 0;
            foreach (IOrderInsurance insuranceCalculateOrder in _insuranceCalculateOrders)
            {
                insuranceValue += insuranceCalculateOrder.CalculateInsurance(insurance);
            }
            return insuranceValue;
        }
    }
}
