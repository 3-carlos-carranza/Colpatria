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
                var networkCredentials = request.Credentials.GetCredential(uri, "Basic");
                var credentialBuffer =
                    new UTF8Encoding().GetBytes(networkCredentials.UserName + ":" + networkCredentials.Password);
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                return request;
            }

            public static void SetNetworkCredentials(
                this WebClientProtocol client,
                string username,
                string password,
                Uri customUrl = null)
            {
                client.PreAuthenticate = true;
            
                var uri = customUrl == null ? new Uri(client.Url) : customUrl;
                var netCredential = new NetworkCredential(username, password);
                ICredentials credentials = netCredential.GetCredential(uri, "Basic");
                client.Credentials = credentials;
            }
        }
    
}
