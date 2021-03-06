﻿using Banlinea.Framework.Notification.EmailProviders.Contracts;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Crosscutting.Common
{
    public class MailService : IEmailNotificatorService
    {
        public bool SendEmail(EmailMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            var client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator =
                    new HttpBasicAuthenticator("api", ConfigurationManager.AppSettings.Get("key-api-mailgun"))
            };

            var request = new RestRequest { Resource = "{domain}/messages" };

            request.AddParameter("domain", ConfigurationManager.AppSettings["domain-colpatria"],
                ParameterType.UrlSegment);

            request.AddParameter("from", message.Sender.Name + "<" + message.Sender.Address + ">");

            request.AddParameter("to", message.To[0].Address);

            request.AddParameter("subject", message.Subject);

            request.AddParameter("html", message.Body);

            #region Attachments

            //if (message.Attachments != null)
            //{
            //    foreach (var attachment in message.Attachments)
            //    {
            //        if (attachment.IsBytes)
            //        {
            //            request.AddFile("attachment", attachment.Data, attachment.Name, attachment.MimeType);
            //        }
            //        else
            //        {
            //            using (var memoryStream = new MemoryStream(File.ReadAllBytes(attachment.Path)))
            //            {
            //                request.AddFile("attachment", memoryStream.ToArray(), Path.GetFileName(attachment.Name));
            //            }
            //        }
            //    }
            //}

            #endregion Attachments

            request.Method = Method.POST;

            client.Execute(request);

            return true;
        }

        public Task<bool> SendEmailAsync(EmailMessage message,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public void SendEmails(IEnumerable<EmailMessage> messages)
        {
            throw new NotImplementedException();
        }

        public void SendEmails(IEnumerable<EmailMessage> messages, string sender)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailsAsync(IEnumerable<EmailMessage> messages,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task SendEmailsAsync(IEnumerable<EmailMessage> messages, string sender,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}