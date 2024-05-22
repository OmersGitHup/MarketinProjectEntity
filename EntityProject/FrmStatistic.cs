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
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }
        DbEntityProductEntities db=new DbEntityProductEntities();

        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            label2.Text = db.Tbl_Kategori.Count().ToString();
            label3.Text=db.Tbl_Product.Count().ToString();
            label5.Text=db.Tbl_Customer.Count(x=>x.Statu==true).ToString();
            label7.Text = db.Tbl_Customer.Count(x => x.Statu == false).ToString();
            label13.Text=db.Tbl_Product.Sum(x=>x.Stock).ToString();
            label21.Text=db.Tbl_Sales.Sum(z=>z.Price).ToString()+" TL";
            //Top Price Product
            label11.Text=(from x in db.Tbl_Product orderby x.Price descending select x.ProductName).FirstOrDefault().ToString();
            //Top Least Price Product
            label9.Text=(from x in db.Tbl_Product orderby x.Price ascending select x.ProductName).FirstOrDefault().ToString();

            label15.Text=db.Tbl_Product.Count(x=>x.Kategori==1).ToString();
            //Find Total Something Count
            label17.Text=db.Tbl_Product.Count(x=> x.ProductName=="Buzdolabı").ToString();
            //Count With distinct
            label23.Text=(from x in db.Tbl_Customer select x.City).Distinct().Count().ToString();

            //Prosedürü kullanma
            label19.Text=db.getTopBrand().FirstOrDefault().ToString();
            

        }
    }
}
