namespace Siged.Application.AppliedTaxes.Exceptions
{
    public class GetAppliedTaxFailedException : Exception
    {
        public override string Message { get; }

        public GetAppliedTaxFailedException() : base()
        {
            Message = "data no found";
        }

    }

}
