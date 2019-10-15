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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Window = System.Windows.Window;

namespace Client
{
    struct newDevice //Data associated with each device on the network.
    {
        public string deviceName;
        public string ipAddress;
        public string macAddress;
    }

    struct connection
    {
        public string deviceName1;
        public string deviceName2;
    }    

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<newDevice> newDevices = new List<newDevice>();
        List<connection> connections = new List<connection>();

        newDevice test = new newDevice();
        connection newConnection = new connection();

        string devicesText;
        string connectionsText;

        public void createTopology(string path)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int i = 1; i < newDevices.Count + 1; i++)
            {
                xlWorkSheet.Cells[i + 1, 1].Value2 = newDevices[i - 1].deviceName;
                xlWorkSheet.Cells[1, i + 1].Value2 = newDevices[i - 1].deviceName;
            }

            //Populate List with Zeroes
            for (int i = 2; i < newDevices.Count + 2; i++)
            {
                for (int j = 2; j < newDevices.Count + 2; j++)
                {
                    xlWorkSheet.Cells[i, j] = 0;
                }
            }

            //Find the indicies in which the two connectons exist.
            int location1 = 0, location2 = 0;

            //For Each Device
            for (int i = 1; i < newDevices.Count + 2; i++)
            {
                for (int j = 1; j < newDevices.Count; j++)
                {
                    
                }

                if (Convert.ToString(xlWorkSheet.Cells[i + 1, 1].Value2 == newDevices[i])) ;

            }

            xlWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

        }

        public Window1()
        {
            DataGrid newDevicesGrid = new DataGrid();
            DataGrid connectionsGrid = new DataGrid();

            test.deviceName = "Device Name Test";
            test.ipAddress = "1.0.0.0";
            test.macAddress = "Test MAC Address";

            newConnection.deviceName1 = "Test Device Name 1";
            newConnection.deviceName2 = "Test Device Name 2";
            newDevices.Add(test);
            connections.Add(newConnection);

            InitializeComponent();
            newDevicesGrid.ItemsSource = newDevices;
            connectionsGrid.ItemsSource = connections;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            devicesText = newDevicesBox.Text;
            connectionsText = newConnectionsBox.Text;
            string pathText = PathBox.Text;

            newDevice tempDevice = new newDevice();
            connection tempConnection = new connection();

            char delim1 = ';';
            char delim2 = ',';
            string[] indiviudalDevices = devicesText.Split(delim1);
            for(int i = 0; i < indiviudalDevices.Count(); i++)
            {
                string[] splitData = indiviudalDevices[i].Split(delim2);
                tempDevice.deviceName = splitData[0];
                tempDevice.ipAddress = splitData[1];
                tempDevice.macAddress = splitData[2];
                newDevices.Add(tempDevice);
            }

            string[] indiviudalConnections = connectionsText.Split(delim1);
            for (int i = 0; i < indiviudalConnections.Count(); i++)
            {
                string[] splitData = indiviudalConnections[i].Split(delim2);
                tempConnection.deviceName1 = splitData[0];
                tempConnection.deviceName2 = splitData[1];
                connections.Add(tempConnection);
            }



            createTopology(PathBox.Text);
        }
    }
}
