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
        string userNameAdmin;
        public fAdmin(string s1)
        {
            userNameAdmin = s1;//lấy tên đăng nhập, kiểm tra lúc thêm xóa sửa tài khoản
            InitializeComponent();
            LoadAdmin();
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadAdmin()
        {
            ListAccount();
            AddAccountBinding();
        }
        private void ListAccount()
        {
            //var ds = from s in db.Accounts select s;
            var ds = account.GetAccounts();
            dtgvAccount.DataSource = ds;
           
        }
 
        //trien
        private void AddAccountBinding()
        {

            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "userName",true,DataSourceUpdateMode.Never));
            numericUpDownType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "style",true,DataSourceUpdateMode.Never));

        }
        
        //trien

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

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text.ToString();
            int temp = (int)numericUpDownType.Value;
            bool type = Convert.ToBoolean(temp);
            bool test=account.AddAccount(userName, type);
            if (test == true)
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Tài khoản đã trùng tên, vui lòng thay đổi thông tin");
            }

            txbUserName.DataBindings.Clear();
            ListAccount();
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "userName", true, DataSourceUpdateMode.Never));






        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text.ToString();
            string passWord = "0";
            bool kt = account.UpdateAccount(userName, passWord);
            if(kt==true)
            {
                MessageBox.Show("reset mật khẩu thành công, mật khẩu mặc định là 0");
            }
            else
            {
                MessageBox.Show("reset mật khẩu thất bại, vui lòng kiểm tra lại thông tin tài khoản");
            }
            txbUserName.DataBindings.Clear();
            ListAccount();
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "userName", true, DataSourceUpdateMode.Never));



        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text.ToString();
            int temp = (int)numericUpDownType.Value;
            bool type = Convert.ToBoolean(temp);
            bool test=account.UpdateAccountFormAdmin(userName, type);
            if (test == true)
            {
                MessageBox.Show("Sửa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thât bại, vui lòng kiểm tra thông tin");
            }
            txbUserName.DataBindings.Clear();
            ListAccount();
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "userName", true, DataSourceUpdateMode.Never));



        }

        //xóa tài khoản
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text.ToString();
            if (userName == userNameAdmin)
            {
                MessageBox.Show("Bạn không thể xóa tài khoản của chính mình khi đang đăng nhập");
                return;
            }
            bool test=account.DeleteAccount(userName);
            if (test == true)
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại");
            }

            //ListAccount();
            txbUserName.DataBindings.Clear();
            ListAccount();
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "userName", true, DataSourceUpdateMode.Never));



        }

        private void tpAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
