using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GameJolt.Responses;

namespace GameJolt
{
    public class DataStore
    {
        private const string ApiNameSpace = "data-store";
        
        /// <summary>
        /// Fetches data from the data store.
        /// </summary>
        /// <param name="key">The key of the data item you'd like to fetch.</param>
        /// <param name="passUser">If you pass in the user information the data item will be fetched for a user else it will be fetched globally for the game.</param>
        public async Task<DataStoreFetch> Fetch(string key, bool passUser = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append(GameApi.GameApiUrl + "/");
            sb.Append(GameApi.ApiVersion + "/");
            sb.Append(ApiNameSpace + "/");
            sb.Append("?game_id=" + GameApi.GameId);// The ID of your game.
            sb.Append("&key=" + key);
            
            if (passUser)
            {
                sb.Append("&username=" + GameApi.Username);// The user's username.
                sb.Append("&user_token=" + GameApi.UserToken);// The user's token.
            }
            WebResponse r = await GameApi.GetAsync<DataStoreFetchResponse>(new Uri(sb.Append(GameApi.BuildSignature(sb.ToString())).ToString()));
            
            if (r.Response is DataStoreFetchResponse dataStoreFetchResponse)
            {
                return dataStoreFetchResponse.Response;
            }

            return new DataStoreFetch();
        }

        /// <summary>
        /// Fetches keys of data items from the data store.
        /// </summary>
        /// <param name="pattern">The pattern to apply to the key names in the data store.</param>
        /// <param name="passUser">If you pass in the user information the data item will be fetched for a user else it will be fetched globally for the game.</param>
        public async Task<DataStoreGetKeys> GetKeys(string pattern = "", bool passUser = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append(GameApi.GameApiUrl + "/");
            sb.Append(GameApi.ApiVersion + "/");
            sb.Append(ApiNameSpace + "/");
            sb.Append("get-keys/");
            sb.Append("?game_id=" + GameApi.GameId);// The ID of your game.
            
            if (!string.IsNullOrEmpty(pattern))
                sb.Append("&pattern=" + pattern);// The pattern to apply to the key names in the data store.
            
            if (passUser)
            {
                sb.Append("&username=" + GameApi.Username);// The user's username.
                sb.Append("&user_token=" + GameApi.UserToken);// The user's token.
            }
            WebResponse r = await GameApi.GetAsync<DataStoreGetKeysResponse>(new Uri(sb.Append(GameApi.BuildSignature(sb.ToString())).ToString()));
            
            if (r.Response is DataStoreGetKeysResponse dataStoreGetKeysResponse)
            {
                return dataStoreGetKeysResponse.Response;
            }

            return new DataStoreGetKeys();
        }

        /// <summary>
        /// Removes data items from the data store.
        /// </summary>
        public void Remove()
        {
        }

        /// <summary>
        /// Sets data in the data store.
        /// </summary>
        public void Set()
        {
        }

        /// <summary>
        /// Updates data in the data store with various functions.
        /// </summary>
        public void Update()
        {
        }
    }
}