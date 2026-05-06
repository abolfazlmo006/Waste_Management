namespace Waste_Management.WebApi.Services.Base
{
    public class Response
    {
        public List<string>? Errors { get; set; }
        public string Message { get; set; }
        public bool SuccessFul { get; set; }
    }
}
