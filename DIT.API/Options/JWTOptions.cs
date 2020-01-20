namespace DIT.API.Options
{
    public sealed class JWTOptions
    {
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationTime { get; set; }

        public string SecurityAlgorithm { get; set; }

        public void Deconstruct(out string signingKey, out string issuer, out string audience, out int expirationTime, out string securityAlgorithm)
        {
            signingKey = SigningKey;
            issuer = Issuer;
            audience = Audience;
            expirationTime = ExpirationTime;
            securityAlgorithm = SecurityAlgorithm;
        }
    }
}
