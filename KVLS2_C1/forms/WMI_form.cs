using System;
using System.Management;
using System.Windows.Forms;


namespace KVLS2_C1.forms
{
    class WMI_form : Form
    {
        private ListView listView;
        private ColumnHeader nameColumnHeader;
        private ColumnHeader valueColumnHeader;
        private ComboBox wmiComboBox;
        private Label wmiLabel;

        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wmiComboBox = new System.Windows.Forms.ComboBox();
            this.wmiLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(80, 61);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(949, 444);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 180;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Value";
            this.valueColumnHeader.Width = 300;
            // 
            // wmiComboBox
            // 
            this.wmiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wmiComboBox.FormattingEnabled = true;
            this.wmiComboBox.Location = new System.Drawing.Point(126, 22);
            this.wmiComboBox.Name = "wmiComboBox";
            this.wmiComboBox.Size = new System.Drawing.Size(350, 20);
            this.wmiComboBox.TabIndex = 8;
            this.wmiComboBox.SelectedIndexChanged += new System.EventHandler(this.wmiComboBox_SelectedIndexChanged);
            // 
            // wmiLabel
            // 
            this.wmiLabel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.wmiLabel.Location = new System.Drawing.Point(45, 22);
            this.wmiLabel.Name = "wmiLabel";
            this.wmiLabel.Size = new System.Drawing.Size(50, 24);
            this.wmiLabel.TabIndex = 7;
            this.wmiLabel.Text = "WMI :";
            this.wmiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WMI_form
            // 
            this.ClientSize = new System.Drawing.Size(1108, 566);
            this.Controls.Add(this.wmiComboBox);
            this.Controls.Add(this.wmiLabel);
            this.Controls.Add(this.listView);
            this.Name = "WMI_form";
            this.ResumeLayout(false);

        }

        public WMI_form()
        {
            InitializeComponent();

            Load += Form_Load;

        }

        #region WMI List 
        private void Form_Load(object sender, EventArgs e)
        {
            this.wmiComboBox.Items.Add("Win32_BaseBoard");
            this.wmiComboBox.Items.Add("Win32_Battery");
            this.wmiComboBox.Items.Add("Win32_BIOS");
            this.wmiComboBox.Items.Add("Win32_Bus");
            this.wmiComboBox.Items.Add("Win32_CDROMDrive");
            this.wmiComboBox.Items.Add("Win32_DiskDrive");
            this.wmiComboBox.Items.Add("Win32_DMAChannel");
            this.wmiComboBox.Items.Add("Win32_Fan");
            this.wmiComboBox.Items.Add("Win32_FloppyController");
            this.wmiComboBox.Items.Add("Win32_FloppyDrive");
            this.wmiComboBox.Items.Add("Win32_IDEController");
            this.wmiComboBox.Items.Add("Win32_IRQResource");
            this.wmiComboBox.Items.Add("Win32_Keyboard");
            this.wmiComboBox.Items.Add("Win32_MemoryDevice");
            this.wmiComboBox.Items.Add("Win32_NetworkAdapter");
            this.wmiComboBox.Items.Add("Win32_NetworkAdapterConfiguration");
            this.wmiComboBox.Items.Add("Win32_OnBoardDevice");
            this.wmiComboBox.Items.Add("Win32_ParallelPort");
            this.wmiComboBox.Items.Add("Win32_PCMCIAController");
            this.wmiComboBox.Items.Add("Win32_PhysicalMedia");
            this.wmiComboBox.Items.Add("Win32_PhysicalMemory");
            this.wmiComboBox.Items.Add("Win32_PortConnector");
            this.wmiComboBox.Items.Add("Win32_PortResource");
            this.wmiComboBox.Items.Add("Win32_Processor");
            this.wmiComboBox.Items.Add("Win32_SCSIController");
            this.wmiComboBox.Items.Add("Win32_SerialPort");
            this.wmiComboBox.Items.Add("Win32_SerialPortConfiguration");
            this.wmiComboBox.Items.Add("Win32_SoundDevice");
            this.wmiComboBox.Items.Add("Win32_SystemEnclosure");
            this.wmiComboBox.Items.Add("Win32_TapeDrive");
            this.wmiComboBox.Items.Add("Win32_TemperatureProbe");
            this.wmiComboBox.Items.Add("Win32_UninterruptiblePowerSupply");
            this.wmiComboBox.Items.Add("Win32_USBController");
            this.wmiComboBox.Items.Add("Win32_USBHub");
            this.wmiComboBox.Items.Add("Win32_VideoController");
            this.wmiComboBox.Items.Add("Win32_VoltageProbe");
            this.wmiComboBox.Items.Add("Win32_LogicalDisk");
            this.wmiComboBox.Items.Add("Win32_OperatingSystem");
            this.wmiComboBox.Items.Add("Win32_PnPDeviceProperty");
            this.wmiComboBox.Items.Add("Win32_PerfFormattedData_PerfOS_Processor");

            this.wmiComboBox.SelectedIndex = 0;
        }
        #endregion



        private void wmiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
#if true
            if (this.wmiComboBox.SelectedItem != null)
            {
                this.listView.Items.Clear();
  
                SelectQuery selectQuery = new SelectQuery(this.wmiComboBox.SelectedItem as string);

                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(selectQuery);

                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    this.listView.Groups.Add(managementObject.ToString(), managementObject.Properties["Name"].Value.ToString());

                    foreach (PropertyData propertyData in managementObject.Properties)
                    {
                        string valueString = null;

                        if (propertyData.Value != null)
                        {
                            valueString = propertyData.Value.ToString();
                        }

                        string[] itemArray = { propertyData.Name, valueString };

                        ListViewItem listViewItem = new ListViewItem(itemArray);

                        listViewItem.Group = listView.Groups[managementObject.ToString()] as ListViewGroup;

                        listView.Items.Add(listViewItem);
                    }
                }
            }
#endif
        }
    }
}