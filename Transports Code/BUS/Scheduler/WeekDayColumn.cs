using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BUS.Windows.Forms
{
    public class WeekDayColumn : DataGridViewColumn
    {
        public WeekDayColumn()
        {
            this.CellTemplate = new DayCell();
            this.HeaderCell = new WeekDayColumnHeader();
            this.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }

    public class WeekDayColumnHeader : DataGridViewColumnHeaderCell
    {

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            Rectangle insideRect = new Rectangle(cellBounds.Left, cellBounds.Top + 1, cellBounds.Width - 2, cellBounds.Height - 3);

            if ((paintParts & DataGridViewPaintParts.Background) != DataGridViewPaintParts.None)
            {
                using (LinearGradientBrush lgb = new LinearGradientBrush(cellBounds,
                        CalendarColors.HeaderCellBackColorLight, CalendarColors.HeaderCellBackColorDark, LinearGradientMode.Vertical))
                {
                    graphics.FillRectangle(lgb, cellBounds);
                }
            }

            if ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None)
            {
                using (Pen p = new Pen(CalendarColors.HeaderCellInnerBorderColor))
                {
                    graphics.DrawRectangle(p, insideRect);
                }

                using (Pen p = new Pen(CalendarColors.HeaderCellBorderColor))
                {
                    graphics.DrawLine(p, cellBounds.Left, cellBounds.Top, cellBounds.Right, cellBounds.Top);
                    graphics.DrawLine(p, cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom);
                    graphics.DrawLine(p, cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1);
                }
            }

            if ((paintParts & DataGridViewPaintParts.ContentForeground) != DataGridViewPaintParts.None)
            {
                string text = formattedValue as string;
                TextFormatFlags tf = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;

                TextRenderer.DrawText(graphics, text, cellStyle.Font, insideRect, cellStyle.ForeColor, tf);
            }
        }
    }

    public class RoundTopLeftHeaderCell : DataGridViewColumnHeaderCell
    {

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            GraphicsPath path = CreateRoundCornerPath(cellBounds);
            Rectangle insideRect = new Rectangle(cellBounds.Left+1, cellBounds.Top + 1, cellBounds.Width - 2, cellBounds.Height - 2);
            GraphicsPath insidePath = CreateRoundCornerPath(insideRect);

            using (SolidBrush b = new SolidBrush(cellStyle.BackColor))
            {
                graphics.FillRectangle(b, cellBounds);
            }

            SmoothingMode lastMode = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (LinearGradientBrush lgb = new LinearGradientBrush(cellBounds,
                CalendarColors.HeaderCellBackColorLight, CalendarColors.HeaderCellBackColorDark, LinearGradientMode.ForwardDiagonal))
            {
                graphics.FillPath(lgb, path);
            }

            if ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None)
            {
                using (Pen p = new Pen(CalendarColors.HeaderCellInnerBorderColor))
                {
                    graphics.DrawPath(p, insidePath);
                }

                using (Pen p = new Pen(CalendarColors.HeaderCellBorderColor))
                {
                    graphics.DrawPath(p, path);
                }
            }

            graphics.SmoothingMode = lastMode;

        }

        private static GraphicsPath CreateRoundCornerPath(System.Drawing.Rectangle bounds)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLines(new Point[] {
                new Point(bounds.Left, bounds.Bottom - 1),
                new Point(bounds.Right - 1, bounds.Bottom - 1),
                new Point(bounds.Right - 1, bounds.Top)});


            path.AddArc(bounds.Left, bounds.Top, 10, 10, -90, -90);
            path.CloseAllFigures();
            return path;
        }
    }
}
