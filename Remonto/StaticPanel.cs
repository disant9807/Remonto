using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo4ka7
{
    public static class StaticPanel
    {
        public static void panelNaMesto(bool usloviem, Panel panel, Label text, string str)
        {
            text.Visible = true;
            if (usloviem == true)
            {
                panel.Visible = true;
                text.Text = str;
            }
            else if (usloviem == false)
            {
                panel.Visible = false;
                text.Text = "-";
            }
        }
    }
}
