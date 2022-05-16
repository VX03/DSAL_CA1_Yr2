using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSAL_CA1_Yr2
{
    public partial class ParentForm : Form
    {
        public normal_mode normalMode;
        public safe_distance_mode safeDistanceMode;
        public safe_distance_smart_mode smartMode;
        public ParentForm()
        {
            InitializeComponent();
            this.normalModeToolStripMenuItem.Click += new EventHandler(this.normalModeToolStripMenuItem_Click);
            this.safeDistanceModeToolStripMenuItem.Click += new EventHandler(this.safeDistanceModeToolStripMenuItem_Click);
            this.safeDistanceSmartModeToolStripMenuItem.Click += new EventHandler(this.smartModeToolStripMenuItem_Click);
        }

        private void normalModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(normalMode != null)
            {
                normalMode.Show();
            }
            if(normalMode == null)
            {
                normalMode = new normal_mode();
                normalMode.MdiParent = this;
                normalMode.Show();
            }
        }
        private void safeDistanceModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (safeDistanceMode != null)
            {
                safeDistanceMode.Show();
            }
            if (safeDistanceMode == null)
            {
                safeDistanceMode = new safe_distance_mode();
                safeDistanceMode.MdiParent = this;
                safeDistanceMode.Show();
            }
        }
        private void smartModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (smartMode != null)
            {
                smartMode.Show();
            }
            if (smartMode == null)
            {
                smartMode = new safe_distance_smart_mode();
                smartMode.MdiParent = this;
                smartMode.Show();
            }
        }
    }
}
