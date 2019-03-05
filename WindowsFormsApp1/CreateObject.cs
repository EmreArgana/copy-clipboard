using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using MetroFramework.Controls;

namespace WindowsFormsApp1
{
    public class CreateObject
    {
        /* public static BunifuCards GetBunifuPanel(FlowLayoutPanel flowLayoutPanel, string text, int panelSizeW, int panelSizeH, int sayi1)
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
         }*/

        public static MetroPanel GetMetroTextBox(FlowLayoutPanel flowLayoutPanel, string text, int panelSizeW, int panelSizeH, int sayi1)
        {
            var MetroPanel = new MetroPanel();
            var MetroTile = new MetroTile();
            var MetroTextBox = new MetroTextBox();
            //
            // MetroPanel
            //
            MetroPanel.Controls.Add(MetroTextBox);
            MetroPanel.Controls.Add(MetroTile);
            if (sayi1 % 2 == 0)
            {
                MetroTile.BackColor = Color.Aquamarine;
            }
            else
            {
                MetroTile.BackColor = Color.Turquoise;
            }
            MetroPanel.Location = new System.Drawing.Point(0, 0);
            //MetroPanel.Name = "metroPanel1";
            MetroPanel.Size = new System.Drawing.Size(panelSizeW, panelSizeH);
            MetroPanel.TabIndex = 1;
            //
            // MetroTile
            //
 //           MetroTile.TileCount = sayi1; // DataCount()
            MetroTile.ActiveControl = null;
            MetroTile.Location = new System.Drawing.Point(3, 3);
            //MetroTile.Name = "metroTile1";
            MetroTile.Size = new System.Drawing.Size(294, 76);
            MetroTile.TabIndex = 2;
            MetroTile.Text = "metroTile1";
            MetroTile.UseCustomBackColor = true;
            // 
            // MetroTextBox
            // 
            MetroTextBox.CustomButton.Image = null;
            MetroTextBox.CustomButton.Location = new System.Drawing.Point(272, 1);
            MetroTextBox.CustomButton.Name = "";
            MetroTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            MetroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            MetroTextBox.CustomButton.TabIndex = 1;
            MetroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            MetroTextBox.CustomButton.UseSelectable = true;
            MetroTextBox.Enabled = false;
            MetroTextBox.Lines = new string[] { "metroTextBox1" };
            MetroTextBox.Location = new System.Drawing.Point(3, 85);
            MetroTextBox.MaxLength = 32767;
            MetroTextBox.Multiline = true;
            //MetroTextBox.Name = "metroTextBox1";
            MetroTextBox.PasswordChar = '\0';
            MetroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            MetroTextBox.SelectedText = "";
            MetroTextBox.SelectionLength = 0;
            MetroTextBox.SelectionStart = 0;
            MetroTextBox.ShortcutsEnabled = true;
            MetroTextBox.Size = new System.Drawing.Size(294, 212);
            MetroTextBox.TabIndex = 4;
            MetroTextBox.Text = text;
            MetroTextBox.UseSelectable = true;
            MetroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            MetroTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);

            flowLayoutPanel.Controls.Add(MetroPanel);
            flowLayoutPanel.Controls.SetChildIndex(MetroPanel, 0);

            return MetroPanel;
        }

        public static MetroPanel GetPictureBox(FlowLayoutPanel flowLayoutPanel, Image image, int panelSizeW, int panelSizeH)
        {
            var MetroPanel = new MetroPanel();
            var PictureBox = new PictureBox();
            var MetroTile = new MetroTile();
            //
            // MetroPanel
            //
            MetroPanel.Controls.Add(MetroTile);
            MetroPanel.Controls.Add(PictureBox);
            MetroPanel.Location = new System.Drawing.Point(0, 0);
            //MetroPanel.Name = "metroPanel1";
            MetroPanel.Size = new System.Drawing.Size(panelSizeW, panelSizeH);
            MetroPanel.TabIndex = 1;
            //
            // MetroTile
            //
            MetroTile.ActiveControl = null;
            MetroTile.Location = new System.Drawing.Point(3, 3);
            //MetroTile.Name = "metroTile1";
            MetroTile.Size = new System.Drawing.Size(294, 76);
            MetroTile.TabIndex = 2;
            MetroTile.Text = "metroTile1";
            // 
            // PictureBox
            // 
            PictureBox.Location = new System.Drawing.Point(3, 85);
            //PictureBox.Name = "pictureBox1";
            PictureBox.Size = new System.Drawing.Size(294, 212);
            PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PictureBox.Image = image;
            PictureBox.TabIndex = 2;
            PictureBox.TabStop = false;


            flowLayoutPanel.Controls.Add(MetroPanel);
            flowLayoutPanel.Controls.SetChildIndex(MetroPanel, 0);

            return MetroPanel;
        }
        

    }
}