using MagicalBox.Database;
using MagicalBox.Model;
using Microsoft.EntityFrameworkCore;
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
            //using AppDbContext dbContext = new AppDbContext();
            //var data = new Admin
            //{
            //    Username = "Admin",
            //    Password = "000000"
            //};
            //dbContext.Admins.Add(data);
            //dbContext.SaveChanges();
            using AppDbContext context = new AppDbContext();
            context.Database.EnsureCreated();
        }

        public static string Global_User_Phone_Number;
        public static string Global_User_IdCard_Number;

        private void User_Button_Click(object sender, RoutedEventArgs e)
        {
            string idCard = idCardNumber.Text;    //获取有效证件编号
            string box = boxNumber.Text;    //获取盒子编号
            string boxNumberFromDb = null;
            using AppDbContext dbContext = new AppDbContext();
            if (idCard != "" && box != "")
            {
                foreach (var item in dbContext.Users.Where(m => m.IdCard == $"{idCard}"))
                {
                    boxNumberFromDb = item.BoxId.ToString();
                    Global_User_Phone_Number = item.PhoneNumber;
                    Global_User_IdCard_Number = item.IdCard;
                    //MessageBox.Show(item.Password);
                }
                // 判断用户名密码是否正确
                if ((boxNumberFromDb != null) && boxNumberFromDb.Equals(box))
                {
                    MessageBox.Show("登录成功！");
                    new UserJudgePage().Show();
                    Window window = Window.GetWindow(this);//关闭父窗体
                    window.Close();
                }
                else
                {
                    MessageBox.Show("登录失败！");
                }
            }
            else MessageBox.Show("请完整填写账号与密码！");         
        }

        private void Admin_Button_Click(object sender, RoutedEventArgs e)
        {
            new AdminLogin().Show();
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
        }
    }
}
