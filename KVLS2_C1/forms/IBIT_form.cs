using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace KVLS2_C1.forms
{
    class IBIT_form : Form
    {

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // IBIT_form
            // 
            this.ClientSize = new System.Drawing.Size(1013, 459);
            this.Name = "IBIT_form";
            this.Text = "IBIT VIEW";
            this.ResumeLayout(false);

        }

        public IBIT_form()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();

#if false
            string query = string.Format("SELECT * FROM Win32_USBController WHERE Name");

            Console.WriteLine("Query: {0}", query);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection retObjectCollection = searcher.Get();

            foreach (ManagementObject retObject in retObjectCollection)
            {
                Console.WriteLine("[{0}]\tName: {1}", retObject["ProcessID"], retObject["Name"]);
            }
#endif

            //var instances = new ManagementClass("Win32_SerialPort").GetInstances();
            //foreach (ManagementObject port in instances)
            //{
            //    Console.WriteLine("{0}: {1}", port["deviceid"], port["name"]);
            //}



        }

        private void timer_tick(object sender, EventArgs e)
        {
            getComDeviceID();
        }

        private void getComDeviceID()
        {
            List<string> id_list = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
            "root\\CIMV2",
            "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                Console.WriteLine("{0}", queryObj["PnPDeviceID"]);
            }
        }


    }
}
