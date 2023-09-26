using System;
using ImapX.Collections;
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

namespace WpfEmal
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MailClick.SelectedItem as ComboBoxItem != null)
            {
                ImapHalper.Initialize((MailClick.SelectedItem as ComboBoxItem).Tag.ToString());
                try
                {

                    if (ImapHalper.Login(Email.Text, Parol.Password))
                    {
                        bool open = false;
                        Pochta windows = new Pochta();
                        windows.ShowDialog();
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show(Email.Text);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Email.Text = "syperkek777@mail.ru";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
//1639503416RchA
//percyshumilin@yandex.ru
//tAppxk4xXBdnbtXUm8wM