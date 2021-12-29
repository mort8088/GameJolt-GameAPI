using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameJolt.Responses
{
    public class DataStoreGetKeysResponse
    {
        [JsonPropertyName("response")]
        public DataStoreGetKeys Response { get; set; }

        public DataStoreGetKeysResponse()
        {
            Response = new DataStoreGetKeys();
        }
    }
    public class DataStoreGetKeys
    {
        /// <summary>
        /// Whether the request succeeded or failed.
        /// Example: true
        /// </summary>
        public string Success { get; set; }
        
        /// <summary>
        /// If the request was not successful, this contains the error message.
        /// Example: No such user could be found.
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// The name of the key. This function will return all the keys for this particular data store.
        /// Example: keyname
        /// </summary>
        public List<string>Keys { get; set; }

        public DataStoreGetKeys()
        {
            Keys = new List<string>();
        }
    }
}