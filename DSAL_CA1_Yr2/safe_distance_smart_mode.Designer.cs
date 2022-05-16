namespace DSAL_CA1_Yr2
{
    partial class safe_distance_smart_mode
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnA = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.btnResetSimulation = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnSeatLayout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.numRow = new System.Windows.Forms.NumericUpDown();
            this.numCol = new System.Windows.Forms.NumericUpDown();
            this.panelSeats = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbEnable = new System.Windows.Forms.RadioButton();
            this.Disable = new System.Windows.Forms.RadioButton();
            this.btnEnableAll = new System.Windows.Forms.Button();
            this.tnDisableAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCol)).BeginInit();
            this.panelSeats.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.Color.Yellow;
            this.btnA.Location = new System.Drawing.Point(43, 213);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(270, 29);
            this.btnA.TabIndex = 56;
            this.btnA.Text = "Person A Booking";
            this.btnA.UseVisualStyleBackColor = false;
            // 
            // labelMessage
            // 
            this.labelMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMessage.Location = new System.Drawing.Point(43, 658);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(270, 155);
            this.labelMessage.TabIndex = 62;
            // 
            // btnResetSimulation
            // 
            this.btnResetSimulation.Location = new System.Drawing.Point(43, 404);
            this.btnResetSimulation.Name = "btnResetSimulation";
            this.btnResetSimulation.Size = new System.Drawing.Size(270, 29);
            this.btnResetSimulation.TabIndex = 60;
            this.btnResetSimulation.Text = "Reset Simulation";
            this.btnResetSimulation.UseVisualStyleBackColor = true;
            // 
            // btnD
            // 
            this.btnD.BackColor = System.Drawing.Color.Green;
            this.btnD.ForeColor = System.Drawing.SystemColors.Control;
            this.btnD.Location = new System.Drawing.Point(43, 356);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(270, 29);
            this.btnD.TabIndex = 59;
            this.btnD.Text = "Person D Booking";
            this.btnD.UseVisualStyleBackColor = false;
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.Red;
            this.btnC.ForeColor = System.Drawing.SystemColors.Control;
            this.btnC.Location = new System.Drawing.Point(43, 306);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(270, 29);
            this.btnC.TabIndex = 58;
            this.btnC.Text = "Person C Booking";
            this.btnC.UseVisualStyleBackColor = false;
            // 
            // btnB
            // 
            this.btnB.BackColor = System.Drawing.Color.Blue;
            this.btnB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnB.Location = new System.Drawing.Point(43, 259);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(270, 29);
            this.btnB.TabIndex = 57;
            this.btnB.Text = "Person B Booking";
            this.btnB.UseVisualStyleBackColor = false;
            // 
            // btnSeatLayout
            // 
            this.btnSeatLayout.Location = new System.Drawing.Point(43, 165);
            this.btnSeatLayout.Name = "btnSeatLayout";
            this.btnSeatLayout.Size = new System.Drawing.Size(270, 29);
            this.btnSeatLayout.TabIndex = 53;
            this.btnSeatLayout.Text = "Setup Cinema Seat Layout";
            this.btnSeatLayout.UseVisualStyleBackColor = true;
            this.btnSeatLayout.Click += new System.EventHandler(this.btnSeatLayout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Column";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Row";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(201, 37);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 29);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(52, 37);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(108, 29);
            this.btnLoad.TabIndex = 43;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // numRow
            // 
            this.numRow.Location = new System.Drawing.Point(163, 87);
            this.numRow.Name = "numRow";
            this.numRow.Size = new System.Drawing.Size(150, 27);
            this.numRow.TabIndex = 64;
            // 
            // numCol
            // 
            this.numCol.Location = new System.Drawing.Point(163, 120);
            this.numCol.Name = "numCol";
            this.numCol.Size = new System.Drawing.Size(150, 27);
            this.numCol.TabIndex = 65;
            // 
            // panelSeats
            // 
            this.panelSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeats.Controls.Add(this.textBox1);
            this.panelSeats.Location = new System.Drawing.Point(319, 12);
            this.panelSeats.Name = "panelSeats";
            this.panelSeats.Size = new System.Drawing.Size(1042, 1031);
            this.panelSeats.TabIndex = 66;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Location = new System.Drawing.Point(283, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(573, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Screen";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tnDisableAll);
            this.groupBox1.Controls.Add(this.btnEnableAll);
            this.groupBox1.Controls.Add(this.Disable);
            this.groupBox1.Controls.Add(this.rbEnable);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(52, 439);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 195);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(28, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enter Editor Mode";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // rbEnable
            // 
            this.rbEnable.AutoSize = true;
            this.rbEnable.Enabled = false;
            this.rbEnable.Location = new System.Drawing.Point(42, 73);
            this.rbEnable.Name = "rbEnable";
            this.rbEnable.Size = new System.Drawing.Size(75, 24);
            this.rbEnable.TabIndex = 1;
            this.rbEnable.TabStop = true;
            this.rbEnable.Text = "Enable";
            this.rbEnable.UseVisualStyleBackColor = true;
            // 
            // Disable
            // 
            this.Disable.AutoSize = true;
            this.Disable.Enabled = false;
            this.Disable.Location = new System.Drawing.Point(140, 73);
            this.Disable.Name = "Disable";
            this.Disable.Size = new System.Drawing.Size(80, 24);
            this.Disable.TabIndex = 2;
            this.Disable.TabStop = true;
            this.Disable.Text = "Disable";
            this.Disable.UseVisualStyleBackColor = true;
            // 
            // btnEnableAll
            // 
            this.btnEnableAll.Enabled = false;
            this.btnEnableAll.Location = new System.Drawing.Point(17, 120);
            this.btnEnableAll.Name = "btnEnableAll";
            this.btnEnableAll.Size = new System.Drawing.Size(91, 29);
            this.btnEnableAll.TabIndex = 3;
            this.btnEnableAll.Text = "Enable All";
            this.btnEnableAll.UseVisualStyleBackColor = true;
            // 
            // tnDisableAll
            // 
            this.tnDisableAll.Enabled = false;
            this.tnDisableAll.Location = new System.Drawing.Point(140, 120);
            this.tnDisableAll.Name = "tnDisableAll";
            this.tnDisableAll.Size = new System.Drawing.Size(91, 29);
            this.tnDisableAll.TabIndex = 4;
            this.tnDisableAll.Text = "Disable All";
            this.tnDisableAll.UseVisualStyleBackColor = true;
            // 
            // safe_distance_smart_mode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 1055);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelSeats);
            this.Controls.Add(this.numCol);
            this.Controls.Add(this.numRow);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.btnResetSimulation);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnSeatLayout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Name = "safe_distance_smart_mode";
            this.Text = "safe_distance_smart_mode";
            ((System.ComponentModel.ISupportInitialize)(this.numRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCol)).EndInit();
            this.panelSeats.ResumeLayout(false);
            this.panelSeats.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button btnResetSimulation;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnSeatLayout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.NumericUpDown numRow;
        private System.Windows.Forms.NumericUpDown numCol;
        private System.Windows.Forms.Panel panelSeats;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button tnDisableAll;
        private System.Windows.Forms.Button btnEnableAll;
        private System.Windows.Forms.RadioButton Disable;
        private System.Windows.Forms.RadioButton rbEnable;
        private System.Windows.Forms.Button button1;
    }
}