using MagicalBox.Database;
using MagicalBox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MagicalBox
{
    /// <summary>
    /// AdminRegist.xaml 的交互逻辑
    /// </summary>
    public partial class AdminRegist : Window
    {
        public AdminRegist()
        {
            InitializeComponent();
        }

        private void Admin_Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            bool Admin_Already_Exist = false;
            using AppDbContext dbContext = new AppDbContext();
            foreach (var item in dbContext.Admins.Where(e => e.Username == adminNameToReg.Text))
            {
                Admin_Already_Exist = true;
            }
            if (Admin_Already_Exist) MessageBox.Show("该管理员名称已存在！");
            else if (adminRegPin.Text != "0000") MessageBox.Show("注册口令错误，请从系统管理员处获取！");
            else
            {
                var data = new Admin
                {
                    Username = adminNameToReg.Text,
                    Password = adminPasswordToReg.Text,
                };
                dbContext.Admins.Add(data);
                dbContext.SaveChanges();
                MessageBox.Show("注册成功，接下来会跳转登陆页面！");
                new AdminLogin().Show();
                Window window = Window.GetWindow(this);//关闭父窗体
                window.Close();
            }
        }
        private void Admin_Reg_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            new AdminLogin().Show();
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
        }
    }
}
