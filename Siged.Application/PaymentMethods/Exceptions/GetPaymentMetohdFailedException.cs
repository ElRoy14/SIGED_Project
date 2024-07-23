namespace Siged.Application.PaymentMethods.Exceptions
{
    public class GetPaymentMetohdFailedException : Exception
    {
        public override string Message { get; }

        public GetPaymentMetohdFailedException(): base()
        {
            Message = "data not found";
        }

    }

}
