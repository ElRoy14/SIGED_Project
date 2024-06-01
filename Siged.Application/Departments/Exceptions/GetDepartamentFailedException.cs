namespace Siged.Application.Departments.Exceptions
{
    public class GetDepartamentFailedException : Exception
    {
        public override string Message { get; }

        public GetDepartamentFailedException() : base() 
        {
            Message = "No Departments found;";
        }

    }

}
