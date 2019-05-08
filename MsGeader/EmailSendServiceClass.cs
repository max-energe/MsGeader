using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

namespace MsGeader
{
    public class EmailSendServiceClass
    {

        public void SendMessege()
        {
            /*Parameters.user_nameFrom = UserNameEdit.Text;
            

            Parameters.user_nameTo = UserNameTo.Text;
            Parameters.massageSubject = tbMassageSubject.Text;
            Parameters.massageBody = tbMessegeBody.Text;
            */
            //PasswordBoxEdit.SecurePassword.ToString()
            //smtpName.Text = smtpBaseAdress[smtpShort()] + ", " + smtpBase[smtpShort()].ToString();


            try
            {

                using (var client = new SmtpClient("smtp.yandex.ru", 25)) //smtpBase[smtpShort()]
                {
                    client.EnableSsl = true; //efefef
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(Parameters.user_nameFrom, Parameters.password);
                    //PasswordBoxEdit.SecurePassword.Clear();
                    //PasswordBoxEdit.Clear();
                    //client.Timeout = 100; // Устанавливаем срок на отправку данных к серверу
                    using (var msg = new MailMessage(Parameters.user_nameFrom, Parameters.user_nameTo))
                    {
                        msg.Subject = Parameters.massageSubject;
                        msg.Body = Parameters.massageBody;
                        msg.IsBodyHtml = false; // Не используем html в теле письма

                        try
                        {
                            client.Send(msg);



                            TestMessageEnd tme = new TestMessageEnd(); //проо
                            tme.Show();


                        }
                        catch (Exception ex)
                        {

                            errorEx(ex.ToString());

                        }
                    }

                }

            }

            catch (Exception error)
            {
                MessageBox.Show(
                    error.Message,
                    "Ошибка в процессе отправки почты!",
                    MessageBoxButton.OK, MessageBoxImage.Error);


            }
        }






    }
}
