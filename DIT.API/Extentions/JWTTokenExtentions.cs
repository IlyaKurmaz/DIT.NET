using DIT.Domain.Models.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIT.API.Extentions
{
    public static class JWTTokenExtentions
    {
        public static bool IsEmptyToken(this JwtTokenResponse tokenResponse) => string.IsNullOrEmpty(tokenResponse.AccessToken);
    }
}
