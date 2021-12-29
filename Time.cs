using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GameJolt.Responses;
using Newtonsoft.Json;

namespace GameJolt
{
    public class Time
    {
        private const string ApiNameSpace = "time";
        
        public async Task<TimeGetTime> GetTime()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append(GameApi.GameApiUrl + "/");
            sb.Append(GameApi.ApiVersion + "/");
            sb.Append(ApiNameSpace + "/");
            sb.Append("?game_id=" + GameApi.GameId);// The ID of your game.
            
            WebResponse r = await GameApi.GetAsync<TimeGetTimeResponse>(new Uri(sb.Append(GameApi.BuildSignature(sb.ToString())).ToString()));
            
            if (r.Response is TimeGetTimeResponse timeResponse)
            {
                return timeResponse.Response;
            }

            return new TimeGetTime();
        }

    }
}