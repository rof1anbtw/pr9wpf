using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEmal
{
    /// <summary>
    /// Логика взаимодействия для send.xaml
    /// </summary>
    public partial class send : Page
    {

        
        public send(string otkeda)
        {
            InitializeComponent();  
            komy.Text = otkeda;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var lognin = ImapHalper.GetCredentials();
            var text = new TextRange(richtext.Document.ContentStart, richtext.Document.ContentEnd);
            MailMessage a = new MailMessage(lognin.Email, komy.Text, Topic.Text, text.Text);
            a.IsBodyHtml= true;
            SmtpClient smtp = new SmtpClient(lognin.SmtpHost);
            smtp.Credentials = new NetworkCredential(lognin.Email, lognin.Pass);
            smtp.EnableSsl= true;
            smtp.Send(a);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

       
    }
}
