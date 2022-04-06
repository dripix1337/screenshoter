using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screenshoter
{
    public partial class ScreenshotForm : Form
    {
        private Bitmap bitMap = new Bitmap ( Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height );
        private SaveFileDialog saveFileDialog = new SaveFileDialog ( );
        public ScreenshotForm()
        {
            InitializeComponent();
            saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";

            Graphics graphics = Graphics.FromImage ( ( Bitmap ) this.bitMap );
            graphics.CopyFromScreen ( 0, 0, 0, 0, bitMap.Size );

            this.pictureBox1.Image = bitMap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( saveFileDialog.ShowDialog ( ) == DialogResult.OK )
                bitMap.Save ( saveFileDialog.FileName );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close ( );
        }
    }
}
