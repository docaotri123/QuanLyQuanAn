using QuanLyQuanAn.BLL;
using System;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class fAdmin : Form
    {
        AccountService account = new AccountService();
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


    }
}
