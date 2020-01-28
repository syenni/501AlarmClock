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
        BindingList<DateTime> alarmList = new BindingList<DateTime>(); //will need to be set to file loaded in of existing alarms

        public AlarmClock()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void AlarmClock_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //DateTime currentTime = DateTime.Now;
            //DateTime enteredTime = DateTimePicker.Value;
            //if (currentTime.Hour == enteredTime.Hour && currentTime.Minute == enteredTime.Minute && currentTime.Second == enteredTime.Second)
            //{
            //    timer.Stop();
            //    lblStatus.Enabled = true;
            //}
        }

        private void BtnAddAlarm_Click(object sender, EventArgs e)
        {
            AddEditAlarm addEditAlarm = new AddEditAlarm();
            if (addEditAlarm.ShowDialog() == DialogResult.OK)
            {
                DateTime newAlarm = addEditAlarm.Alarm;
                string alarmString = newAlarm.Hour.ToString() + newAlarm.Minute.ToString();
                alarmList.Add(newAlarm);
                listBox.DataSource = alarmList;
                listBox.DisplayMember = alarmString;
            }
                
            

        }
    }
}
