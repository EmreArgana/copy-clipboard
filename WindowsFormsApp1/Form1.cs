﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroForm
    {
        private PictureBox pb;

        public Form1()
        {
            InitializeComponent();

            pb = new PictureBox();
            this.Controls.Add(pb);
            pb.Dock = DockStyle.Fill;
        }

        #region Blur And Unblur Effect
        private void Blur()
        {
            Bitmap bmp = Screenshot.TakeSnapshot(this);
            BitmapFilter.GaussianBlur(bmp, 0);

            pb.Image = bmp;
            pb.SendToBack();
        }

        private void UnBlur()
        {
            pb.Image = null;
            pb.SendToBack();
        }
        #endregion

        #region Clipboard Text & Bitmap Control

        DateTime dateTime = DateTime.Now;
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
            if (dObj.GetDataPresent(DataFormats.Text))
            {
                DatabaseOperations.AddData((string)dObj.GetData(DataFormats.Text), "Category",Convert.ToString(dateTime));
                CreateObject.GetMetroTextBox(flowLayoutPanel1, DatabaseOperations.GetLastData(), 300, 300, 1);


            }
            else if (dObj2.GetDataPresent(DataFormats.Bitmap))
            {
                MessageBox.Show("Test");
                CreateObject.GetPictureBox(flowLayoutPanel1, (Image)dObj2.GetData(DataFormats.Bitmap), 300, 300);
            }
        }
        #endregion

        #region Convert Bitmap to jpg
        //https://stackoverflow.com/questions/11743160/how-do-i-encode-and-decode-a-base64-string
        #endregion



        private void Form1_Load(object sender, EventArgs e)
        {
            Clipboard.Clear();
            DataClipboard = SetClipboardViewer(this.Handle);
            for (int i = 0; i < DatabaseOperations.GetDataCount(); i++)
            {
               CreateObject.GetMetroTextBox(flowLayoutPanel1, DatabaseOperations.GetData(i), 300, 300, i);
            }

        }
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            this.Text = this.Location.ToString();
        }
        
    }
}