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
    public partial class AlarmClock : Form
    {
        System.Timers.Timer timer;
        BindingList<AddEditAlarm> alarmList = new BindingList<AddEditAlarm>();

        public AlarmClock()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            AddEditAlarm addEditAlarm = new AddEditAlarm();
            if (addEditAlarm.ShowDialog() == DialogResult.OK)
            {
                alarmList[index] = addEditAlarm;
                listBox.Items[index] = addEditAlarm.ToString();
            }
            WriteAlarms();
        }

        private void AlarmClock_Load(object sender, EventArgs e)
        {
            LoadAlarms();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            foreach(AddEditAlarm thisAlarm in alarmList)
            {
                if (currentTime.Hour == thisAlarm.Alarm.Hour && currentTime.Minute == thisAlarm.Alarm.Minute && currentTime.Second == thisAlarm.Alarm.Second)
                {
                    timer.Stop();
                    lblStatus.Visible = true;
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
            if (lblStatus.Visible)
            {
                lblStatus.Visible = false;
                await PutTaskDelay();
                lblStatus.Visible = true;
            }
        }

        private async Task PutTaskDelay()
        {
            await Task.Delay(30000);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (lblStatus.Visible) lblStatus.Visible = false;
        }

        private void WriteAlarms()
        {
            using (StreamWriter file = new StreamWriter(@"C:\Users\sethyenni\Documents\501AlarmClock\alarms.txt"))
            {
                foreach (AddEditAlarm alarm in alarmList)
                {
                    file.WriteLine(alarm.Alarm.ToString());
                }
            }
            using (StreamWriter file = new StreamWriter(@"C:\Users\sethyenni\Documents\501AlarmClock\alarmsOnOff.txt"))
            {
                foreach (AddEditAlarm alarm in alarmList)
                {
                    file.WriteLine(alarm.On.ToString());
                }
            }
        }

        private void LoadAlarms()
        {
            BindingList<DateTime> alarms = new BindingList<DateTime>();
            BindingList<bool> alarmsOnOff = new BindingList<bool>();
            using (StreamReader file = new StreamReader(@"C:\Users\sethyenni\Documents\501AlarmClock\alarms.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    alarms.Add(Convert.ToDateTime(line));
                }
            }
            using (StreamReader file = new StreamReader(@"C:\Users\sethyenni\Documents\501AlarmClock\alarmsOnOff.txt"))
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
        }
    }
}