using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambar.Utils
{
    class GradientPanel : Panel
    {
        public Color first { get; set; }
        public Color second { get; set; }
        public float angle { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.first, this.second, this.angle);
                Graphics g = e.Graphics;
                g.FillRectangle(lgb, this.ClientRectangle);
                base.OnPaint(e);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
