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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            desobj = Rijndael.Create();
        }


        

        SymmetricAlgorithm desobj;

       

       

        

        

        
        
        public string ConvertIntegerToBinary(int intNumber)
        {

            int remainder;
            string result = string.Empty;
            while (intNumber > 0)
            {
                remainder = intNumber % 2;
                intNumber /= 2;
                result = remainder.ToString() + result;
            }
            return result;
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(ofd.FileName);

                txtFilePath.Text = ofd.FileName.ToString();
                picOriginalImage.Image = bit;
                picOriginalImage.SizeMode = PictureBoxSizeMode.StretchImage;


            }
        }

        public string encodedtext="";
        private void btnEncrypt_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void btnDecrypt_Click_1(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();

            //System.IO.MemoryStream ms1 = new System.IO.MemoryStream(cipherbytes);
            //CryptoStream cs1 = new CryptoStream(ms1, desobj.CreateDecryptor(), CryptoStreamMode.Read);

            //cs1.Read(cipherbytes, 0, cipherbytes.Length);
            //plainbytes2 = ms1.ToArray();
            //cs1.Close();
            //ms1.Close();

            //txtDecrptedText.Text = Encoding.ASCII.GetString(plainbytes2);
        }

        public Bitmap img;
        private void btnEncode_Click_1(object sender, EventArgs e)
        {
            img = new Bitmap(txtFilePath.Text);
            string text = "";

            if(txtPlaintext.Text=="")
            {
                MessageBox.Show("Text Cannot Be Blank!!!");
            }

            if(txtPassword.Text.Length<6)
            {
                MessageBox.Show("Passoerd is too Short!!!");
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            else
            {
                text = crypto.EncryptStringAES(txtPlaintext.Text, txtPassword.Text);
                //Program.Password = txtPassword.Text;
                //cipherData = txtPlaintext.Text;
                //plainbytes = Encoding.ASCII.GetBytes(cipherData);
                //plainkey = Encoding.ASCII.GetBytes("0123456789abcdef");
                //desobj.Key = plainkey;
                //desobj.Mode = CipherMode.CBC;
                //desobj.Padding = PaddingMode.PKCS7;
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //CryptoStream cs = new CryptoStream(ms, desobj.CreateEncryptor(), CryptoStreamMode.Write);
                //cs.Write(plainbytes, 0, plainbytes.Length);
                //cs.Close();
                //cipherbytes = ms.ToArray();
                //ms.Close();
                //text = (Encoding.ASCII.GetString(cipherbytes));
                txtEcncrypttext.Text = text;
                img = HideandExtract.embedText(text, img);
                MessageBox.Show("Message embedded!!!");
                MessageBox.Show("Do not forget to save!!");
            }

            

            //for (int i = 0; i < img.Width; i++)
            //{
            //    for (int j = 0; j < img.Height; j++)
            //    {
            //        Color pixel = img.GetPixel(i, j);

            //        if (i < 1 && j < txtPlaintext.TextLength * 7)
            //        {


                       /* Console.WriteLine("R=[" + i + "][" + j + "]=" + pixel.R);
                        Console.WriteLine("G=[" + i + "][" + j + "]=" + pixel.G);
                        Console.WriteLine("B=[" + i + "][" + j + "]=" + pixel.B);

                        char[] PictureR = ConvertIntegerToBinary(pixel.R).ToCharArray();
                        char[] PictureG = ConvertIntegerToBinary(pixel.G).ToCharArray();
                        char[] PictureB = ConvertIntegerToBinary(pixel.B).ToCharArray();

                        foreach (var item in PictureR)
                        {
                            Console.WriteLine("RBinary:" + item);
                        }
                        foreach (var item in PictureG)
                        {
                            Console.WriteLine("GBinary:" + item);
                        }
                        foreach (var item in PictureB)
                        {
                            Console.WriteLine("BBinary:" + item);
                        }



                        char Letter = Convert.ToChar(txtPlaintext.Text.Substring(j, 1));



                        int Value = Convert.ToInt32(Letter);
                        Console.WriteLine("Letter:" + Letter + "Value:" + Value);

                        Console.WriteLine(ConvertIntegerToBinary(Value));
                        char[] text = ConvertIntegerToBinary(Value).ToCharArray();
                        foreach (var item in text)
                        {
                            Console.WriteLine(item);
                        }*/


            //        }
            //    }
            //}
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = "Welcome: " + Program.username;
            lblDate.Text = DateTime.Today.ToShortDateString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_file = new SaveFileDialog();
            save_file.Filter = "Png Image|*.png|Bitmap Image|*.bmp";

            if (save_file.ShowDialog() == DialogResult.OK)
            {
                switch (save_file.FilterIndex)
                {
                    case 0:
                        {
                            img.Save(save_file.FileName, ImageFormat.Png);
                        }
                        break;
                    case 1:
                        {
                            img.Save(save_file.FileName, ImageFormat.Bmp);
                        }
                        break;
                }
                
            }

            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool mousedown; 
        private void toppanel_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void toppanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mouseX = MousePosition.X - 150;
                int mouseY = MousePosition.Y - 20;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void toppanel_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
    }
}
