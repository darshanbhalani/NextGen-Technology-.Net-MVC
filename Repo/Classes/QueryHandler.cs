using NextGen_Technology.Models;
using NextGen_Technology.Repo.Interfaces;
using System.Configuration;
using System.Drawing.Text;
using Npgsql;
using System.Net.Mail;
using System.Net;

namespace NextGen_Technology.Repo.Classes
{
    public class QueryHandler : IQueryHandler
    {
        public void saveData(Query data)
        {
            DBConfiguration dbConfiguration = new DBConfiguration
            {
                Host = "localhost",
                Port = "5432",
                Username = "postgres",
                Password = "2708",
                Database = "NextGen Technology"
            };

            string connectionString = dbConfiguration.generateConnectionString();


            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = $"insert into query values('{data.firstName}','{data.lastName}','{data.country}','{data.city}','{data.phone}','{data.email}','{data.description}','{DateTime.UtcNow}');";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public void sendEmailToClient(Query data)
        {

            SMTPConfiguration sMTPConfiguration = new SMTPConfiguration
            {
                server = "smtp.gmail.com",
                hostName = "connect.nextgentechnology@gmail.com",
                password = "tcllfvvxodcydksv",
                port = 587
            };

            MailMessage message = new MailMessage();
            message.From = new MailAddress(sMTPConfiguration.hostName);
            message.Subject = "Welcome to NextGen Technology";
            message.To.Add(new MailAddress(data.email.Trim().ToLower().ToString()));
            message.Body = @$"
                    <html>
                    <body>
                    Hi {data.firstName.Trim().ToString()},<br/>
                    We're thrilled you reached out to us! At NextGen Technology. Our Team will connect you as soon as possible.
                    </body>
                    </html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient(sMTPConfiguration.server)
            {
                Port = sMTPConfiguration.port,
                Credentials = new NetworkCredential(sMTPConfiguration.hostName, sMTPConfiguration.password),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
        public void sendEmailToAdmin()
        {
        }
    }
}
