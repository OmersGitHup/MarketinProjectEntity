using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProject
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        DbEntityProductEntities db = new DbEntityProductEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Product select new
            {
                x.ID,
                x.ProductName,
                x.Brand,
                x.Price,
                x.Statu,
                x.Tbl_Kategori.Ad
            }).ToList();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Product t = new Tbl_Product();
            t.ProductName = txtProName.Text;
            t.Brand = txtBrand.Text;
            t.Stock = short.Parse(txtStock.Text);
            t.Kategori = int.Parse(cmbKategori.SelectedValue.ToString());
            t.Price = decimal.Parse(txtPrice.Text);
            t.Statu = true;
            
            db.Tbl_Product.Add(t);
            db.SaveChanges();
            MessageBox.Show("Product Saved");



        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(txtID.Text);
            var product = db.Tbl_Product.Find(x);
            db.Tbl_Product.Remove(product);
            db.SaveChanges();
            MessageBox.Show("ProductDeleted");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(txtID.Text);
            var product = db.Tbl_Product.Find(x);
            product.ProductName = txtProName.Text;
            product.Brand = txtBrand.Text;
            product.Stock = short.Parse(txtStock.Text);
            db.SaveChanges();
            MessageBox.Show("Product Updated");
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var kategori = (from x in db.Tbl_Kategori
                            select new
                            {
                                x.ID,
                                x.Ad
                            }
                            ).ToList();
            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember="Ad";
            cmbKategori.DataSource = kategori;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
          
        }
    }
}
