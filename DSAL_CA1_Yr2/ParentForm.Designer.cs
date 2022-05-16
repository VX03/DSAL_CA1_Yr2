namespace DSAL_CA1_Yr2
{
    partial class ParentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.simulationModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeDistanceModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeDistanceSmartModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulationModeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // simulationModeToolStripMenuItem
            // 
            this.simulationModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalModeToolStripMenuItem,
            this.safeDistanceModeToolStripMenuItem,
            this.safeDistanceSmartModeToolStripMenuItem});
            this.simulationModeToolStripMenuItem.Name = "simulationModeToolStripMenuItem";
            this.simulationModeToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.simulationModeToolStripMenuItem.Text = "SimulationMode";
            // 
            // normalModeToolStripMenuItem
            // 
            this.normalModeToolStripMenuItem.Name = "normalModeToolStripMenuItem";
            this.normalModeToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.normalModeToolStripMenuItem.Text = "Normal Mode";
            // 
            // safeDistanceModeToolStripMenuItem
            // 
            this.safeDistanceModeToolStripMenuItem.Name = "safeDistanceModeToolStripMenuItem";
            this.safeDistanceModeToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.safeDistanceModeToolStripMenuItem.Text = "Safe Distance Mode";
            // 
            // safeDistanceSmartModeToolStripMenuItem
            // 
            this.safeDistanceSmartModeToolStripMenuItem.Name = "safeDistanceSmartModeToolStripMenuItem";
            this.safeDistanceSmartModeToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.safeDistanceSmartModeToolStripMenuItem.Text = "Safe Distance Smart Mode";
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ParentForm";
            this.Text = "ParentForm";
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem simulationModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safeDistanceModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safeDistanceSmartModeToolStripMenuItem;
    }
}