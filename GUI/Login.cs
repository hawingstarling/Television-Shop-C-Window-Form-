using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using Ecommerce.DAO;

namespace Ecommerce.GUI
{
    public partial class Login : KryptonForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        int count = 1;

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (LoginFunc(username, password))
            {
                this.Hide();
                Account acc = AccountDAO.Instance.GetAccount(username);
                Main frmMain = new Main(acc);
                frmMain.ShowDialog();
                this.Show();
            }
            else
            {
                count++;
                if (count <= 3)
                {
                    MessageBox.Show("You have enter bad name or password.");
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("You have to enter bad name or password 3 times. Press YES to exit the program", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (d == DialogResult.Yes)
                    {
                        Application.ExitThread();
                    }
                    count = 1;
                }

            }
            txtUsername.Text = "";
            txtUsername.Focus();
            txtPassword.Text = "";
        }

        bool LoginFunc(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

    }
}
