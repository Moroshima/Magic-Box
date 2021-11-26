using MagicalBox.Database;
using MagicalBox.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MagicalBox
{
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
            using AppDbContext dbContext = new AppDbContext();
            var data = new Admin
            {
                Username = "Admin",
                Password = "000000"
            };
            dbContext.Admins.Add(data);
            dbContext.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string idCard = idCardNumber.Text;    //获取用户名
            string box = boxNumber.Text;    //获取密码
            string boxNumberFromDb = null;
            using AppDbContext dbContext = new AppDbContext();
            //if (idCard != null && box != null)
            //    foreach (var item in dbContext.Users.Where(m => m.IdCard == $"{idCard}"))
            //    {
            //        boxNumberFromDb = item.id;
            //        //MessageBox.Show(item.Password);
            //    }
            //else MessageBox.Show("请完整填写账号与密码！");
            ////判断用户名密码是否正确
            //if ($"{passwordFromDb}".Equals(password))
            //{
            //    MessageBox.Show("登录成功！");
            new AdminLogin().Show();
            //}
            //else
            //{
            //    MessageBox.Show("登录失败！");
            //}
        }
    }
}
