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
using System.Windows.Shapes;

namespace MsGeader
{
    /// <summary>
    /// Логика взаимодействия для TestMassageError.xaml
    /// </summary>
    public partial class TestMassageError : Window
    {
        public TestMassageError(string msg)
        {
            InitializeComponent();
            tbError.Text = msg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }
    }
}
