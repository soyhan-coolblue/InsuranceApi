using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using Insurance.Application.Insurance.Commands.CalculateInsurance;
using Insurance.Application.Common.Exceptions;

namespace Insurance.Application.IntegrationTests.Insurance.Commands
{
    public class CalculateInsuranceTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CalculateInsuranceCommand();

            FluentActions.Invoking(() =>
                Testing.SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCalculateInsurance()
        {

            var command = new CalculateInsuranceCommand
            {
                ProductIds = new List<int>(){ 1 }
            };

            var order = await Testing.SendAsync(command);

            order.Should().NotBeNull();
            order.InsuranceDtos.Should().NotBeNullOrEmpty();
            //item.Title.Should().Be(command.Title);
            //item.CreatedBy.Should().Be(userId);
            //item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            //item.LastModifiedBy.Should().BeNull();
            //item.LastModified.Should().BeNull();
        }
    }
}
