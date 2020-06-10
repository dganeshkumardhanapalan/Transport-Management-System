using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BUS.Windows.Forms
{
    public class WeekRow : DataGridViewRow
    {
        public WeekRow()
        {
            this.HeaderCell = new WeekRowHeaderCell();
        }

        public Calendar Calendar
        {
            get { return this.DataGridView as Calendar; }
        }

        public DateTime StartTime
        {
            get
            {
                return Calendar.StartTime.AddDays(7 * this.Index);
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this.StartTime.AddDays(7);
            }
        }
    }

    public class WeekRowHeaderCell : DataGridViewRowHeaderCell
    {

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            Rectangle insideRect = new Rectangle(cellBounds.Left, cellBounds.Top + 1, cellBounds.Width - 2, cellBounds.Height - 3);
            if ((paintParts & DataGridViewPaintParts.Background) != DataGridViewPaintParts.None)
            {
                using (LinearGradientBrush lgb = new LinearGradientBrush(cellBounds,
                        CalendarColors.HeaderCellBackColorLight, CalendarColors.HeaderCellBackColorDark, LinearGradientMode.Horizontal))
                {
                    graphics.FillRectangle(lgb, cellBounds);
                }
            }

            if ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None)
            {
                using (Pen p = new Pen(CalendarColors.HeaderCellInnerBorderColor))
                {
                    graphics.DrawLine(p, cellBounds.Left + 1, cellBounds.Top, cellBounds.Left + 1, cellBounds.Bottom - 1);
                    graphics.DrawLine(p, cellBounds.Right - 2, cellBounds.Top, cellBounds.Right - 2, cellBounds.Bottom - 1);
                    
                    if (rowIndex == 0)
                        graphics.DrawLine(p, cellBounds.Left +1, cellBounds.Top, cellBounds.Right - 2, cellBounds.Top);
                }

                using (Pen p = new Pen(CalendarColors.HeaderCellBorderColor))
                {
                    graphics.DrawLine(p, cellBounds.Left, cellBounds.Top, cellBounds.Left, cellBounds.Bottom - 1);
                    graphics.DrawLine(p, cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom - 1);
                    graphics.DrawLine(p, cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right - 1, cellBounds.Bottom - 1);
                }
            }

            if ((paintParts & DataGridViewPaintParts.ContentForeground) != DataGridViewPaintParts.None)
            {
                string text = formattedValue as string;
                TextFormatFlags tf = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

                TextRenderer.DrawText(graphics, text, cellStyle.Font, insideRect, cellStyle.ForeColor, tf);
            }
        }
    }
}
