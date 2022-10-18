using DTO;
using EShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal class ProductDAO
    {

        private ProductDAO() { }
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return ProductDAO.instance; }
            private set { ProductDAO.instance = value; }
        }
        public List<Product> GetAll()
        {
            DataTable _dt = new DataTable();

            string query = "select * from SanPham";
            _dt = DataProvider.Instance.ExecuteQuery(query);

            List<Product> list = new List<Product>();

            foreach (DataRow dr in _dt.Rows)
            {
                list.Add(new Product(dr));
            }
            return list;
        }

        public bool Insert(string masp, string tensp, string kichthuoc, int soluong, double giasp, string maloai, string mansx, string image)
        {
            string query = string.Format("insert into SanPham(MASP, TENSP, KICHTHUOC, SOLUONG, GIASP, MALOAI, MANSX, IMG) values('{0}', '{1}'. '{2}, {3}, {4}, '{5}', '{6}', '{7}')", masp, tensp, kichthuoc, soluong, giasp, maloai, mansx, image);

            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                if (result > 0) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
