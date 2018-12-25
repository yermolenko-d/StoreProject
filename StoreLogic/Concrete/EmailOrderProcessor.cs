using System.Net;
using System.Net.Mail;
using StoreLogic.Entities;
using StoreLogic.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic.Concrete
{
    public class EmailSetup
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "cakestore@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"d:\game_store_emails";
    }
    

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSetup emailSetup;

        public EmailOrderProcessor (EmailSetup setup)
        {
            emailSetup = setup;
        }

        public void ProcessOrder(Basket basket, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSetup.UseSsl;
                smtpClient.Host = emailSetup.ServerName;
                smtpClient.Port = emailSetup.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSetup.Username, emailSetup.Password);
            
            if (emailSetup.WriteAsFile)
            {
                smtpClient.DeliveryMethod
                    = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                smtpClient.PickupDirectoryLocation = emailSetup.FileLocation;
                smtpClient.EnableSsl = false;
            }


            StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("---")
                    .AppendLine("Товары:");

            foreach (var line in basket.Show)
            {
                var subtotal = line.Cake.Price * line.Amount;
                body.AppendFormat("{0} x {1} (итого: {2:c}",
                    line.Amount, line.Cake.Name, subtotal);
            }

            body.AppendFormat("Общая стоимость: {0:c}", basket.CountTotal())
                .AppendLine("---")
                .AppendLine("Доставка:")
                .AppendLine(shippingDetails.Name)
                .AppendLine(shippingDetails.Line1)
                .AppendLine(shippingDetails.Line2 ?? "")
                .AppendLine(shippingDetails.Line3 ?? "")
                .AppendLine(shippingDetails.City)
                .AppendLine(shippingDetails.Country)
                .AppendLine("---")
                .AppendFormat("Подарочная упаковка: {0}",
                    shippingDetails.Gift ? "Да" : "Нет");

            MailMessage mailMessage = new MailMessage(
                                   emailSetup.MailFromAddress,   // От кого
                                   emailSetup.MailToAddress,     // Кому
                                   "Новый заказ отправлен!",        // Тема
                                   body.ToString());                // Тело письма

            if (emailSetup.WriteAsFile)
            {
                mailMessage.BodyEncoding = Encoding.UTF8;
            }

            smtpClient.Send(mailMessage);
        }
    }
  }
}