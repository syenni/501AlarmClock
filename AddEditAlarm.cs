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
        public DateTime Alarm { get; private set; }

        public AddEditAlarm()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            Alarm = dateTimePicker.Value;
        }
    }
}
