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
    /// <summary>
    /// Definitions for the AddEditAlarm class
    /// </summary>
    public partial class AddEditAlarm : Form
    {
        /// <summary>
        /// Property of a DateTime called Alarm
        /// </summary>
        public DateTime Alarm { get; protected set; }
        /// <summary>
        /// Property of a bool to indicate whether an alarm is set to on or off.
        /// </summary>
        public bool On { get; protected set; }

        /// <summary>
        /// Default Construtor for an instance of this class
        /// </summary>
        public AddEditAlarm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for when a defined alarm and on/off indicator is passed in
        /// </summary>
        /// <param name="alarm"></param>
        /// <param name="onOff"></param>
        public AddEditAlarm(DateTime alarm, bool onOff)
        {
            InitializeComponent();
            Alarm = alarm;
            On = onOff;
        }

        /// <summary>
        /// Event handler for when the cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event handler for when the set button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSet_Click(object sender, EventArgs e)
        {
            Alarm = dateTimePicker.Value;
            if (rbnOn.Checked)
                On = true;
            else
                On = false;
        }

        /// <summary>
        /// Override method of ToString() to format an instance of this class to print an alarm in the listbox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string on = "";
            string minute = "";
            string hour = "";
            string amPM = "";
            int numHour = Alarm.Hour;
            if (On) on = "On"; else on = "Off";
            if (Alarm.Minute == 0)
                minute = "00";
            else if
                (Alarm.Minute < 10) minute = "0" + Alarm.Minute.ToString();
            else
                minute = Alarm.Minute.ToString();
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

        /// <summary>
        /// Event handler for when this class is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditAlarm_Load(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now;
        }
    }
}
