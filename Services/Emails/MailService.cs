using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace practica1.Services.Emails
{
    public class MailService : IMailService
    {
        private readonly HttpClient _httpClient;
        public MailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            string url = "https://api.mailersend.com/v1/email";
            string token = "mlsn.47427a11150badca2e66e5fde38053e7a4c3c55e59d129e5dfd41d502c9a3f62";
        
            var email = new
            {
                from = new {email ="info@trial-x2p0347ooopgzdrn.mlsender.net"},
                to = new[] { new {email = toEmail } },
                subject = subject,
                text = body,
                html = $"<p>{body}</p>"
            };
            string jsonBody = JsonSerializer.Serialize(email);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Fallo el envio del correo: "+response.StatusCode);
            }
        }
    }
}