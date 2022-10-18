using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DTO;

namespace Ecommerce.GUI
{
    public partial class Main : KryptonForm
    {
        Form activeForm;

        private Account _acc;
        public Main()
        {
            InitializeComponent();
        }

        public Main(Account acc)
        {
            InitializeComponent();
            _acc = acc;
        }
        
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();

            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelMenu.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new CreateProduct());
        }

        private void panelMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new Product());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new Order());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            nameMenu.Text = _acc.UserName;       
        }

        private void nameMenu_Click(object sender, EventArgs e)
        {

        }
    }
}
