using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Goal
{
    public int GoalId { get; set; }

    public string? Goal1 { get; set; }

    public string? GoalValue { get; set; }

    public virtual ICollection<PerformanceEvaluation> PerformanceEvaluations { get; } = new List<PerformanceEvaluation>();
}
