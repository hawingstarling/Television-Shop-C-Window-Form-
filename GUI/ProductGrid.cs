using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ecommerce.DAO;

namespace Ecommerce.GUI
{
    public partial class ProductGrid : Form
    {
        public ProductGrid()
        {
            InitializeComponent();
        }

        private BindingSource bds = new BindingSource();

        public void LoadDtgv()
        {
            bds.DataSource = ProductDAO.Instance.GetAll();
        }

        public void AddDataBinding()
        {
            txtProductId.DataBindings.Add("Text", dtgv.DataSource, "IDProduct");
            txtProductName.DataBindings.Add("Text", dtgv.DataSource, "NameProduct");
            txtProductSize.DataBindings.Add("Text", dtgv.DataSource, "Size");
            cbCategory.DataBindings.Add("Text", dtgv.DataSource, "IDCategory");
            cbProducer.DataBindings.Add("Text", dtgv.DataSource, "IDProducer");
            txtProductAmount.DataBindings.Add("Text", dtgv.DataSource, "Amount");
            txtProductPrice.DataBindings.Add("Text", dtgv.DataSource, "Price");
            pictureProduct.DataBindings.Add("Text", dtgv.DataSource, "Image");
        }

        public void ChangHeader()
        {
            dtgv.Columns["IDProduct"].HeaderText = "Id";
            dtgv.Columns["NameProduct"].HeaderText = "Name Product";
            dtgv.Columns["IDCategory"].HeaderText = "Id Category";
            dtgv.Columns["IDProducer"].HeaderText = "Id Producer";
            dtgv.Columns["Amount"].HeaderText = "Amount";
            dtgv.Columns["Price"].HeaderText = "Price";
        }

        private void ProductGrid_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            dtgv.Columns["Size"].Visible = false;
            dtgv.Columns["Image"].Visible = false;
            ChangHeader();
            AddDataBinding();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ProductDAO.Instance.Delete(txtProductId.Text))
            {
                MessageBox.Show("Delete successfull");
                LoadDtgv();
            }
            else
            {
                MessageBox.Show("Vui lòng xử lý hóa đơn trước");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (ProductDAO.Instance.Update(txtProductId.Text, txtProductName.Text, txtProductSize.Text, int.Parse(txtProductAmount.Text), double.Parse(txtProductPrice.Text), cbCategory.Text, cbProducer.Text, pictureProduct.Image.ToString()))
            {
                MessageBox.Show("Update successfull");
            }
            else
            {
                MessageBox.Show("Vui lòng xử lý hóa đơn trước");
            }
            LoadDtgv();
        }

        private void cbProducer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
