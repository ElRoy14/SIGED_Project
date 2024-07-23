namespace Siged.Application.ServiceNames.Exceptions
{
    public class GetServiceNameFailedException : Exception
    {
        public override string Message { get; }

        public GetServiceNameFailedException(): base()
        {
            Message = "data no found";
        }

    }

}
