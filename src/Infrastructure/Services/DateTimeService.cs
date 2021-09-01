using Insurance.Application.Common.Interfaces;
using System;

namespace Insurance.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
