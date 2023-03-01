using System.Net;

namespace NZWalksAPI.Models
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}
