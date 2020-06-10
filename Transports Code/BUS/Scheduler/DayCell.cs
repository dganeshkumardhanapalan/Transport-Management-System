using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BUS.Windows.Forms
{
    public class DayCell : DataGridViewCell
    {
        public Calendar Calendar
        {
            get { return this.DataGridView as Calendar; }
        }

        public override Type FormattedValueType
        {
            get { return typeof(string); }
        }

        public DateTime StartTime
        {
            get
            {
                WeekRow r = this.OwningRow as WeekRow;
                return r.StartTime.AddDays(this.ColumnIndex);
            }
        }

        public DateTime EndTime
        {
            get { return this.StartTime.AddDays(1); }
        }


        IEnumerable<Appointment> CalendarEvents
        {
            get
            {
                List<Appointment> selected = new List<Appointment>();
                foreach (Appointment calendarEvent in this.Calendar.CalendarEvents)
                {
                    if (calendarEvent.StartTime >= this.StartTime && calendarEvent.EndTime < this.EndTime)
                    {
                        selected.Add(calendarEvent);
                    }
                }
                return selected;
            }
        }

        const int HeaderHeight = 20;
        const int AppointmentHeight = 19;
        const int AppointmentVMargin = 2;
        const int AppointmentHMargin = 3;

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            Color backColor;
            Color borderColor;
            if (this.StartTime.Month == Calendar.CurrentDate.Month)
            {
                backColor = CalendarColors.DayCellCurrentMonthBackColor;
                borderColor = CalendarColors.DayCellCurrentMonthBorderColor;
            }
            else
            {
                backColor = CalendarColors.DayCellOtherMonthBackColor;
                borderColor = CalendarColors.DayCellOtherMonthBorderColor;
            }

            if ((paintParts & DataGridViewPaintParts.Background) != DataGridViewPaintParts.None)
            {
                using(Brush b = new SolidBrush(backColor))
                {
                    graphics.FillRectangle(b, cellBounds);
                }
            }

            if ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None)
            {
                using(Pen p = new Pen(borderColor))
                {
                    graphics.DrawLine(p, cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right - 1, cellBounds.Bottom - 1);
                    graphics.DrawLine(p, cellBounds.Right-1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom - 1);
                }
            }

            if ((paintParts & DataGridViewPaintParts.ContentForeground) != DataGridViewPaintParts.None)
            {
                PaintHeader(graphics, cellBounds, rowIndex, cellState, cellStyle);

                int appointmentIndex = 0;
                foreach (Appointment appointment in this.CalendarEvents)
                {
                    Rectangle appointmentBounds = GetAppointmentBounds(appointmentIndex++, cellBounds.Size);
                    appointmentBounds.Offset(cellBounds.Location);

                    if (appointmentBounds.Bottom + 8 + AppointmentVMargin < cellBounds.Bottom)
                    {
                        PaintAppointment(appointment, appointmentBounds,
                            graphics, cellBounds, cellState, cellStyle);
                    }
                    else
                    {
                        PaintOverflowIndicator(graphics, cellBounds, cellState, cellStyle);
                    }
                }
            }
        }

        void PaintHeader(System.Drawing.Graphics graphics, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, DataGridViewCellStyle cellStyle)
        {
            Rectangle headerRect = new Rectangle(cellBounds.Left, cellBounds.Top, cellBounds.Width - 1, Math.Min(HeaderHeight, cellBounds.Height - 1));
            if (headerRect.IsEmpty)
                return;

            Color foreColor = Style.ForeColor;

            if ((cellState & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
            {
                using (Brush b = new SolidBrush(cellStyle.SelectionBackColor))
                {
                    graphics.FillRectangle(b, headerRect);
                }
                foreColor = cellStyle.SelectionForeColor;
            }
            else if (this.StartTime.Date == DateTime.Today)
            {
                using (LinearGradientBrush lgb = new LinearGradientBrush(headerRect,
                    CalendarColors.DayCellCurrentMonthBackColor, CalendarColors.DayCellTodayBackColorDark, LinearGradientMode.Vertical))
                {
                    graphics.FillRectangle(lgb, headerRect);
                }

            }

            if (this.StartTime.Date == DateTime.Today)
            {
                using (Pen p = new Pen(CalendarColors.DayCellTodayBorderColor))
                {
                    graphics.DrawLine(p, headerRect.Left, headerRect.Bottom, headerRect.Right - 1, headerRect.Bottom);
                }
            }

            string headerText;
            if (this.StartTime.Day == 1 || (rowIndex == 0 && this.ColumnIndex == 0))
                headerText = this.StartTime.ToString("M");
            else
                headerText = this.StartTime.Day.ToString();


            TextFormatFlags tf = TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
            TextRenderer.DrawText(graphics, headerText, cellStyle.Font, headerRect, foreColor, tf);

        }

        void PaintAppointment(Appointment appointment, Rectangle appointmentBounds, 
            Graphics graphics, Rectangle cellBounds, DataGridViewElementStates cellState, DataGridViewCellStyle cellStyle)
        {
            if (appointmentBounds.IsEmpty)
                return;

            using (SolidBrush b = new SolidBrush(appointment.BackColor))
            {
                graphics.FillRectangle(b, appointmentBounds);
            }

            float width = (appointment == Calendar.SelectedAppointment) ? 2f : 1f;
            using (Pen p = new Pen(CalendarColors.HeaderCellBorderColor, width))
            {
                graphics.DrawRectangle(p, appointmentBounds);
            }

            if (!String.IsNullOrEmpty(appointment.Text))
            {
                appointmentBounds.Inflate(-1, -1);
                TextFormatFlags tf = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
                TextRenderer.DrawText(graphics, appointment.Text, cellStyle.Font, appointmentBounds, cellStyle.ForeColor, tf);

            }
        }

        private static Rectangle GetAppointmentBounds(int appointmentIndex, Size cellSize)
        {
            Rectangle appointmentBounds = new Rectangle(AppointmentHMargin,
                (HeaderHeight + 1 + AppointmentVMargin) + (appointmentIndex * (AppointmentHeight + AppointmentVMargin)),
                cellSize.Width - 1 - AppointmentHMargin * 2, AppointmentHeight);

            return appointmentBounds;
        }

        private void PaintOverflowIndicator(Graphics graphics, Rectangle cellBounds, DataGridViewElementStates cellState, DataGridViewCellStyle cellStyle)
        {
            Rectangle indicatorBounds = new Rectangle(0, 0, 20, 8);

            graphics.TranslateTransform(cellBounds.Right - indicatorBounds.Width - 1,
                cellBounds.Bottom - indicatorBounds.Height - 1);

            using (Brush b = new HatchBrush(HatchStyle.Percent25, Color.Yellow, Color.White))
            {
                graphics.FillRectangle(b, indicatorBounds);
            }

            graphics.FillPolygon(Brushes.Black,
                new Point[] { new Point(2, 2), new Point(9, 2), new Point(5, 6) });

            for (int i = 0; i < 3; i++)
			{
                graphics.FillRectangle(Brushes.Black, new Rectangle(11 + i * 3, 2, 2, 2)); 
			}

            graphics.DrawRectangle(Pens.Black, indicatorBounds);

            graphics.ResetTransform();
        }

        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseDown(e);

            int eventIndex = 0;
            foreach (Appointment calendarEvent in this.CalendarEvents)
            {
              //  Rectangle cellBounds = this.Calendar.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Rectangle eventBounds = GetAppointmentBounds(eventIndex, this.Size);
                if (eventBounds.Contains(e.Location))
                {
                    //TODO: move this to SelectedAppointment handling. 
                    //the previous cell need also be redrawn
                    this.Calendar.SelectedAppointment = calendarEvent;
                    this.DataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);
                    break;
                }
                eventIndex++;
            }
        }


    }
}
