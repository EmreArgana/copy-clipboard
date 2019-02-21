using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class BitmapToBase64
    {
        public static void ToBase64String(RichTextBox richTextBox)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }

            // Convert the image to byte[]
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] imageBytes = stream.ToArray();

            // Write the bytes (as a string) to the textbox
            richTextBox.Text = System.Text.Encoding.UTF8.GetString(imageBytes);

            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(imageBytes);

            // Write the bytes (as a Base64 string) to the textbox
            richTextBox.Text = base64String;
        }
       
    }
}
