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
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;

namespace Client
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> deviceName = new List<string>();

        private void sqlTest()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=actiontracting:us-central1:emaildatabase;Initial Catalog=emailDB;User ID=Hackers;Password=Arizona$;");

            try
            {
                sqlCon.Open();
            }

            catch(Exception e)
            {
                Console.Write("Failed!" + e.ToString());
            }
           
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from ROE", sqlCon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);

            foreach (DataRow row in dtbl.Rows)
            {
                Console.WriteLine(row["esender"]);
            }
            Console.ReadKey();
        }

        private void macAddress()
        {
            String firstMacAddress = NetworkInterface
    .GetAllNetworkInterfaces()
    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
    .Select(nic => nic.GetPhysicalAddress().ToString())
    .FirstOrDefault();

            Console.Write(firstMacAddress);
        }

        private void putUnityExecutable(string path)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = false;
            //        Please chnge the file path here V V V bellow based on where the .exe files is
            myProcess.StartInfo.FileName = "C:\\Users\\hawar\\Desktop\\ZipUE4thing\\MHacks12MalwareNetwork.exe";
            //myProcess.StartInfo.Arguments = "-parentHWND " + panel1.Handle.ToInt32() + " " + Environment.CommandLine;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
        }

        public MainWindow()
        {
            InitializeComponent();
            //macAddress();
            putUnityExecutable("test");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window1 win2 = new Window1();
            win2.Show();
        }
    }
}
