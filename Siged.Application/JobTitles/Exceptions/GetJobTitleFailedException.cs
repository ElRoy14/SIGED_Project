namespace Siged.Application.JobTitles.Exceptions
{
    public class GetJobTitleFailedException : Exception
    {
        public override string Message { get; }

        public GetJobTitleFailedException() : base()
        {
            Message = "No jobtitle found";
        }

    }

}
