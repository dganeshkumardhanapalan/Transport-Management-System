using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BUS.Windows.Forms
{
    [System.ComponentModel.DesignerCategory("code")]
    public class Calendar : DataGridView
    {
        public Calendar()
        {
            this.BorderStyle = BorderStyle.None;
            this.ReadOnly = true;
            this.AllowUserToAddRows = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToResizeRows = true;
            this.AllowUserToResizeColumns = true;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            InitializeDisplay();

            _calendarEvents = new AppointmentCollection(this);
        }

        private AppointmentCollection _calendarEvents;
        public AppointmentCollection CalendarEvents
        {
            get { return _calendarEvents; }
        }


        private DateTime _startDate;

        [Browsable(false)]
        public DateTime StartTime
        {
            get { return _startDate; }
            private set { _startDate = value; }
        }

        private DateTime _endDate;

        [Browsable(false)]
        public DateTime EndTime
        {
            get { return _endDate; }
            private set { _endDate = value; }
        }

        private DateTime _currentDate = DateTime.Today;

        [Category("Calendar")]
        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value;
            InitializeDisplay();
            }
        }

        private Appointment _selectedAppointment;

        [Browsable(false)]
        public Appointment SelectedAppointment
        {
            get { return _selectedAppointment; }
            set { _selectedAppointment = value; }
        }

        private CalendarWeekRule _weekNumberRule = CalendarWeekRule.FirstFullWeek;

        [Category("Calendar")]
        public CalendarWeekRule WeekNumberRule
        {
            get { return _weekNumberRule; }
            set { _weekNumberRule = value; }
        }

        private DayOfWeek _firstDayOfWeek = DayOfWeek.Monday;

        [Category("Calendar")]
        public DayOfWeek FirstDayOfWeek
        {
            get { return _firstDayOfWeek; }
            set { _firstDayOfWeek = value; }
        }

        private void InitializeDisplay()
        {
            if (this.ColumnCount > 0)
                this.Columns.Clear();

            this.MultiSelect = false;
            this.RowHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular);
            this.RowHeadersDefaultCellStyle.ForeColor = CalendarColors.HeaderCellForeColor;

            this.RowHeadersVisible = true;
            this.ColumnHeadersVisible = true;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            this.TopLeftHeaderCell = new RoundTopLeftHeaderCell();
            this.ColumnHeadersHeight = 22;

            for (int i = 0; i < 7; i++)
            {
                WeekDayColumn c = new WeekDayColumn();
                c.DisplayIndex = i;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //TODO: correct for FirstDayOfWeek
                c.HeaderCell.Value = CultureInfo.CurrentUICulture.DateTimeFormat.GetDayName((DayOfWeek)((i + 1) % 7));
                this.Columns.Add(c);
            }

            DateTime date = CurrentDate;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            this.StartTime = firstDayOfMonth.AddDays(-GetDayOfWeekNumber(firstDayOfMonth.DayOfWeek));

            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, 
                CultureInfo.CurrentUICulture.Calendar.GetDaysInMonth(date.Year, date.Month));
            this.EndTime = lastDayOfMonth.AddDays(6 - GetDayOfWeekNumber(lastDayOfMonth.DayOfWeek));

            this.RowTemplate = new WeekRow();
            this.RowCount = (int)Math.Ceiling(((TimeSpan)(EndTime - StartTime)).Days / 7.0);

            for (int i = 0; i < this.RowCount; i++)
            {
                this.Rows[i].HeaderCell.Value =
                    CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(this.StartTime.AddDays(i * 7), this.WeekNumberRule, this.FirstDayOfWeek).ToString();
            }
            AutoSizeRows();
        }

        private int GetDayOfWeekNumber(DayOfWeek dayOfWeek)
        {
            if (this.FirstDayOfWeek == DayOfWeek.Sunday)
                return (int)dayOfWeek;
            return ((int)dayOfWeek + (7 - (int)this.FirstDayOfWeek)) % 7;
        }

        protected override void OnResize(EventArgs e)
        {
            AutoSizeRows();
            base.OnResize(e);
        }

        private void AutoSizeRows()
        {
            int[] heights = Allocate(this.Height - this.Columns[0].HeaderCell.Size.Height, this.Rows.Count);
            for (int i = 0; i < this.Rows.Count; i++)
                this.Rows[i].Height = heights[i];
        }

        private static int[] Allocate(int amount, int n)
        {
                        int lowResult = amount / n;
                int highResult = lowResult + 1;
                int[] results = new int[n];
                int reminder = amount % n;
                for (int i = 0; i < reminder; i++)
                    results[i] = highResult;
                for (int i = reminder; i < n; i++)
                    results[i] = lowResult;

                return results;

        }

        internal static void EventPropertyChanged(Appointment calendarEvent)
        {
        }
    }



    public static class CalendarColors
    {
        public static readonly Color HeaderCellBackColorLight = Color.FromArgb(246, 243, 236);
        public static readonly Color HeaderCellBackColorDark = Color.FromArgb(233, 225, 209);
        public static readonly Color HeaderCellBorderColor = Color.FromArgb(140, 116, 100);
        public static readonly Color HeaderCellInnerBorderColor = Color.FromArgb(226, 255, 250, 242);// (251, 249, 246);
        public static readonly Color HeaderCellDividerColor = Color.FromArgb(208, 194, 159);
        public static readonly Color HeaderCellForeColor = Color.FromArgb(157, 133, 111);

        public static readonly Color CalendarFrameColor = Color.FromArgb(234, 208, 152);

        public static readonly Color DayCellOtherMonthBackColor = Color.FromArgb(255, 255, 213);
        public static readonly Color DayCellCurrentMonthBackColor = Color.FromArgb(255, 244, 188);
        public static readonly Color DayCellOtherMonthBorderColor = Color.FromArgb(234, 228, 177);
        public static readonly Color DayCellCurrentMonthBorderColor = Color.FromArgb(234, 208, 152);

        public static readonly Color DayCellTodayBackColorDark = Color.FromArgb(255, 214, 154);
        public static readonly Color DayCellTodayBorderColor = Color.FromArgb(254, 142, 75);
    }
}
