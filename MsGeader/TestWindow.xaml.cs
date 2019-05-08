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


    public partial class TestWindow : Window
    {
        Dictionary<string, int> smtpBase;// Создание элемент класса (ключ/значение)
        Dictionary<string, string> smtpBaseAdress;
        public TestWindow()
        {
            InitializeComponent();
            smtpBase = new Dictionary<string, int>();
            smtpBaseAdress = new Dictionary<string, string>();
        }

        
        private string smtpShort()
        {
            var user_nameTo = UserNameTo.Text;
            var poz = user_nameTo.IndexOf('@') + 1;
            string MailAdress = user_nameTo.Substring(poz);
            smtpBase.Clear();
            smtpBase.Add("yandex.ru",25);
            smtpBase.Add("mail.ru", 25);
            smtpBaseAdress.Clear();
            smtpBaseAdress.Add("yandex.ru", "smtp.yandex.ru");
            
            return MailAdress;
        }

        private void errorEx(string error)
        {
            TestMassageError tmerror = new TestMassageError(error);
            
            tmerror.ShowDialog();
            //MessageBox.Show("Невозможно отправить письмо " + error);
        }

        


        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            
            SendMessege();
        }

        
    }
}
