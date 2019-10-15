using System;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Net.NetworkInformation;

namespace attempt7
{
    class Program
    {
        static void Main(string[] args)
        {
            String firstMacAddress = NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            .Select(nic => nic.GetPhysicalAddress().ToString())
            .FirstOrDefault();

            while (true)
            {
                //mail stuff
                MailMessage email = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("umdearbornstudent1", "ovrucwhjkxqaxatr");
                smtpClient.EnableSsl = true;
                string usrEmail = "umdearbornstudent1@gmail.com";

                Console.WriteLine("Please provide me with an Email address.");
                string sendTo = Console.ReadLine().ToString();
                Console.WriteLine("Please provide me with an email subject.");
                string mesSubject = Console.ReadLine().ToString();
                Console.WriteLine("Please provide me with a message.");
                string emailMessage = Console.ReadLine();

                //SQL server stuff
                String connectionString = null;
                MySqlConnection cnn;
                connectionString = "server=34.68.3.3;database=emailDB;uid=Hackers;pwd=Arizona$";
                cnn = new MySqlConnection(connectionString);

                //mail stuff
                email.From = new MailAddress("haw2abe@gmail.com");
                email.To.Add(sendTo);
                email.Subject = mesSubject;
                email.Body = emailMessage;

                //SQL server stuff
                DateTime datetimeNow = DateTime.Now;
                string time = datetimeNow.ToString("yyyy-MM-dd HH:mm:ss");
                String Query = "INSERT INTO emailDB.ROE (esender, ereceiver, timestmp, macadd) VALUES('" + usrEmail + "', '" + sendTo + "', '" + time + "', '" + firstMacAddress + "'" + ")";


                try
                {
                    smtpClient.Send(email);
                }
                catch (SmtpFailedRecipientException error)
                {
                    Console.WriteLine("error: " + error.Message + "\nFailing recipient: " + error.FailedRecipient);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.ToString());
                }
                catch
                {
                    Console.WriteLine("Error!");
                }

                Console.WriteLine("Email sent successfully!");

                try
                {
                    cnn.Open();
                    Console.WriteLine("connection open");

                    MySqlCommand command = new MySqlCommand(Query, cnn);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("Data appended to the database!");
                    }
                    else
                    {
                        Console.WriteLine("Error: Data NOT appended to database!");
                    }

                    cnn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("error opening the db " + e.ToString());
                }
                catch
                {
                    Console.WriteLine("test");
                }

                Console.WriteLine("Server updated successfully!");

                Console.WriteLine("Would you like to send another email? Y or N");
                string exitVar = Console.ReadLine();

                if (exitVar[0] == 'N' || exitVar[0] == 'n' || exitVar == "no" || exitVar == "NO")
                {
                    Console.WriteLine("Thank you for using Dearborns' Finest's program");
                    break;
                }
            }
        }
    }
}
