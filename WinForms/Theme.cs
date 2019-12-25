using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace VoltFramework.WinForms
{
    public class Theme
    {
        //main
        public Color MainBackColor = Color.White;
        public Color AlterBackColor = Color.FromArgb(100,228, 228, 288);
        public Color MainBorderColor = Color.Gray;
        public Color AlterBorderColor = Color.DarkGray;
        public int BorderThickness = 1;
        public Color MainTextColor = Color.DarkGray;
        public Color AlterTextColor = SystemColors.ControlDarkDark;

        public Theme()
        {

        }

        public void ApplyToControl(Control c)
        {
            c.BackColor = MainBackColor;
            c.ForeColor = MainTextColor;
            if(c is Button)
            {
                ((Button)c).FlatStyle = FlatStyle.Flat;
            }
        }
    }
}
