
using QuanLyQuanAn.BLL.Services;
using QuanLyQuanAn.DAL.Model;
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
                btn.Click += btn_Click;
                btn.Tag = item;

                if (item.statusTable == "Trống")
                {
                    btn.BackColor = Color.Green;
                }
                else
                    btn.BackColor = Color.White;
                flpTable.Controls.Add(btn);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as TableFood).idTable;
            DisplayBill(idTable);
        }

        private void DisplayBill(int id)
        {
            lsvBill.Clear();
            var listDetail = tableFood.TableFoodDetails(id);
            foreach(var item in listDetail)
            {
                ListViewItem lsvItem = new ListViewItem(item.nameFood);
                lsvItem.SubItems.Add(item.price.ToString());
                lsvItem.SubItems.Add(item.count.ToString());

                lsvBill.Items.Add(lsvItem);
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

       
    }
}
