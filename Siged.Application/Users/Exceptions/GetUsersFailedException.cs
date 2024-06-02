namespace Siged.Application.Users.Exceptions
{
    public class GetUsersFailedException : Exception
    {
        public override string Message { get; }

        public GetUsersFailedException() : base()
        {
            Message = "No data found";
        }

    }

}
