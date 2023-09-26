using ImapX;
using ImapX.Collections;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace WpfEmal
{
    /// <summary>
    /// Логика взаимодействия для FolderPage.xaml
    /// </summary>
    public partial class FolderPage : Page
    {
        MessageCollection messages;
        Message meseng;
        string pismo = "";
        public FolderPage(object folder)
        {
            InitializeComponent();

            Task.Run(() =>
            {
          
                    Dispatcher.Invoke(new Action(() =>
                    {
                        messages = ImapHalper.GetMessagesForFolder(folder.ToString());



                        foreach (Message item in messages)
                        {
                            var s = item as Message;
                            MessengeList.Items.Add(s.Subject);
                        }
                    }));
                   
               
            });


        }

      

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var meseng = MessengeList.SelectedItem;
            string subjekt = "";
            string sobshenie = "";
            MailAddress otkogo = null;
            foreach (Message item in messages)
            {
                if (item.Subject == meseng)
                {
                    subjekt = item.Subject;
                    sobshenie = item.Body.Text;
                    otkogo = item.From;

                }
            }
            send page = new send(otkogo.ToString());
            folderpage.Content = page;


        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var meseng = MessengeList.SelectedItem;
            string subjekt = "";
            string sobshenie = "";
            string otkogo = "";
            foreach (Message item in messages)
            {
                if (item.Subject == meseng)
                {
                    subjekt = item.Subject;
                    sobshenie = item.Body.Text;
                    otkogo = item.From.ToString();

                }
            }
            Pismo pega = new Pismo(subjekt, otkogo, sobshenie);
            folderpage.Content = pega;

        }

        private void MessengeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var meseng = MessengeList.SelectedItem;
            pismo = meseng.ToString();
            string subjekt = "";
            string sobshenie = "";
            string otkogo = null;
            foreach (Message item in messages)
            {
                if (item.Subject == meseng)
                {
                    subjekt = item.Subject;
                    sobshenie = item.Body.Text;
                    otkogo = item.From.ToString();

                }
            }
            Pismo pega = new Pismo(subjekt, otkogo, sobshenie);
            folderpage.Content = pega;

        }

    }
}
