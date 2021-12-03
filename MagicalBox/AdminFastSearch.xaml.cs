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
    /// AdminFastSearch.xaml 的交互逻辑
    /// </summary>
    public partial class AdminFastSearch : Window
    {
        public AdminFastSearch()
        {
            InitializeComponent();
            SetData();
        }
        private void SetData()
        {
            bool BoxId_To_Search_Exist = false;
            using AppDbContext dbContext = new AppDbContext();
            foreach (var item in dbContext.Users.Where(e => e.BoxId.ToString() == AdminPage.BoxId_String_To_Search))
            {
                BoxId_To_Search_Exist = true;
            }
            if (BoxId_To_Search_Exist)
            {
                foreach (var item in dbContext.Users.Where(e => e.BoxId.ToString() == AdminPage.BoxId_String_To_Search))
                {
                    User Single_User = item;
                    User_Info_Text.Text =
                    "盒子编号" + Single_User.BoxId + "\n\n" +
                    "姓名：" + Single_User.Username + "\n\n" +
                    "有效证件：" + Single_User.IdCard + "\n\n" +
                    "登机牌号：" + Single_User.BoardCard + "\n\n" +
                    "出发地：" + Single_User.Departure + "\n\n" +
                    "目的地：" + Single_User.Destination + "\n\n" +
                    "手机机型：" + Single_User.PhoneType + "\n\n" +
                    "手机号码：" + Single_User.PhoneNumber + "\n\n" +
                    "备用联系方式：" + Single_User.BackupLink + "\n\n" +
                    "是否已取回手机：" + Single_User.Returned + "\n\n" +
                    "满意度：" + Single_User.Satisfaction + "\n\n" +
                    "评价：" + Single_User.Comment + "\n\n";
                }
            }
            else
            {
                MessageBox.Show("查无此盒！");
                Window window = Window.GetWindow(this);//关闭父窗体
                window.Close();
            }
        }
        private void Get_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            using AppDbContext dbContext = new AppDbContext();
            foreach (var item in dbContext.Users.Where(e => e.BoxId.ToString() == AdminPage.BoxId_String_To_Search))
            {
                item.Returned = true;
            }
            dbContext.SaveChanges();
            MessageBox.Show("设置成功！");
            SetData();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            using AppDbContext dbContext = new AppDbContext();
            foreach (var item in dbContext.Users.Where(e => e.BoxId.ToString() == AdminPage.BoxId_String_To_Search))
            {
                User Single_User = item;
                dbContext.Users.Remove(Single_User);
            }
            dbContext.SaveChanges();
            MessageBox.Show("移除成功！");
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
        }
    }
}
