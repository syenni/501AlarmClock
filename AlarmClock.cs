using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _501AlarmClock
{
    public partial class AlarmClock : Form
    {
        System.Timers.Timer timer;
        BindingList<AddEditAlarm> alarmList = new BindingList<AddEditAlarm>(); //will need to be set to file loaded in of existing alarms

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
        }

        private void AlarmClock_Load(object sender, EventArgs e)
        {
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
        }

        private void BtnSnooze_Click(object sender, EventArgs e)
        {

        }

        private void BtnStop_Click(object sender, EventArgs e)
        {

        }
    }
}
