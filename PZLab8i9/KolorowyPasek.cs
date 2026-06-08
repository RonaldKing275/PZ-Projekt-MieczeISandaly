using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace PZLab8i9
{
    public class KolorowyPasek : ProgressBar
    {
        public KolorowyPasek()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Maximum
        {
            get => base.Maximum;
            set
            {
                if (value < 0) value = 1;

                if (base.Value > value) base.Value = value;

                base.Maximum = value;
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Value
        {
            get => base.Value;
            set
            {
                if (value < 0) value = 0;

                if (value > base.Maximum) base.Maximum = value;

                base.Value = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = this.ClientRectangle;

            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, rec.Width, rec.Height);

            if (this.Maximum > 0)
            {
                int width = (int)((double)rec.Width * ((double)this.Value / this.Maximum));

                if (this.Value > 0 && width == 0)
                {
                    width = 1;
                }

                Rectangle pasek = new Rectangle(0, 0, width, rec.Height);
                e.Graphics.FillRectangle(new SolidBrush(this.ForeColor), pasek);
            }
        }
    }
}