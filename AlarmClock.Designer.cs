namespace _501AlarmClock
{
    partial class AlarmClock
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddAlarm = new System.Windows.Forms.Button();
            this.btnSnooze = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(39, 22);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 47);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAddAlarm
            // 
            this.btnAddAlarm.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAlarm.Location = new System.Drawing.Point(163, 22);
            this.btnAddAlarm.Name = "btnAddAlarm";
            this.btnAddAlarm.Size = new System.Drawing.Size(98, 47);
            this.btnAddAlarm.TabIndex = 1;
            this.btnAddAlarm.Text = "+";
            this.btnAddAlarm.UseVisualStyleBackColor = true;
            this.btnAddAlarm.Click += new System.EventHandler(this.BtnAddAlarm_Click);
            // 
            // btnSnooze
            // 
            this.btnSnooze.Enabled = false;
            this.btnSnooze.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnooze.Location = new System.Drawing.Point(39, 356);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(98, 47);
            this.btnSnooze.TabIndex = 2;
            this.btnSnooze.Text = "Snooze";
            this.btnSnooze.UseVisualStyleBackColor = true;
            this.btnSnooze.Click += new System.EventHandler(this.BtnSnooze_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(163, 356);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 47);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 18;
            this.listBox.Location = new System.Drawing.Point(27, 95);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(252, 238);
            this.listBox.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Tomato;
            this.lblStatus.Location = new System.Drawing.Point(34, 431);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(245, 31);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Alarm is ringing!";
            this.lblStatus.Visible = false;
            // 
            // AlarmClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 485);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSnooze);
            this.Controls.Add(this.btnAddAlarm);
            this.Controls.Add(this.btnEdit);
            this.Name = "AlarmClock";
            this.Text = "Alarm Clock";
            this.Load += new System.EventHandler(this.AlarmClock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddAlarm;
        private System.Windows.Forms.Button btnSnooze;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label lblStatus;
    }
}

