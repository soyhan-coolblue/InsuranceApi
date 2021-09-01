using Insurance.Application.Common.Interfaces;
using Insurance.Domain.Entities;
using System.Collections.Generic;

namespace Insurance.Application.Insurance.Implementations
{
    public class HasDigiCam : IOrderInsurance
    {
        public float CalculateInsurance(List<InsuranceDto> insurances)
        {
            float additionalInsuranceCost = 0; bool hasDigiCam = false;
            if (!hasDigiCam)
            {
                foreach (var item in insurances)
                {
                    if (item.ProductTypeName == "Digital cameras")
                    {
                        hasDigiCam = true;
                        additionalInsuranceCost = 500;
                    }
                }
            }
            return additionalInsuranceCost;
        }
    }
}