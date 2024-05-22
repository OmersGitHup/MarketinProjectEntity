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
    public partial class FrmEnterSc : Form
    {
        public FrmEnterSc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbEntityProductEntities db=new DbEntityProductEntities();
            var sorgu = from x in db.Tbl_Admin where x.UserName == textBox1.Text && x.Password == textBox2.Text select x;
            if (sorgu.Any()) {
                FrmMainForm mainForm = new FrmMainForm();
                mainForm.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("WRONG Password or Username");
            }
        }
    }
}
