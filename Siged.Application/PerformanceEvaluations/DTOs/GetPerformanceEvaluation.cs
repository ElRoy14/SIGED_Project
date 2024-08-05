using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.PerformanceEvaluations.DTOs
{
    public class GetPerformanceEvaluation
    {
        public int PerformanceEvaluationId { get; set; }
        public int? EvaluatorId { get; set; }
        public string? EvaluatorName { get; set; } //1
        public int? GoalId { get; set; }
        public string? GoalName { get; set; }//2
        public string? GoalValueData { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }//3
        public string? Rating { get; set; }//4

    }

}
