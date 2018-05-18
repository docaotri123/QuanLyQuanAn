using QuanLyQuanAn.BLL;
using QuanLyQuanAn.BLL.Services;
using QuanLyQuanAn.DAL.Model;
using QuanLyQuanAn.DAL.ViewModel;
using QuanLyQuanAn.GUI.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class fAdmin : Form
    {
        AccountService account = new AccountService();
        FoodService food = new FoodService();

        public fAdmin()
        {
            InitializeComponent();
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            ListAccount();
        }

        private void ListAccount()
        {
            //var ds = from s in db.Accounts select s;
            var ds = account.GetAccounts();
            dtgvAccount.DataSource = ds;
        }

        private void ListFood()
        {
            var listFood = food.GetFoods();
            List<VFood> list = new List<VFood>();
            VFood x;
            foreach(var item in listFood)
            {
                x = new VFood();
                x.idFood = item.idFood;
                x.nameFood = item.nameFood;
                x.price = item.price;
                x.idFoodCategory = item.idFoodCategory;
                list.Add(x);
            }
            dtgvFood.DataSource = list;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            fFood food = new fFood();
            food.Show();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ListFood();
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sửa");
        }

  

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xóa");
        }
    }
}
