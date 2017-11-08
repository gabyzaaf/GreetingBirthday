using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BirthdayGreeting2;

namespace EmailSender
{
    class EmailSender : ISender
    {
        private MailMessage mail;
        private SmtpClient smtpClient = new SmtpClient();

        public EmailSender()
        {
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Credentials = new System.Net.NetworkCredential("trainingatrolladev@gmail.com", "Arolla75003");
            smtpClient.EnableSsl = true;
        }

        public void Send(List<EmployeeInformations> employee)
        {

            foreach (var emp in employee)
            {
                Console.WriteLine($"Employee is {emp.Name} with email {emp.Email}");
                this.mail = new MailMessage("me@gmail.com",emp.Email.ToString());
                mail.Subject = "This is a email test";
                mail.Body = "Body inside the email";
                smtpClient.Send(mail);
                
            }
            Console.WriteLine("Finish to Send Email");
        }
    }
}
