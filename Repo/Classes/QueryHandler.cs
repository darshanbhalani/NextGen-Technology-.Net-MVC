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
            message.Subject = "Welcome to NextGen Technology 🎉";
            message.To.Add(new MailAddress(data.email.Trim().ToLower().ToString()));
            message.Body = @$"
                        <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
</head>
<body style='font-family: Arial, sans-serif; background-color: transparent; margin: 0; padding: 0;  color:white;'>
    <div class='container' style='width: 80%; margin: 20px auto; max-width: 600px;background-color: #0a3d62; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); padding: 20px;'>
        <img src='https://storage.googleapis.com/nextgen_technology/Assets/logos/logo4-light.png' alt='Company Logo' style='max-width: 100px;height: auto; display: block; margin: 0 auto 20px;'>
        <div class='content' style='text-align: center;'>
            <p>Hi <span class='name' style='font-weight: bold;'><b>{data.firstName.Trim().ToString()}</b></span>,</p>
            <p>We're thrilled you reached out to us! At NextGen Technology, our team will connect with you as soon as possible.</p>
        </div>
    </div>
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
