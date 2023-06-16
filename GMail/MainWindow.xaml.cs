using Microsoft.Win32;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GMail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml weozxcbixfxxxbnf
    /// </summary>
    public partial class MainWindow : Window
    {
        const string myMailAddress = "samoliuk.sviatoslav@gmail.com";
        const string accountPassword = "weozxcbixfxxxbnf";
        MailPriority mailPriority;
        Attachment attachmentCollection;
        public MainWindow()
        {
            InitializeComponent();
            attachmentCollection = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MailMessage mail = new MailMessage(myMailAddress, toBox.Text)
            {
                Subject = themeBox.Text,
                Body = $"<h1>My Mail Message from C#</h1><p>{txtBox.Text}</p>",
                IsBodyHtml = true,
                Priority = mailPriority
            };
            mail.Attachments.Add(attachmentCollection);

            SmtpClient client = new SmtpClient("nojal84824@aramask.com")
            {
                Credentials = new NetworkCredential(myMailAddress, accountPassword),
                EnableSsl = true
            };

            client.Send(mail);
        }

        private void priority_Checked(object sender, RoutedEventArgs e)
        {
            mailPriority = MailPriority.High;
        }

        private void priority_Unchecked(object sender, RoutedEventArgs e)
        {
            mailPriority = MailPriority.Low;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                attachmentCollection = new Attachment(dialog.FileName);
            }
        }
    }
}
