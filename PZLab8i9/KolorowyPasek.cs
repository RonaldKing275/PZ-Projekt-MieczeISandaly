using System;
using System.Collections.Generic;
using System.Text;

namespace PZLab8i9
{
    public class KolorowyPasek : ProgressBar
    {
        public KolorowyPasek()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, rec.Width, rec.Height);

            if (this.Maximum > 0)
            {
                int width = (int)((double)rec.Width * ((double)this.Value / this.Maximum));
                Rectangle pasek = new Rectangle(0, 0, width, rec.Height);

                e.Graphics.FillRectangle(new SolidBrush(this.ForeColor), pasek);
            }
        }
    }
}
