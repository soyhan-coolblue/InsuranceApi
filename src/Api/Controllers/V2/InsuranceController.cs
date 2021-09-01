using Insurance.Application.Insurance.Commands.CalculateInsurance;
using Insurance.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.Api.Controllers
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/insurance")]
    public class InsuranceController : ApiControllerBase
    {
        [HttpPost]
        [Route("Calculate")]
        public async Task<ActionResult<OrderDto>> Calculate(CalculateInsuranceCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
