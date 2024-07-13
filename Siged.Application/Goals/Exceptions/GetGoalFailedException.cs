namespace Siged.Application.Goals.Exceptions
{
    public class GetGoalFailedException : Exception
    {
        public override string Message { get; }

        public GetGoalFailedException() : base()
        {
            Message = "No gols found";
        }

    }

}
