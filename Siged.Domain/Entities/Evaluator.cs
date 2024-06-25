using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Evaluator
{
    public int EvaluatorId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<PerformanceEvaluation> PerformanceEvaluations { get; } = new List<PerformanceEvaluation>();

    public virtual UserInfo? User { get; set; }
}
