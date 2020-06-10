using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace BUS.Windows.Forms
{
    public class Appointment
    {
        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private Color _backColor;

        public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        private Calendar _calendar;

        public Calendar Calendar
        {
            get { return _calendar; }
            internal set { _calendar = value; }
        }

        protected void PropertyChanged()
        {
            if (Calendar != null)
                Calendar.EventPropertyChanged(this);
        }
    }

    public class AppointmentCollection : Collection<Appointment>
    {
        internal AppointmentCollection(Calendar calendar)
        {
            _calendar = calendar;
        }

        private Calendar _calendar;
        protected Calendar Calendar
        {
            get { return _calendar; }
        }

        protected override void ClearItems()
        {
            //base.ClearItems();
            base.Items.Clear();
        }

        protected override void InsertItem(int index, Appointment item)
        {
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, Appointment item)
        {
            base.SetItem(index, item);
        }
    }

    public static class NiceColors 
    {
        public static readonly Color Color0 = Color.FromArgb(255, 204, 204);
        public static readonly Color Color1 = Color.FromArgb(166, 202, 240);
        public static readonly Color Color2 = Color.FromArgb(204, 255, 153);
        public static readonly Color Color3 = Color.FromArgb(239, 214, 198);
        public static readonly Color Color4 = Color.FromArgb(255, 204, 153);
        public static readonly Color Color5 = Color.FromArgb(204, 236, 255);
        public static readonly Color Color6 = Color.FromArgb(204, 204, 153);
        public static readonly Color Color7 = Color.FromArgb(221, 221, 221);
        public static readonly Color Color8 = Color.FromArgb(153, 255, 204);
        public static readonly Color Color9 = Color.FromArgb(255, 255, 153);
    }
}
