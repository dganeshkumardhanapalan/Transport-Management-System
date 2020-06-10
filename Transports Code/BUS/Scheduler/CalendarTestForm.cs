using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BUS.Windows.Forms
{
    public partial class CalendarTestForm : Form
    {
        public CalendarTestForm()
        {
            InitializeComponent();
        }


        void CalendarTestForm_Load(object sender, System.EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                Appointment event1 = new Appointment();
                event1.StartTime = calendar1.StartTime.AddDays(rand.Next(this.calendar1.RowCount*7));
                event1.EndTime = event1.StartTime.AddHours(1);
                switch (i%3)
	            {
                    case 0:
                        event1.BackColor = NiceColors.Color0;
                        break;
                    case 1:
                        event1.BackColor = NiceColors.Color1;
                        break;
                    case 2:
                        event1.BackColor = NiceColors.Color2;
                        break;
	            }
                event1.Text = "Lorem ipsum dolor sit amet";
                calendar1.CalendarEvents.Add(event1);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.calendar1.CurrentDate = dateTimePicker1.Value;
        }
    }
}