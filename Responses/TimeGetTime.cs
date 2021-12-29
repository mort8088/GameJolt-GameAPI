using System.Text.Json.Serialization;

namespace GameJolt.Responses
{
    public class TimeGetTimeResponse
    {
        [JsonPropertyName("response")]
        public TimeGetTime Response { get; set; }

        public TimeGetTimeResponse()
        {
            Response = new TimeGetTime();
        }
    }
    public class TimeGetTime
    {
        /// <summary>
        /// Whether the request succeeded or failed.
        /// Example: true
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        /// <summary>
        /// If the request was not successful, this contains the error message.
        /// Example: Unknown fatal error occurred.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
        /// <summary>
        /// The UNIX time stamp (in seconds) representing the server's time.
        /// Example: 1394374272
        /// </summary>
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }
        /// <summary>
        /// The timezone of the server.
        /// Example: America/New_York
        /// </summary>
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
        /// <summary>
        /// The current year.
        /// Example: 2015
        /// </summary>
        [JsonPropertyName("year")]
        public int Year { get; set; }
        /// <summary>
        /// The current month.
        /// Example: 4
        /// </summary>
        [JsonPropertyName("month")]
        public int Month { get; set; }
        /// <summary>
        /// The day of the month.
        /// Example: 28
        /// </summary>
        [JsonPropertyName("day")]
        public int Day { get; set; }
        /// <summary>
        /// The hour of the day.
        /// Example: 12
        /// </summary>
        [JsonPropertyName("hour")]
        public int Hour { get; set; }
        /// <summary>
        /// The minute of the hour.
        /// Example: 30
        /// </summary>
        [JsonPropertyName("minute")]
        public int Minute { get; set; }
        /// <summary>
        /// The seconds of the minute.
        /// Example: 59
        /// </summary>
        [JsonPropertyName("second")]
        public int Second { get; set; }

        public TimeGetTime()
        {
            
        }
    }
}