using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _501AlarmClock
{
    /// <summary>
    /// Definitions for the AlarmClock class
    /// </summary>
    public partial class AlarmClock : Form
    {
        /// <summary>
        /// List of alarms used
        /// </summary>
        BindingList<AddEditAlarm> alarmList = new BindingList<AddEditAlarm>();

        /// <summary>
        /// Defualt Constructor
        /// </summary>
        public AlarmClock()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            AddEditAlarm addEditAlarm = new AddEditAlarm();
            if (index >= 0)
            {
                if (addEditAlarm.ShowDialog() == DialogResult.OK)
                {
                    alarmList[index] = addEditAlarm;
                    listBox.Items[index] = addEditAlarm.ToString();
                }
                WriteAlarms();
            }
        }

        private void AlarmClock_Load(object sender, EventArgs e)
        {
            LoadAlarms();
        }

        private async void CreateAlarmDelay()
        {
            foreach (AddEditAlarm alarm in alarmList)
            {
                if (alarm.On)
                {
                    TimeSpan ts = alarm.Alarm.Subtract(DateTime.Now);
                    if (ts.TotalMilliseconds > 0)
                    {
                        await PutTaskDelay((int)ts.TotalMilliseconds);
                        btnSnooze.Enabled = true;
                        btnStop.Enabled = true;
                        lblStatus.Visible = true;
                    }
                }
            }
        }

        private void BtnAddAlarm_Click(object sender, EventArgs e)
        {
            AddEditAlarm addEditAlarm = new AddEditAlarm();
            if (addEditAlarm.ShowDialog() == DialogResult.OK)
            {
                alarmList.Add(addEditAlarm);
                listBox.Items.Add(addEditAlarm.ToString());
            }
            WriteAlarms();
        }

        private async void BtnSnooze_Click(object sender, EventArgs e)
        {
            btnSnooze.Enabled = false;
            btnStop.Enabled = false;
            if (lblStatus.Visible)
            {
                lblStatus.Visible = false;
                await PutTaskDelay(30000); //30 second snooze
                lblStatus.Visible = true;
                btnSnooze.Enabled = true;
                btnStop.Enabled = true;
            }
        }

        private async Task PutTaskDelay(int ms)
        {
            await Task.Delay(ms);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            btnStop.Enabled = false;
            btnSnooze.Enabled = false;
        }

        private void WriteAlarms()
        {
            using (StreamWriter file = new StreamWriter("alarms.txt"))
            {
                foreach (AddEditAlarm alarm in alarmList)
                {
                    file.WriteLine(alarm.Alarm.ToString());
                }
            }
            using (StreamWriter file = new StreamWriter("alarmsOnOff.txt")) //Absolute path - @"C:\Users\sethyenni\Documents\501AlarmClock\alarmsOnOff.txt"
            {
                foreach (AddEditAlarm alarm in alarmList)
                {
                    file.WriteLine(alarm.On.ToString());
                }
            }
            CreateAlarmDelay();
        }

        private void LoadAlarms()
        {
            BindingList<DateTime> alarms = new BindingList<DateTime>();
            BindingList<bool> alarmsOnOff = new BindingList<bool>();
            using (StreamReader file = new StreamReader("alarms.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    alarms.Add(Convert.ToDateTime(line));
                }
            }
            using (StreamReader file = new StreamReader("alarmsOnOff.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    alarmsOnOff.Add(Convert.ToBoolean(line));
                }
            }
            for(int i = 0; i < alarms.Count; i++)
            {
                AddEditAlarm alarm = new AddEditAlarm(alarms[i], alarmsOnOff[i]);
                alarmList.Add(alarm);
                listBox.Items.Add(alarm.ToString());
            }
            CreateAlarmDelay();
        }
    }
}