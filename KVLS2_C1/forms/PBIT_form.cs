using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Timers;
using System.Management;

using Hardware.Info;
using Hardware;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;
using System.Windows.Forms.DataVisualization.Charting;


namespace KVLS2_C1.forms
{
    class PBIT_form : Form
    {
        static Computer _thisComputer;

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Panel panel1;
        private ColumnHeader columnHeader5;
        ListViewItem Lvi1;

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1105, 512);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Contet";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "State";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Min";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Max";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 512);
            this.panel1.TabIndex = 0;
            // 
            // PBIT_form
            // 
            this.ClientSize = new System.Drawing.Size(1105, 512);
            this.Controls.Add(this.panel1);
            this.Name = "PBIT_form";
            this.Text = "PBIT VIEW";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public PBIT_form()
        {
            InitializeComponent();
            View_Init();

            Thread worker = new Thread(pThread);
            worker.IsBackground = true;
            worker.Start();

        }

        private void View_Init()
        {

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.Columns[0].Width = -2;
            listView1.Columns[0].Width = 200;

            listView1.Columns[1].Width = -2;
            listView1.Columns[1].Width = 400;

            listView1.Columns[2].Width = -2;
            listView1.Columns[2].Width = 100;

            listView1.Columns[3].Width = -2;
            listView1.Columns[3].Width = 100;

            listView1.Columns[4].Width = -2;
            listView1.Columns[4].Width = 100;



        }
        private void pThread()
        {

            while (true)
            {
#if true
                string[] str = getComportList();
                StringBuilder sb = new StringBuilder();
                List<string> comport = new List<string>();

                comport = GetSerialPorts();

          

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
#if false
                        for (int i = 0; i < str.Length; i++)
                        {
                            sb.Append(str[i]);
                        }

                        Console.WriteLine(sb.ToString());
#endif
                        foreach (var port in comport)
                        {
                            Console.WriteLine(port);
                        }
                        listView1.Items.Clear();
                        getComport_List();
                        CPU_InfoUpdate();


                    }));
                }
                else
                {
#if false
                    for (int i = 0; i < str.Length; i++)
                    {
                        sb.Append(str[i]);
                    }

                    Console.WriteLine(sb.ToString());
#endif
                    foreach (var port in comport)
                    {
                        Console.WriteLine(port);
                    }


                    getComport_List();
                    CPU_InfoUpdate();

                }
                Thread.Sleep(1000);
            }
#endif
                }


        private void getComport_List()
        {

            List<string> comport = new List<string>();
            comport = GetSerialPorts();

            foreach (var item in comport)
            {
                listView1.Items.Add(new ListViewItem(item));
                //listView1.Items[1].SubItems[3].Text = "-";
            }
            //new ListViewItem(item);
#if false
            Lvi1 = new ListViewItem("COM", 0);
            Lvi1.SubItems.Add("-");
            Lvi1.SubItems.Add("-");
            Lvi1.SubItems.Add("-");
            Lvi1.SubItems.Add("-");
            listView1.Items.Add(Lvi1);
#endif
        }

        public List<string> GetSerialPorts()
        {
            List<string> portNames = new List<string>();
            string[] port = System.IO.Ports.SerialPort.GetPortNames();

            foreach (string portName in port)
            {
                portNames.Add(portName);
            }

            portNames.Sort();
            return portNames;
        }



        private string[] getComportList()
        {

            List<string> comList = new List<string>();
            var search = new ManagementObjectSearcher("Win32_SerialPort");

            string[] p = System.IO.Ports.SerialPort.GetPortNames();
            string[] ports = new string[p.Length];

            for (int i = 0; i < p.Length; i++)
            {
                ports[i] = p[i];

            }
            //MessageBox.Show(ports.ToString());

            return ports;
        }



        private void CPU_InfoUpdate()
        {
            _thisComputer = new Computer() { CPUEnabled = true, GPUEnabled = true, MainboardEnabled = true, HDDEnabled = true };
            _thisComputer.Open();

            StringBuilder sb = new StringBuilder();

            foreach (var hardwareItem in _thisComputer.Hardware)
            {
                switch (hardwareItem.HardwareType)
                {
                    case HardwareType.CPU:
                    case HardwareType.GpuNvidia:
                    case HardwareType.HDD:
                    case HardwareType.Mainboard:
                    case HardwareType.RAM:
                        AddCpuInfo(sb,hardwareItem);
                        break;
                }
            }

;
            Console.WriteLine(sb.ToString());

            //getComport_List(sb, sb.Length);
            Thread.Sleep(1000);

        }


        private void AddCpuInfo(StringBuilder sb, IHardware hardwareItem)
        {
            hardwareItem.Update();
            foreach (IHardware subHardware in hardwareItem.SubHardware)
                subHardware.Update();

            string text;

            foreach (var sensor in hardwareItem.Sensors)
            {
                string name = sensor.Name;
                string value = sensor.Value.HasValue ? sensor.Value.Value.ToString() : "-1";

                switch (sensor.SensorType)
                {
                    case SensorType.Temperature:
                        text = $"{name} Temperature = {value}";
                        sb.AppendLine(text);
                        break;

                    case SensorType.Voltage:
                        text = $"{name} Voltage = {value}";
                        sb.AppendLine(text);
                        break;

                    case SensorType.Fan:
                        text = $"{name} RPM = {value}";
                        sb.AppendLine(text);
                        break;

                    case SensorType.Load:
                        text = $"{name} % = {value}";
                        sb.AppendLine(text);
                        break;

                    case SensorType.Power:
                        text = $"{name} % = {value}";
                        sb.AppendLine(text);
                        break;
                }

            }
        }

    }
}
