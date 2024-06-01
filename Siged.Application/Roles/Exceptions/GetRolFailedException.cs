namespace Siged.Application.Roles.Exceptions
{
    public class GetRolFailedException : Exception
    {
        public override string Message { get; }

        public GetRolFailedException() : base()
        {
            Message = "No role found";
        }

    }
}
