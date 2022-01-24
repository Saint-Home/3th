using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KVLS2_C1.forms
{
    class IBIT_form : Form
    {
        private Label label1;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IBIT";
            // 
            // IBIT_form
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Name = "IBIT_form";
            this.Text = "IBIT VIEW";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public IBIT_form()
        {
            InitializeComponent();
        }

    }
}
