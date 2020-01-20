using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIT.Domain.Models.AuthModel
{
    public class JwtTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; } = "";

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; } = "";

        [JsonProperty("expires_in")]
        public DateTime Expiration { get; set; } = DateTime.Now;

        [JsonProperty("token_type")]
        public string TokenType { get; set; } = "Bearer";
    }
}