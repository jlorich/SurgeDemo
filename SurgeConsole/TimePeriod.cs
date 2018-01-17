using System;
using System.Collections.Generic;

namespace SurgeConsole
{
    public class TimePeriod {
        public DateTime Start;

        public DateTime End;

        public static List<TimePeriod> GetTimePeriods(SchedulingApiResponse apiResponse) {
            var startDate = DateTime.Parse(apiResponse.StartOfTimePeriod);
            var endDate = DateTime.Parse(apiResponse.EndOfTimePeriod);
            var period = apiResponse.DaysInPeriod;

            var timePeriods = new List<TimePeriod>();

            if (startDate >= endDate) {
              return timePeriods;
            }

            DateTime periodStart = startDate;

            do {
              var potentialPeriodEnd = periodStart.AddDays(period);
              var periodEnd = potentialPeriodEnd > endDate ? endDate : potentialPeriodEnd;

              var timePeriod = new TimePeriod {
                Start = periodStart,
                End = periodEnd
              };

              timePeriods.Add(timePeriod);

              periodStart = periodEnd;
            } while(periodStart < endDate);

            return timePeriods;
        }
    }
}