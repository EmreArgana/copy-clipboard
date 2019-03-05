using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Bunifu.Framework.UI;
using BunifuAnimatorNS;

namespace WindowsFormsApp1
{
    public class CreatePanel
    {
        public static Panel GetPanel(FlowLayoutPanel flowLayoutPanel, string text, int panelSizeW, int panelSizeH, int panelX, int panelY)
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

            flowLayoutPanel.Controls.Add(panel);
            flowLayoutPanel.Controls.SetChildIndex(panel, 0);

            return panel;
        }

        public static BunifuCards GetBunifuPanel(FlowLayoutPanel flowLayoutPanel, string text, int panelSizeW, int panelSizeH, int sayi1)
        {
            var Cards = new BunifuCards();
            var MaterialTextbox = new BunifuMaterialTextbox();

            Cards.BackColor = Color.White;
            Cards.BorderRadius = 20;
            Cards.BottomSahddow = true;
            if (sayi1 % 2 == 0)
            {
                Cards.color = Color.Aquamarine;
            }
            else
            {
                Cards.color = Color.Turquoise;
            }
            Cards.Controls.Add(MaterialTextbox);// Cards in içine materialtextbox i ekle
            Cards.LeftSahddow = false;
            Cards.Location = new Point(0, 0);
            Cards.Name = "bunifuCards1";
            Cards.RightSahddow = true;
            Cards.ShadowDepth = 20;
            Cards.Size = new Size(panelSizeW, panelSizeH);//300, 300
            Cards.TabIndex = 0;

            MaterialTextbox.AutoCompleteMode = AutoCompleteMode.None;
            MaterialTextbox.AutoCompleteSource = AutoCompleteSource.None;
            MaterialTextbox.characterCasing = CharacterCasing.Normal;
            MaterialTextbox.Cursor = Cursors.IBeam;
            MaterialTextbox.Font = new Font("Microsoft Sans Serif", 9.75F);
            MaterialTextbox.HintForeColor = Color.Empty;
            MaterialTextbox.HintText = "";
            MaterialTextbox.isPassword = false;
            MaterialTextbox.LineFocusedColor = Color.CornflowerBlue;
            MaterialTextbox.LineIdleColor = Color.SkyBlue;
            MaterialTextbox.LineMouseHoverColor = Color.CornflowerBlue;
            MaterialTextbox.LineThickness = 3;
            MaterialTextbox.Location = new Point(0, 0);
            MaterialTextbox.Margin = new Padding(4);
            MaterialTextbox.MaxLength = 32767;
            MaterialTextbox.Name = "bunifuMaterialTextbox1";
            MaterialTextbox.Size = new Size(292, 202);
            MaterialTextbox.TabIndex = 1;
            MaterialTextbox.Text = text;// Textbox ta gözükmesi gereken yazı
            MaterialTextbox.TextAlign = HorizontalAlignment.Left;




            flowLayoutPanel.Controls.Add(Cards);
            flowLayoutPanel.Controls.SetChildIndex(Cards, 0);





            return Cards;
        }

    }
}