//namespace PotatoWebAPI;
//using MailKit.Net.Smtp;
//using MailKit.Security;
//using MimeKit;

//public class SendEmail
//{
//    private readonly IConfiguration _configuration;

//    public SendEmail(IConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    public async Task SendEmailAsync(string toEmail, string subject, string body)
//    {
//        try
//        {
//            var email = new MimeMessage();
//            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:SenderEmail"]));
//            email.To.Add(MailboxAddress.Parse("toEmail"));
//            email.Subject=subject;
//            email.Body=new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };
//            using var smtp=new SmtpClient();
//            await smtp.ConnectAsync(_configuration["EmailSettings:SmtpServer"]);

//        }
//        catch (Exception ex) { }
//    }
//}

