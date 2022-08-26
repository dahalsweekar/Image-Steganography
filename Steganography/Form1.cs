using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        kec_dbEntities _db = new kec_dbEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            cboRole.SelectedIndex = 0;
            txtUsername.Focus();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsername.Text = "";
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                tblSteg tb = _db.tblStegs.Where(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text).FirstOrDefault();
                if (tb != null)
                {
                    if (cboRole.SelectedIndex == 1)

                    {
                        Program.username = txtUsername.Text;
                        LoginForm frm = new LoginForm();
                        frm.Show();
                        this.Hide();
                    }
                    else if (cboRole.SelectedIndex == 2)
                    {
                        Program.username = txtUsername.Text;
                        ExtractForm frm = new ExtractForm();
                        frm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid username and password");
                }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm frm = new RegisterForm();
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        bool mousedown;
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mouseX = MousePosition.X - 150;
                int mouseY = MousePosition.Y - 20;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
    }
}
