using QuanLyQuanAn.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.GUI.View
{
    public partial class fEditFood : Form
    {
        public string nameFood;
        public string price;
        public string idFood;
        FoodCategoryService category = new FoodCategoryService();
        FoodService food = new FoodService();

        public fEditFood(string id,string name, string price, string idCategory)
        {
            InitializeComponent();
            txbnameFood.Text = name;
            txbpriceFood.Text = price;
            idFood = id;
            var listCategory = category.GetFoodCategories();
            List<string> listName = new List<string>();
            foreach (var item in listCategory)
                listName.Add(item.nameFoodCategory);
            string nameCategory = category.GetNameCategoryById(int.Parse(idCategory));
            cbFoodCategory.DataSource = listName;
            cbFoodCategory.SelectedItem = nameCategory;
            //cbFoodCategory.ValueMember = idCategory;
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            decimal x = decimal.Parse(txbpriceFood.Text);
            string nameCate = cbFoodCategory.SelectedValue.ToString();
            int idCategory = category.GetIDCategoryByName(nameCate);
            food.UpdateFood(int.Parse(idFood), txbnameFood.Text, x,idCategory );
            MessageBox.Show("Updated thành công");
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txbnameFood_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
