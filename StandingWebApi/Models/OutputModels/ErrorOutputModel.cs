namespace StandingBackProject.API.Models.OutputModels
{
    public class ErrorOutputModel
    {
        public int StatusCode { get; set; }
        public string StatusCodeName { get; set; }
        public string Message { get; set; }
    }
}
