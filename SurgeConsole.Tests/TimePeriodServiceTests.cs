using System;
using Xunit;
using SurgeConsole;
using System.Linq;
using System.Collections.Generic;

namespace SurgeConsole.Tests
{
    public class TimePeriodServiceTests
    {
        [Fact]
        public void TestGetTimePeriods()
        {
            var service = new TimePeriodService();

            var apiResponse = new SchedulingApiResponse()
            {
                StartOfTimePeriod = "2017-03-01",
                EndOfTimePeriod = "2017-04-04",
                DaysInPeriod = 7
            };

            var timePeriods = service.GetTimePeriods(apiResponse);

            Assert.Equal(5, timePeriods.Count);

            var validPeriods = new List<TimePeriod>() {
                new TimePeriod {
                    Start = new DateTime(2017, 3, 1),
                    End =  new DateTime(2017, 3, 8),
                },
                new TimePeriod {
                    Start = new DateTime(2017, 3, 8),
                    End =  new DateTime(2017, 3, 15),
                },
                new TimePeriod {
                    Start = new DateTime(2017, 3, 15),
                    End =  new DateTime(2017, 3, 22),
                },
                new TimePeriod {
                    Start = new DateTime(2017, 3, 22),
                    End =  new DateTime(2017, 3, 29),
                },
                new TimePeriod {
                  Start = new DateTime(2017, 3, 29),
                  End =  new DateTime(2017, 4, 4),
                },
            };

            for (int i = 0; i < timePeriods.Count; i++)
            {
                var validPeriod = validPeriods[i];
                var currentPeriod = timePeriods[i];

                Assert.Equal(validPeriod.Start, currentPeriod.Start);
                Assert.Equal(validPeriod.End, currentPeriod.End);
            }
        }
    }
}
