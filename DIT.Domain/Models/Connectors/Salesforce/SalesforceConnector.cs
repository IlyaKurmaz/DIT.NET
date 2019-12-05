namespace DIT.Domain.Models.Connectors
{
    public sealed class SalesforceConnector : Connector
    {
        public string LoginUrl { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        #nullable enable
        public string? Token { get; set; }

        #nullable enable
        public string? IdentityId { get; set; }
    }
}