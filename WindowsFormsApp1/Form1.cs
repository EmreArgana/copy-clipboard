using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        #region Clipboard Text Control
        IntPtr DataClipboard;
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref Message m)
        {
            int WM_DRAWCLIPBOARD = 0x0308;
            int WM_CHANGECBCHAIN = 0x030D;
            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                ReadClipboard();
                SendMessage(DataClipboard, m.Msg, m.WParam, m.LParam);
            }
            else if (m.Msg == WM_CHANGECBCHAIN)
            {
                if (m.WParam == DataClipboard)
                    DataClipboard = m.LParam;
                else
                    SendMessage(DataClipboard, m.Msg, m.WParam, m.LParam);
            }
            base.WndProc(ref m);
        }
        private void ReadClipboard()
        {
            IDataObject dObj = Clipboard.GetDataObject();
            IDataObject dObj2 = Clipboard.GetDataObject();
            IDataObject dObj3 = Clipboard.GetDataObject();
            if (dObj.GetDataPresent(DataFormats.Text))
            {
                textBox1.Text = (string)dObj.GetData(DataFormats.Text);
                DatabaseOperations.AddData((string)dObj.GetData(DataFormats.Text), "Text");
                DatabaseConnection.OpenConnection();
                string stringData = DatabaseOperations.GetData(Convert.ToInt32(comboBox1.SelectedItem), dataGridView1);
                CreatePanel.GetPanel(flowLayoutPanel1, stringData, 250, 200, 0, 0);
                DatabaseConnection.CloseConnection();

            }
            else if (dObj2.GetDataPresent(DataFormats.Bitmap))
            {
                MessageBox.Show("Test");
                pictureBox1.Image = (Image)dObj2.GetData(DataFormats.Bitmap);
            }
        }
        #endregion
        OpenFileDialog ofd = new OpenFileDialog();
        private void Form1_Load(object sender, EventArgs e)
        {
            DataClipboard = SetClipboardViewer(this.Handle);
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            this.Text = this.Location.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}