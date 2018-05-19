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
        TableFoodService tableFood = new TableFoodService();

        string userNameAdmin;
        public fAdmin(string s1)
        {
            userNameAdmin = s1;//lấy tên đăng nhập, kiểm tra lúc thêm xóa sửa tài khoản
            InitializeComponent();
            LoadAdmin();
            LoadTable();
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
        private void LoadTable()
        {
            ListTable();
            AddTableBinding();
            List<string> Status = new List<string>();
            Status.Add("Trống");
            Status.Add("Đã Đặt");
            cbTable.Items.AddRange(Status.ToArray());

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
        //Mục bàn ăn
        private void ListTable()
        {
            var ds = tableFood.GetTableFoods();
            dataGridView1.DataSource = ds;
        }
        private void AddTableBinding()
        {
            txbIdTable.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "idTable", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "nameTable", true, DataSourceUpdateMode.Never));
            cbTable.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "statusTable", true, DataSourceUpdateMode.Never));
        }
        private void ClearTableBinding()
        {
            txbIdTable.DataBindings.Clear();
            txbTableName.DataBindings.Clear();
            cbTable.DataBindings.Clear();
        }

        //thêm bàn ăn
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string nameTable = txbTableName.Text.ToString();
            bool test = tableFood.AddTable(nameTable);
            if (test == true)
            {
                MessageBox.Show("Thêm bàn thành công");
            }
            else
            {
                MessageBox.Show("Bàn đã tồn tại không thể thêm");
            }
            ClearTableBinding();
            ListTable();
            AddTableBinding();

        }
        //xóa bàn ăn
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int IdTable = int.Parse(txbIdTable.Text);
            //MessageBox.Show(IdTable.ToString());
            bool test = tableFood.DeleteTable(IdTable);
            if (test == true)
            {
                MessageBox.Show("Xóa bàn thành công");
            }
            else
            {
                MessageBox.Show("Xóa bàn không thành công");
            }
            ClearTableBinding();
            ListTable();
            AddTableBinding();
        }
        //sửa bàn ăn, sửa tên
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int IdTable = int.Parse(txbIdTable.Text);
            string newNameTable = txbTableName.Text.ToString();
            bool test = tableFood.EditNameTable(IdTable, newNameTable);
            if (test == true)
            {
                MessageBox.Show("Sửa tên bàn thành công");
            }
            else
            {
                MessageBox.Show("Tên bàn đã tồn tại");
            }
            ClearTableBinding();
            ListTable();
            AddTableBinding();
        }

        //them bàn ăn
        private void btnAddTable_Click_1(object sender, EventArgs e)
        {
            string nameTable = txbTableName.Text.ToString();
            bool test = tableFood.AddTable(nameTable);
            if (test == true)
            {
                MessageBox.Show("Thêm bàn thành công");
            }
            else
            {
                MessageBox.Show("Bàn đã tồn tại không thể thêm");
            }
            ClearTableBinding();
            ListTable();
            AddTableBinding();
        }

        //xóa bàn ăn
        private void btnDeleteTable_Click_1(object sender, EventArgs e)
        {
            int IdTable = int.Parse(txbIdTable.Text);
            //MessageBox.Show(IdTable.ToString());
            bool test = tableFood.DeleteTable(IdTable);
            if (test == true)
            {
                MessageBox.Show("Xóa bàn thành công");
            }
            else
            {
                MessageBox.Show("Xóa bàn không thành công");
            }
            ClearTableBinding();
            ListTable();
            AddTableBinding();
        }
        //sửa bàn ăn, sửa tên
        private void btnEditTable_Click_1(object sender, EventArgs e)
        {
            int IdTable = int.Parse(txbIdTable.Text);
            string newNameTable = txbTableName.Text.ToString();
            bool test = tableFood.EditNameTable(IdTable, newNameTable);
            if (test == true)
            {
                MessageBox.Show("Sửa tên bàn thành công");
            }
            else
            {
                MessageBox.Show("Tên bàn đã tồn tại");
            }
            ClearTableBinding();
            ListTable();
            AddTableBinding();
        }
        //trien

        private void ListFood()
        {
            var listFood = food.GetFoods();
            List<VFood> list = new List<VFood>();
            foreach(var item in listFood)
            {
                ListViewItem x = new ListViewItem(item.idFood.ToString());
                x.SubItems.Add(item.nameFood);
                x.SubItems.Add(item.price.ToString());
                x.SubItems.Add(item.idFoodCategory.ToString());

                lsvFood.Items.Add(x);
            }
            
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            fAddFood food = new fAddFood();
            food.Show();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            lsvFood.Items.Clear();
            ListFood();
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (lsvFood.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvFood.SelectedItems[0];
                string id= item.SubItems[0].Text;
                string name= item.SubItems[1].Text;
                string price= item.SubItems[2].Text;
                string idCategory = item.SubItems[3].Text;

                fEditFood f = new fEditFood(id,name,price, idCategory);
                f.Show();
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng để sửa");
            }
        }

  

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if(lsvFood.SelectedItems.Count>0)
            {
                string x = lsvFood.SelectedItems[0].Text;
                food.DeleteFood(int.Parse(x));
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng để xóa");
            }
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
