namespace DSAL_CA1_Yr2
{
    partial class normal_mode
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNoOfRow = new System.Windows.Forms.TextBox();
            this.tbSeatsPerRow = new System.Windows.Forms.TextBox();
            this.tbRowDivider = new System.Windows.Forms.TextBox();
            this.tbColumnDivider = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMaxSeat = new System.Windows.Forms.TextBox();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnEndSimulation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisableAll = new System.Windows.Forms.Button();
            this.btnEnableAll = new System.Windows.Forms.Button();
            this.rbDisable = new System.Windows.Forms.RadioButton();
            this.rbEnable = new System.Windows.Forms.RadioButton();
            this.btnEditorMode = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelSeats = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(170, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seats per row";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Row divider (s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Column divider (s)";
            // 
            // tbNoOfRow
            // 
            this.tbNoOfRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNoOfRow.Location = new System.Drawing.Point(157, 76);
            this.tbNoOfRow.Name = "tbNoOfRow";
            this.tbNoOfRow.Size = new System.Drawing.Size(125, 27);
            this.tbNoOfRow.TabIndex = 6;
            // 
            // tbSeatsPerRow
            // 
            this.tbSeatsPerRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSeatsPerRow.Location = new System.Drawing.Point(157, 109);
            this.tbSeatsPerRow.Name = "tbSeatsPerRow";
            this.tbSeatsPerRow.Size = new System.Drawing.Size(125, 27);
            this.tbSeatsPerRow.TabIndex = 7;
            // 
            // tbRowDivider
            // 
            this.tbRowDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRowDivider.Location = new System.Drawing.Point(157, 142);
            this.tbRowDivider.Name = "tbRowDivider";
            this.tbRowDivider.Size = new System.Drawing.Size(125, 27);
            this.tbRowDivider.TabIndex = 8;
            // 
            // tbColumnDivider
            // 
            this.tbColumnDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbColumnDivider.Location = new System.Drawing.Point(157, 175);
            this.tbColumnDivider.Name = "tbColumnDivider";
            this.tbColumnDivider.Size = new System.Drawing.Size(125, 27);
            this.tbColumnDivider.TabIndex = 9;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 224);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(270, 29);
            this.btnGenerate.TabIndex = 10;
            this.btnGenerate.Text = "Generate Seats";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Max seats";
            // 
            // tbMaxSeat
            // 
            this.tbMaxSeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaxSeat.Location = new System.Drawing.Point(157, 266);
            this.tbMaxSeat.Name = "tbMaxSeat";
            this.tbMaxSeat.Size = new System.Drawing.Size(125, 27);
            this.tbMaxSeat.TabIndex = 12;
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.Color.Yellow;
            this.btnA.Location = new System.Drawing.Point(12, 299);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(270, 29);
            this.btnA.TabIndex = 13;
            this.btnA.Text = "Person A Booking";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Click += new System.EventHandler(this.person_Click);
            // 
            // btnB
            // 
            this.btnB.BackColor = System.Drawing.Color.Blue;
            this.btnB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnB.Location = new System.Drawing.Point(12, 345);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(270, 29);
            this.btnB.TabIndex = 14;
            this.btnB.Text = "Person B Booking";
            this.btnB.UseVisualStyleBackColor = false;
            this.btnB.Click += new System.EventHandler(this.person_Click);
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.Red;
            this.btnC.ForeColor = System.Drawing.SystemColors.Control;
            this.btnC.Location = new System.Drawing.Point(12, 392);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(270, 29);
            this.btnC.TabIndex = 15;
            this.btnC.Text = "Person C Booking";
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.Click += new System.EventHandler(this.person_Click);
            // 
            // btnD
            // 
            this.btnD.BackColor = System.Drawing.Color.Green;
            this.btnD.ForeColor = System.Drawing.SystemColors.Control;
            this.btnD.Location = new System.Drawing.Point(12, 442);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(270, 29);
            this.btnD.TabIndex = 16;
            this.btnD.Text = "Person D Booking";
            this.btnD.UseVisualStyleBackColor = false;
            this.btnD.Click += new System.EventHandler(this.person_Click);
            // 
            // btnEndSimulation
            // 
            this.btnEndSimulation.Location = new System.Drawing.Point(12, 491);
            this.btnEndSimulation.Name = "btnEndSimulation";
            this.btnEndSimulation.Size = new System.Drawing.Size(270, 29);
            this.btnEndSimulation.TabIndex = 17;
            this.btnEndSimulation.Text = "End Simulation";
            this.btnEndSimulation.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisableAll);
            this.groupBox1.Controls.Add(this.btnEnableAll);
            this.groupBox1.Controls.Add(this.rbDisable);
            this.groupBox1.Controls.Add(this.rbEnable);
            this.groupBox1.Controls.Add(this.btnEditorMode);
            this.groupBox1.Location = new System.Drawing.Point(12, 545);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 199);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Editor";
            // 
            // btnDisableAll
            // 
            this.btnDisableAll.Location = new System.Drawing.Point(71, 149);
            this.btnDisableAll.Name = "btnDisableAll";
            this.btnDisableAll.Size = new System.Drawing.Size(108, 29);
            this.btnDisableAll.TabIndex = 23;
            this.btnDisableAll.Text = "Disable All";
            this.btnDisableAll.UseVisualStyleBackColor = true;
            // 
            // btnEnableAll
            // 
            this.btnEnableAll.Location = new System.Drawing.Point(71, 102);
            this.btnEnableAll.Name = "btnEnableAll";
            this.btnEnableAll.Size = new System.Drawing.Size(108, 29);
            this.btnEnableAll.TabIndex = 22;
            this.btnEnableAll.Text = "Enable All";
            this.btnEnableAll.UseVisualStyleBackColor = true;
            // 
            // rbDisable
            // 
            this.rbDisable.AutoSize = true;
            this.rbDisable.Location = new System.Drawing.Point(136, 72);
            this.rbDisable.Name = "rbDisable";
            this.rbDisable.Size = new System.Drawing.Size(80, 24);
            this.rbDisable.TabIndex = 21;
            this.rbDisable.TabStop = true;
            this.rbDisable.Text = "Disable";
            this.rbDisable.UseVisualStyleBackColor = true;
            // 
            // rbEnable
            // 
            this.rbEnable.AutoSize = true;
            this.rbEnable.Location = new System.Drawing.Point(33, 72);
            this.rbEnable.Name = "rbEnable";
            this.rbEnable.Size = new System.Drawing.Size(75, 24);
            this.rbEnable.TabIndex = 20;
            this.rbEnable.TabStop = true;
            this.rbEnable.Text = "Enable";
            this.rbEnable.UseVisualStyleBackColor = true;
            // 
            // btnEditorMode
            // 
            this.btnEditorMode.Location = new System.Drawing.Point(33, 37);
            this.btnEditorMode.Name = "btnEditorMode";
            this.btnEditorMode.Size = new System.Drawing.Size(197, 29);
            this.btnEditorMode.TabIndex = 19;
            this.btnEditorMode.Text = "Enter Editor Mode";
            this.btnEditorMode.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(21, 28);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(108, 29);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // labelMessage
            // 
            this.labelMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMessage.Location = new System.Drawing.Point(12, 759);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(270, 155);
            this.labelMessage.TabIndex = 19;
            // 
            // panelSeats
            // 
            this.panelSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeats.Location = new System.Drawing.Point(297, 31);
            this.panelSeats.Name = "panelSeats";
            this.panelSeats.Size = new System.Drawing.Size(1065, 1012);
            this.panelSeats.TabIndex = 20;
            // 
            // normal_mode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 1055);
            this.Controls.Add(this.panelSeats);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEndSimulation);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.tbMaxSeat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbColumnDivider);
            this.Controls.Add(this.tbRowDivider);
            this.Controls.Add(this.tbSeatsPerRow);
            this.Controls.Add(this.tbNoOfRow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Name = "normal_mode";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.normal_mode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNoOfRow;
        private System.Windows.Forms.TextBox tbSeatsPerRow;
        private System.Windows.Forms.TextBox tbRowDivider;
        private System.Windows.Forms.TextBox tbColumnDivider;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMaxSeat;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnEndSimulation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisableAll;
        private System.Windows.Forms.Button btnEnableAll;
        private System.Windows.Forms.RadioButton rbDisable;
        private System.Windows.Forms.RadioButton rbEnable;
        private System.Windows.Forms.Button btnEditorMode;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label labelMessage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelSeats;
    }
}
