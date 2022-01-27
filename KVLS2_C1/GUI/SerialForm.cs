using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace OpenHardwareMonitor.GUI {
  public partial class SerialForm : Form {
    private MainForm parent;
    private Timer Timer = null;
    public SerialForm(MainForm m) {
      InitializeComponent();
      parent = m;

      Timer = new Timer();
      Timer.Tick += Timer_Tick;
      Timer.Interval = (int)1000;
      Timer.Start();

    }

    private void updateComport() {

      comboBox1.Items.Clear();
      string[] comlist = System.IO.Ports.SerialPort.GetPortNames();

      if (comlist.Length > 0) {
        //foreach (var com in comlist) {
          comboBox1.Items.AddRange(comlist);
        //}
      }
    }


    private void Timer_Tick(object sender, EventArgs e) {
      updateComport();
    }
  }
}
