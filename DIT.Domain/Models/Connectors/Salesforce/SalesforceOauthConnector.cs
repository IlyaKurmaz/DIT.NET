namespace DIT.Domain.Models
{
    public sealed class SalesforceOauthConnector : Connector
    {
        public string LoginUrl { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        #nullable enable
        public string? IdentityId { get; set; }
    }
}
