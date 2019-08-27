using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class GroupedCompletedStatistic
    {
        public StatisticDate Date { get; }
        public IReadOnlyList<CompletedStatistic> CompletedStatistics { get; }

        public GroupedCompletedStatistic(StatisticDate date, IReadOnlyList<CompletedStatistic> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
        
        public override bool Equals(object obj)
        {
            var compared = obj as GroupedCompletedStatistic;
            
            if (compared == null)
                return false;

            if (compared.Date == Date && CompletedStatistics.SequenceEqual(compared.CompletedStatistics))
            {
                return true;   
            }

            return false;
        }
    }
}
