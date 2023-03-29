using RecapProject1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listCategories();
            ListProducts();
        }

        void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.ToList();
            }
        }

        void ListProductsByCategoryId(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.Where(p=>p.CategoryID == id).ToList();
            }
        }
        void listCategories()
        {
            using(NorthwindContext context =new  NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";
            }
        }

        void ListProductByProductName(string key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.Where(p => p.ProductName.Contains(key)).ToList();
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(cbxCategory.SelectedValue);
                ListProductsByCategoryId(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            ListProductByProductName(tbxSearch.Text);
        }
    }
}
