namespace Siged.Application.PaymenInvoiceStatus.Exceptions
{
    public class GetPaymentInvoiceStatusFailedException : Exception
    {
        public override string Message { get; }

        public GetPaymentInvoiceStatusFailedException(): base()
        {
            Message = "data not found";
        }

    }

}
