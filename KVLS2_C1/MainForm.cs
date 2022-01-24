using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;

using System.Collections.Specialized;
using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;


namespace KVLS2_C1
{

    public partial class MainForm : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleseCaputre();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int IParam);

        private Color SelectThemeColor(int index)
        {
#if false
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
#endif
            string color = ThemeColor.ColorList[index - 1];
            return ColorTranslator.FromHtml(color);
        }

        private void ActiveButton(object btnSender,int index)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor(index);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel3.BackColor = color;
                    panel2.BackColor = ThemeColor.ChangeColorBrightness(color,-0.3);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


        private void OpenChildForm(Form childForm, object btnSender, int index)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActiveButton(btnSender, index);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(childForm);
            this.MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label2.Text = childForm.Text;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            this.Update();
        }


        private void button1_Click(object sender, EventArgs e)
        { 
            //ActiveButton(sender,0);
           OpenChildForm(new forms.PBIT_form(), sender, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ActiveButton(sender,1);
            OpenChildForm(new forms.IBIT_form(), sender, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ActiveButton(sender,2);
            OpenChildForm(new forms.CBIT_form(), sender, 3);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleseCaputre();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new forms.WMI_form(), sender, 4);
        }
#if false
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            pnlTitleBar.BackColor = Color.FromArgb(108, 156, 196);
            pnlLogo.BackColor = Color.SteelBlue;
            currentButton = null;
            btnCloseChildFrm.Visible = false;
        }
#endif

    }
}
