using MagicalBox.Database;
using MagicalBox.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MagicalBox
{
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;    //获取用户名
            string password = passwordTextBox.Password;    //获取密码
            string passwordFromDb = null;
            using AppDbContext dbContext = new AppDbContext();
            if (username != null && password != null)
                foreach (var item in dbContext.Admins.Where(m => m.Username == $"{username}"))
                {
                    passwordFromDb = item.Password;
                    //MessageBox.Show(item.Password);
                }
            else MessageBox.Show("请完整填写账号与密码！");
            //判断用户名密码是否正确
            if ($"{passwordFromDb}".Equals(password))
            {
                MessageBox.Show("登录成功！");
                new AdminPage().Show();
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }
    }
}
