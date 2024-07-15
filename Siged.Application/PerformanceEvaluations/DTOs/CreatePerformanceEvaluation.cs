using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.PerformanceEvaluations.DTOs
{
    public class CreatePerformanceEvaluation
    {
        public int? EvaluatorId { get; set; }
        public int? GoalId { get; set; }
        public int? UserId { get; set; }
        public string? Rating { get; set; }
    }
}
