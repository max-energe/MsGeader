using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net;
using System.Net.Mail;

namespace MsGeader
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            var user_name = UserNameEdit.Text;
            var password = PasswordBoxEdit.SecurePassword;

            try
            {
                using (var client = new SmtpClient("smtp.yandex.ru", 25))
                {
                    client.EnableSsl = true; //efefef
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(user_name, password);
                    //client.Timeout = 100; // Устанавливаем срок на отправку данных к серверу
                    using (var msg = new MailMessage("max-energe@yandex.ru", "cad-exs.m@yandex.ru"))
                    {
                        msg.Subject = $"Заголовок сообщения {DateTime.Now}";
                        msg.Body = $"Тело сообщения {DateTime.Now}";
                        msg.IsBodyHtml = false; // Не используем html в теле письма

                        try
                        {
                            client.Send(msg);
                            MessageBox.Show("Почта отправлена");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }                                                
                    }

                }
                
            }

            catch(Exception error)
            {
                MessageBox.Show(
                    error.Message,
                    "Ошибка в процессе отправки почты!",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
