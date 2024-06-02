namespace Siged.Application.Salarys.Exceptions
{
    public class GetSalaryFailedException : Exception
    {
        public override string Message { get; }

        public GetSalaryFailedException() : base()
        {
            Message = "No salary found";
        }

    }

}
