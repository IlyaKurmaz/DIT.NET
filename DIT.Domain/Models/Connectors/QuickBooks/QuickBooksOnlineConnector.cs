namespace DIT.Domain.Models.Connectors.QuickBooks
{
    public sealed class QuickBooksOnlineConnector: Connector
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string RealmId { get; set; }

        public bool IsSandbox { get; set; }

        public string ApplicationId { get; set; }

        public string ApplicationSecret { get; set; }
    }
}
