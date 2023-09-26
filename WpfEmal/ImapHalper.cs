using ImapX.Collections;
using ImapX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows;

namespace WpfEmal
{
    internal class LoggedUser
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string SmtpHost { get; set; }
    }
    internal class ImapHalper
    {
        private static ImapClient client { get; set; }
        private static LoggedUser loggedUser { get; set; } = new LoggedUser();
        public static void Initialize(string host)
        {
            client = new ImapClient(host, true);
            if (!client.Connect())
            {
                throw new Exception("Error connecting to the client.");
            }
            else
            {
                loggedUser.SmtpHost = host.Replace("imap", "smtp");
            }
        }
        public static bool Login(string u, string p)
        {
            loggedUser.Email = u;
            loggedUser.Pass = p;
            return client.Login(u, p);

        }
        public static void Logout()
        {
            if (client.IsAuthenticated)
            {
                client.Logout();
                client.Dispose();
            }
        }
        public static CommonFolderCollection GetFolders()
        {
            client.Folders.Inbox.StartIdling(); 
            client.Folders.Inbox.OnNewMessagesArrived += Inbox_OnNewMessagesArrived;
            return client.Folders;
        }
        private static void Inbox_OnNewMessagesArrived(object sender, IdleEventArgs e)
        {
            MessageBox.Show($"Пришло новое сообщение в папку { e.Folder.Name}.");
        }
        public static MessageCollection GetMessagesForFolder(string name)
        {
            client.Folders[name].Messages.Download();
            return client.Folders[name].Messages;
        }
        public static LoggedUser GetCredentials()
        {
            return loggedUser;
        }
    }
}
