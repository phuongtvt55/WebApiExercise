using Newtonsoft.Json;
using System.Net;


namespace DataAccess.DTO
{
    public class Response<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }
}
