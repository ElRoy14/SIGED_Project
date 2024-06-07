namespace Siged.Application.Users.Exceptions
{
    public class DeleteUserFailedException : Exception
    {
        public override string Message { get; }

        public DeleteUserFailedException() : base()
        {
            Message = "Failed to delete user";
        }

    }

}
