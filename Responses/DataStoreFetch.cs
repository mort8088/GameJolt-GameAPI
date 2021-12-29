using System.Text.Json.Serialization;

namespace GameJolt.Responses
{
    public class DataStoreFetchResponse
    {
        [JsonPropertyName("response")]
        public DataStoreFetch Response { get; set; }

        public DataStoreFetchResponse()
        {
            Response = new DataStoreFetch();
        }
    }
    public class DataStoreFetch
    {
        /// <summary>
        /// Whether the request succeeded or failed.
        /// Example: true
        /// </summary>
        [JsonPropertyName("success")]
        public bool	Success { get; set; }
        
        /// <summary>
        /// If the request was not successful, this contains the error message.
        /// Example: Unknown fatal error occurred.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        /// <summary>
        /// If the request was successful, this contains the item's data.
        /// Example: Some example data.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}