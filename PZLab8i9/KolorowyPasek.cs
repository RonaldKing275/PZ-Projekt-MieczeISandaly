using System;
using System.Collections.Generic;
using System.Text;
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

        // Wymuszamy natychmiastowe przerysowanie, gdy wartość się zmienia
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Value
        {
            get => base.Value;
            set { base.Value = value; this.Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Maximum
        {
            get => base.Maximum;
            set { base.Maximum = value; this.Invalidate(); }
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
