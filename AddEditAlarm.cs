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
    public partial class AddEditAlarm : Form
    {
        public DateTime Alarm { get; set; }
        public bool On { get; set; }

        public AddEditAlarm()
        {
            InitializeComponent();
        }

        public AddEditAlarm(DateTime alarm, bool onOff)
        {
            InitializeComponent();
            Alarm = alarm;
            On = onOff;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            Alarm = dateTimePicker.Value;
            if (rbnOn.Checked)
                On = true;
            else
                On = false;
        }

        public override string ToString()
        {
            string on = "";
            string minute = "";
            string hour = "";
            string amPM = "";
            int numHour = Alarm.Hour;
            if (On) on = "On"; else on = "Off";
            if (Alarm.Minute == 0) minute = "00"; else minute = Alarm.Minute.ToString();
            if (numHour > 12)
            {
                numHour -= 12;
                hour = numHour.ToString();
                amPM = "PM";
            }
            else
            {
                hour = numHour.ToString();
                amPM = "AM";
            }
            return hour + ":" + minute + " " + amPM + "   " + on;
        }
    }
}
