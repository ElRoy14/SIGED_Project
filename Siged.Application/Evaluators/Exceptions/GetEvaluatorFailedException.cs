namespace Siged.Application.Evaluators.Exceptions
{
    public class GetEvaluatorFailedException : Exception
    {
        public override string Message { get; }

        public GetEvaluatorFailedException(): base()
        {
            Message = "No evaluators found";
        }

    }

}
