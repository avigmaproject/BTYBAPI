using System.Text;

namespace BTYBApi.Repository.Project
{
    // Helper class for OAuth1.0a authentication header
    class OAuth1Header
    {
        private readonly string apiKey;
        private readonly string apiSecretKey;
        private readonly string accessToken;
        private readonly string accessTokenSecret;
        private readonly string oauthVersion;

        public OAuth1Header(string apiKey, string apiSecretKey, string accessToken, string accessTokenSecret, string oauthVersion = "1.0")
        {
            this.apiKey = apiKey;
            this.apiSecretKey = apiSecretKey;
            this.accessToken = accessToken;
            this.accessTokenSecret = accessTokenSecret;
            this.oauthVersion = oauthVersion;
        }

        public string GetAuthorizationHeader()
        {
            var nonce = Guid.NewGuid().ToString("N");
            var timestamp = ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();

            var signatureParameters = new Dictionary<string, string>
        {
            { "oauth_consumer_key", apiKey },
            { "oauth_nonce", nonce },
            { "oauth_signature_method", "HMAC-SHA1" },
            { "oauth_timestamp", timestamp },
            { "oauth_token", accessToken },
            { "oauth_version", oauthVersion }
        };

            var baseString = string.Join("&",
                signatureParameters
                    .OrderBy(kvp => kvp.Key)
                    .Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

            var signatureBaseString = $"GET&{Uri.EscapeDataString("https://api.twitter.com/1.1/trends/place.json")}&{Uri.EscapeDataString(baseString)}";

            var signingKey = $"{Uri.EscapeDataString(apiSecretKey)}&{Uri.EscapeDataString(accessTokenSecret)}";
            var sha1 = new System.Security.Cryptography.HMACSHA1(Encoding.UTF8.GetBytes(signingKey));
            var signatureBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(signatureBaseString));
            var signature = Convert.ToBase64String(signatureBytes);

            var authorizationHeaderParams = new Dictionary<string, string>(signatureParameters)
        {
            { "oauth_signature", Uri.EscapeDataString(signature) }
        };

            var authorizationHeader = "OAuth " + string.Join(", ",
                authorizationHeaderParams
                    .OrderBy(kvp => kvp.Key)
                    .Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}=\"{Uri.EscapeDataString(kvp.Value)}\""));

            return authorizationHeader;
        }
    }

    // Model classes to deserialize the JSON response
    class Trend
    {
        public List<TrendItem> Trends { get; set; }
    }

    class TrendItem
    {
        public string Name { get; set; }
    }
}
