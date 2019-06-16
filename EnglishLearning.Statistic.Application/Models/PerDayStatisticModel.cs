using System;

namespace EnglishLearning.Statistic.Application.Models
{
    public class PerDayStatisticModel
    {
        public DateModel Date { get; set; }
        public int CompletedTasksCount { get; set; }
        public int CompletedTextCount { get; set; }
        public int CompletedVideoCount { get; set; }
    }
}
