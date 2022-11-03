namespace DemoApp.SharedLibrary.ExceptionHandling
{
    public class ErrorResponse
    {
        public ErrorResponse(params string[] errors)
        {
            Errors = errors;
        }

        public string[] Errors { get; set; }
    }
}