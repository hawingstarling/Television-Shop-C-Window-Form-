using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product
    {
        private string _idProduct;
        private string _nameProduct;
        private string _size;
        private string _idCategory;
        private string _idProducer;
        private string _image;
        private int _amount;
        private double _price;

        public Product() { }

        public Product(DataRow dr)
        {
            _idProduct = dr["MASP"].ToString();
            _nameProduct = dr["TENSP"].ToString();
            _size = dr["KICHTHUOC"].ToString();
            _idCategory = dr["MALOAI"].ToString();
            _idProducer = dr["MANSX"].ToString();
            _image = dr["IMAGE"].ToString();
            _amount = int.Parse(dr["SOLUONG"].ToString());
            _price = double.Parse(dr["GIA"].ToString());
        } 

        public Product(string idProduct, string nameProduct, string size, string idCategory, string idProducer, string image, int amount, int price)
        {
            _idProduct = idProduct;
            _nameProduct = nameProduct;
            _size = size;
            _idCategory = idCategory;
            _idProducer = idProducer;
            _image = image;
            _amount = amount;
            _price = price;
        }

        public string IdProduct
        {
            get { return _idProduct; }
            set { _idProduct = value; }
        }

        public string NameProduct
        {
            get { return _nameProduct; }
            set { _nameProduct = value; }
        }

        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
            }
        }

        public string IdCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        }

        public string IdProducer
        {
            get { return _idProducer; }
            set { _idProducer = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }
    }
}
