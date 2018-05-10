
using QuanLyQuanAn.BLL.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class fTableManager : Form
    {
        TableFoodService tableFood = new TableFoodService();
        
        
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }
        
        private void LoadTable()
        {
            var listTable = tableFood.GetTableFoods();
            int x = 50;
            int y = 50;
            foreach(var item in listTable)
            {
                Button btn = new Button() { Width = x, Height = y };
                btn.Text = item.nameTable+Environment.NewLine+item.statusTable;
                if (item.statusTable == "Trống")
                {
                    btn.BackColor = Color.Green;
                }
                else
                    btn.BackColor = Color.White;
                flpTable.Controls.Add(btn);
            }
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
