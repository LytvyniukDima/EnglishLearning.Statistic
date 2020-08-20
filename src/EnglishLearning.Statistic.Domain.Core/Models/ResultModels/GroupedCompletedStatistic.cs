﻿using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;

namespace EnglishLearning.Statistic.Domain.Core.Models.ResultModels
{
    public class GroupedCompletedStatistic
    {
        public GroupedCompletedStatistic(StatisticDate date, IReadOnlyList<CompletedStatistic> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
        
        public StatisticDate Date { get; }
        public IReadOnlyList<CompletedStatistic> CompletedStatistics { get; }

        public override bool Equals(object obj)
        {
            var compared = obj as GroupedCompletedStatistic;
            
            if (compared == null)
            {
                return false;
            }

            if (compared.Date == Date && CompletedStatistics.SequenceEqual(compared.CompletedStatistics))
            {
                return true;   
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode() ^ CompletedStatistics.GetHashCode();
        }
    }
}
