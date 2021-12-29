using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GameJolt
{
    public static class GameApi
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use.
        private static readonly HttpClient Client = new HttpClient();
        public static string GameId { get; set; }
        public static string GameKey { get; set; }
        public static string Username { get; set; }
        public static string UserToken { get; set; }
        public const string GameApiUrl = "https://api.gamejolt.com/api/game";
        public const string ApiVersion = "v1_2";
        
        static GameApi()
        {
            
        }
        
        /// <summary>
        /// returns the &signature to be appended to the url being sent to the API
        /// </summary>
        /// <param name="input">the URL string to be called</param>
        /// <returns></returns>
        internal static string BuildSignature(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hashSh1 = sha1.ComputeHash(Encoding.UTF8.GetBytes(input+GameKey));
  
                // declare StringBuilder
                StringBuilder sb = new StringBuilder(hashSh1.Length * 2);
  
                // computing hashSh1
                foreach (byte b in hashSh1)
                {
                    sb.Append(b.ToString("X2").ToLower());
                }

                return $"&signature={sb}";
            }
        }

        /// <summary>
        /// Gets from an uri asynchronously.
        /// </summary>
        /// <typeparam name="T">The expected return object.</typeparam>
        /// <param name="uri">The request URI.</param>
        /// <returns>The response of the HTTP GET.</returns>
        public static async Task<WebResponse> GetAsync<T>(Uri uri)
        {
            using HttpResponseMessage response = await Client.GetAsync(uri);
            string responseString = await response.Content.ReadAsStringAsync();

            ValidateResponseCode(response.StatusCode, responseString);

            return WebResponse.Make(DeserializeObject<T>(responseString), response.StatusCode);
        }
        
        /// <summary>
        /// Posts to an uri asynchronously.
        /// </summary>
        /// <typeparam name="T">The expected return object.</typeparam>
        /// <param name="uri">The request URI.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>The response of the HTTP POST.</returns>
        public static async Task<WebResponse> PostAsync<T>(Uri uri, object body)
        {
            using StringContent content = new(SerializeObject(body), Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await Client.PostAsync(uri, content);
            string responseString = await response.Content.ReadAsStringAsync();

            ValidateResponseCode(response.StatusCode, responseString);

            return WebResponse.Make(DeserializeObject<T>(responseString), response.StatusCode);
        }

        /// <summary>
        /// Validates a <see cref="HttpStatusCode"/> and throws errors based on the code.
        /// </summary>
        /// <param name="statusCode">The status code to validate.</param>
        /// <param name="response">The response of the http request.</param>
        private static void ValidateResponseCode(HttpStatusCode statusCode, string response)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new Exception($"Bad Request ({response})");
                case HttpStatusCode.Unauthorized:
                    throw new Exception($"Unauthorized Access ({response})");
                case HttpStatusCode.Forbidden:
                    throw new Exception($"Forbidden ({response})");
                case HttpStatusCode.NotFound:
                    throw new Exception($"Not Found ({response})");
                case HttpStatusCode.InternalServerError:
                    throw new Exception($"Internal Server Error ({response})");
                case HttpStatusCode.BadGateway:
                    throw new Exception($"Bad Gateway ({response})");
                case HttpStatusCode.ServiceUnavailable:
                    throw new Exception($"Service Unavailable ({response})");
            }

            // This status code is not in the HttpStatusCode Enum
            if ((int)statusCode == 429)
            {
                throw new Exception($"Too Many Requests ({response})");
            }
        }
        
        /// <summary>
        /// Custom deserialization with StringEnumConverter.
        /// </summary>
        /// <typeparam name="T">The type of the expected object.</typeparam>
        /// <param name="json">The json to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        private static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new StringEnumConverter());
        }

        /// <summary>
        /// Custom serialization with StringEnumConverter.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The serialized JSON.</returns>
        private static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, new StringEnumConverter());
        }
        
        /*
         * DataStore - Fetch, 
         * Time
         * Scores
         * Sessions
         * Trophies
         * Users
         * Friends
         * Batch
         */
    }
}