using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing.Imaging;

namespace Steganography
{
    public partial class ExtractForm : Form
    {
        public ExtractForm()
        {
            InitializeComponent();
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                picStegImage.Image = Image.FromFile(open_dialog.FileName);
                txtExtractFilePath.Text = open_dialog.FileName.ToString();
            }

            //OpenFileDialog ofd = new OpenFileDialog();

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    Bitmap bit = new Bitmap(ofd.FileName);

            //    txtExtractFilePath.Text = ofd.FileName.ToString();
            //    picStegImage.Image = bit;
            //    picStegImage.SizeMode = PictureBoxSizeMode.StretchImage;
            //}
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            
                Bitmap bmp = new Bitmap(picStegImage.Image);
                string extractedText = HideandExtract.extractText(bmp);

                try
                {
                    extractedText = crypto.DecryptStringAES(extractedText, txtExtractPassword.Text);
                }
                catch
                {
                    MessageBox.Show("Wrong password", "Error");

                    return;
                }

                txtextractedText.Text = extractedText;

                
                //System.IO.MemoryStream ms1 = new System.IO.MemoryStream(cipherbytes);
                //CryptoStream cs1 = new CryptoStream(ms1, desobj.CreateDecryptor(), CryptoStreamMode.Read);

                //cs1.Read(cipherbytes, 0, cipherbytes.Length);
                //plainbytes2 = ms1.ToArray();
                //cs1.Close();
                //ms1.Close();

                //txtextractedText.Text = Encoding.ASCII.GetString(plainbytes2);


            
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void txtextractedText_TextChanged(object sender, EventArgs e)
        {
            txtextractedText.Multiline = true;
        }

        bool mousedown;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mouseX = MousePosition.X;
                int mouseY = MousePosition.Y;
                SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
    }
}        
       
    
