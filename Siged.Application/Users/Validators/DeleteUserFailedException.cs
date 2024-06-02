namespace Siged.Application.Users.Validators
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
