using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class DateTimeFactory
    {
        private static Random _random = new Random();
        
        public static IReadOnlyList<DateTime> GetRandomDateTimes(int count, int maxDiffernceFromNow = 31)
        {
            var now = DateTime.Now;
            var dates = new List<DateTime>();
            
            for (var i = 0; i < count; i++)
            {
                var newDate = now.Subtract(TimeSpan.FromDays(_random.Next(maxDiffernceFromNow))).Date;
                if (dates.Contains(newDate))
                {
                    i--;
                }
                else
                {
                    dates.Add(newDate);
                }
            }

            return dates;
        }

        public static DateTime GetRandomDateTime(int maxDiffernceFromNow = 31)
        {
            var now = DateTime.Now;

            return now.Subtract(TimeSpan.FromDays(_random.Next(maxDiffernceFromNow)));
        }
    }
}