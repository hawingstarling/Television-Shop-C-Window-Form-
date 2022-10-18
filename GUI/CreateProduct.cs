using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce.GUI
{
    public partial class CreateProduct : Form
    {
        public CreateProduct()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CreateProduct_Load(object sender, EventArgs e)
        {
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            
            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                pictureProduct3.Image = Image.FromFile(openPicture.FileName);
            }
            openPicture.Dispose();
        }

        private void bunifuImageProduct1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
