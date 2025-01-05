using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace msmtp_test
{
    class Program
    {

        static void Main(string[] args)
        {
            float pegel = 333;

            Console.WriteLine("MSMTP TEST");
            mail m = new mail();
            m.subject("Test Mail");
            m.body("Hello world");
            m.body("Pegel Gundelsheim is " + pegel.ToString());
            m.body("This is an auto-generated mail. Do not reply ");
            m.body("Have a nice day ");
            m.send("carsten.lueck@outlook.com");

            //Process.Start("mail.sh", "mail.txt");
        }
    }

    public class mail
    {
        List<string> mailbody;
        string body_file = "mailbody.txt";

        /// <summary>
        /// create a new mail
        /// </summary>
        public mail()
        {
            mailbody = new List<string>();
        }

        public void subject(string s)
        {
            mailbody.Add("Subject: " + s + "\r");
        }

        /// <summary>
        /// add text to mail body
        /// </summary>
        /// <param name="s"></param>
        public void body(string s)
        {
            //mailbody.Add("<pre>"+s+"</pre>");
            mailbody.Add("\r"+s);
        }

        /// <summary>
        /// save mail body to file
        /// </summary>

        public void saveMail ()
        {
            File.WriteAllLines(body_file, mailbody);
        }

        public void send(string address)
        {
            File.WriteAllLines(body_file, mailbody);
            Process.Start("mail.sh", address + " " + body_file);
        }
    }
}
