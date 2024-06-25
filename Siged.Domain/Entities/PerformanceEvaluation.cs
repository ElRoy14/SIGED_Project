using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class PerformanceEvaluation
{
    public int PerformanceEvaluationId { get; set; }

    public int? EvaluatorId { get; set; }

    public int? GoalId { get; set; }

    public int? UserId { get; set; }

    public string? Rating { get; set; }

    public virtual Evaluator? Evaluator { get; set; }

    public virtual Goal? Goal { get; set; }

    public virtual UserInfo? User { get; set; }
}
