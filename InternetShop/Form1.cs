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

    public partial class Form1 : Form
    {
        Dictionary<string, string> users = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();

            users["ivan"] = "123";
            users["oleg"] = "098";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Проверьте логин пароль");
                return;
            }
            users[txtUsername.Text] = txtPassword.Text;
            lblStatus.Text = "Регистрация успешна";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (users.ContainsKey(txtUsername.Text))
            {
                if (users[txtUsername.Text] == txtPassword.Text)
                {
                    lblStatus.Text = "всё хорошо";
                    var shop = new Shop(this);
                    shop.Show();
                    Visible = false;
                }
                else lblStatus.Text = "Неверный пароль";
            }
            else lblStatus.Text = "Неверное имя пользователя";


        }
    }
}
