using System;
using System.Net;
using System.Text;
using System.Web.Services.Protocols;

namespace Data.DataCredito
{
    public static class ClientExtensions
    {
        public static WebRequest GetRequestWithBasicAuthorization(this WebRequest request, Uri uri)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var networkCredentials = request.Credentials.GetCredential(uri, "Basic");
            var credentialBuffer =
                new UTF8Encoding().GetBytes(networkCredentials.UserName + ":" + networkCredentials.Password);
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
            return request;
        }

        public static void SetNetworkCredentials(
            this WebClientProtocol client,
            string userName,
            string password,
            Uri customUrl = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            client.PreAuthenticate = true;

            var uri = customUrl == null ? new Uri(client.Url) : customUrl;
            var netCredential = new NetworkCredential(userName, password);
            ICredentials credentials = netCredential.GetCredential(uri, "Basic");
            client.Credentials = credentials;
        }
    }
}