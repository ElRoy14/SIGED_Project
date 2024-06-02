namespace Siged.Application.Users.Exceptions
{
    public class UserNotCreatedException : Exception
    {
        public override string Message { get; }

        public UserNotCreatedException() : base()
        {
            Message = "User could not be created";
        }

    }

}
