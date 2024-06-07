namespace Siged.Application.Authentication.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public override string Message { get; }

        public UserNotFoundException() : base()
        {
            Message = "No se encontro usuario con estas credenciales";
        }

    }

}
