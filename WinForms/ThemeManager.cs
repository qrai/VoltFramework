using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoltFramework.WinForms
{
    public class ThemeManager
    {
        public Theme CurrentTheme;

        public ThemeManager()
        {
            CurrentTheme = new Theme();
        }
        public ThemeManager(Theme theme)
        {
            CurrentTheme = theme;
        }
        public void ApplyTheme(Form form)
        {
            foreach(Control c in form.Controls)
            {
                CurrentTheme.ApplyToControl(c);
            }
        }
    }
}
