using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile profile = new fAccountProfile();
            profile.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin admin = new fAdmin();
            admin.ShowDialog();
        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
