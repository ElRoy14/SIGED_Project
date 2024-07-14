using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.PerformanceEvaluations.Exceptions
{
    public class GetPerformanceFailedException : Exception
    {
        public override string Message { get; }

        public GetPerformanceFailedException(): base()
        {
            Message = "No data found";
        }

    }
}
