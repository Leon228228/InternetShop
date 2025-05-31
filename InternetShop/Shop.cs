using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetShop
{
   
    public partial class Shop : Form
    {
        List<Item> items = new List<Item>();
        List<string> kostil =new List<string>();
        Form1 form;
        public Shop(Form1 form)
        {
            InitializeComponent();
            items.Add(new Item
            {
                name = "potato",
                price = 5.5f
            });
            items.Add(new Item
            {
                name = "clode",
                price = 8.5f
            });
            this.form = form;
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            UpdateList();           
        }

        private void UpdateList()
        {
            if (kostil.Count != items.Count)
            {
                kostil.Clear();
                foreach (var i in items)
                {
                    kostil.Add(i.name + " - " + i.price);
                }
            }
            listBoxProducts.DataSource = null;
            listBoxProducts.DataSource = kostil;

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            form.Visible = true;
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            float price = -1;
            if(float.TryParse(txtPdroductPrice.Text, out price))
            {
                Item item = new Item
                {
                    name = txtProductName.Text,
                    price = price
                };
                items.Add(item);
                UpdateList();
                lblStatus.Text = "Товар добавлен";
                txtPdroductPrice.Text = "";
                txtProductName.Text = "";
            }
            else lblStatus.Text = "Цена указана не корректно";

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var temp = listBoxProducts.SelectedIndex;
            if(temp <0)
            {
                lblStatus.Text = "Выберите товар";
                return;
            }

            txtPdroductPrice.Text = items[temp].price.ToString();
            txtProductName.Text = items[temp].name;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var temp = listBoxProducts.SelectedIndex;
            if (temp < 0)
            {
                lblStatus.Text = "Выберите товар";
                return;
            }
            items.RemoveAt(temp);
            UpdateList();
        }
    }
    class Item
    {
        public string name;
        public float price;
    }
}
