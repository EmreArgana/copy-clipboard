using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class CreatePanel
    {
        public static Panel GetPanel(Form form, string text,int panelSizeW,int panelSizeH,int panelX,int panelY)
        {
            var panel = new Panel();
            panel.Size = new Size(panelSizeW, panelSizeH);
            panel.Location = new Point(panelX, panelY);
            panel.BackColor = Color.Gray;
            
            var textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Size = new Size(244, 100);
            textBox.Location = new Point(0, 0);
            textBox.Text = text;
            panel.Controls.Add(textBox);
            form.Controls.Add(panel);

            return panel;
        }
    }
}
