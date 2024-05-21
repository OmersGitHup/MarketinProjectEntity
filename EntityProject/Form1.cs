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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityProductEntities db=new DbEntityProductEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var kategories=db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = kategories;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Kategori t=new Tbl_Kategori();
            t.Ad = textBox2.Text;
            db.Tbl_Kategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori added");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int x =Convert.ToInt32(textBox1.Text);
            var ktgr = db.Tbl_Kategori.Find(x);
            db.Tbl_Kategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Deleted");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.Tbl_Kategori.Find(x);
            ktgr.Ad=textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Update Confirmed");

        }
    }
}
