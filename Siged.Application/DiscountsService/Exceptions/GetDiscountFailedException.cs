namespace Siged.Application.DiscountsService.Exceptions
{
    public class GetDiscountFailedException : Exception
    {
        public override string Message { get; }

        public GetDiscountFailedException() : base()
        {
            Message = "data not found";
        }

    }

}
