using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoltFramework.WinForms
{
    public class ApplicationManager
    {
        public ThemeManager ThemeManager;
        private Form Form;

        public ApplicationManager(Form form)
        {
            Form = form;
            ThemeManager = new ThemeManager();
        }
    }
}
