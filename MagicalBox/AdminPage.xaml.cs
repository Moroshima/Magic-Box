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
    /// AdminPage.xaml 的交互逻辑
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
            InitList();
        }

        public void InitList()
        {
            dataList.Items.Clear();
            using AppDbContext dbContext = new AppDbContext();
            foreach (var item in dbContext.Users.Where(m => m.Id >= 1))
            {
                dataList.Items.Add(item);
                //passwordFromDb = item.Password;
                //MessageBox.Show(item.Password);
            }
        }
        private void refreshList_Click(object sender, RoutedEventArgs e)
        {
            InitList();
        }
        private void addInfo_Click(object sender, RoutedEventArgs e)
        {
            new AddUserInfo().ShowDialog();
            InitList();
        }

        private void removeInfo_Click(object sender, RoutedEventArgs e)
        {
            User Single_User = dataList.SelectedItem as User;
            if (Single_User != null && Single_User is User)
            {
                using AppDbContext dbContext = new AppDbContext();
                dbContext.Users.Remove(Single_User);
                //dataList.Items.Remove(Single_User);
                dbContext.SaveChanges();
                InitList();
            }
            else MessageBox.Show("请先选定需要删除信息的乘客！");
        }

        public static string BoxId_String_To_Search;

        private void checkDetail_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(dataList.SelectedItem.GetType().ToString());
            User Single_User = dataList.SelectedItem as User;
            if (Single_User != null && Single_User is User)
            {
                MessageBox.Show(
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
                    "评价：" + Single_User.Comment + "\n\n"
                    );
            }
            else MessageBox.Show("请先选定需要查看的乘客！");
        }
        private void phoneReturned_Click(object sender, RoutedEventArgs e)
        {
            User Single_User = dataList.SelectedItem as User;
            if (Single_User != null && Single_User is User)
            {
                using AppDbContext dbContext = new AppDbContext();
                foreach (var item in dbContext.Users.Where(e => e.Id == Single_User.Id))
                {
                    item.Returned = true;
                }
                dbContext.SaveChanges();
                MessageBox.Show("设备归还成功！");
                InitList();
            }
            else MessageBox.Show("请先选定对应的乘客！");
        }

        private void easySearch_Click(object sender, RoutedEventArgs e)
        {
            BoxId_String_To_Search = BoxId_To_Search.Text;
            if (BoxId_String_To_Search != "")
            {
                // MessageBox.Show(BoxId_String_To_Search);
                bool BoxId_To_Search_Exist = false;
                using AppDbContext dbContext = new AppDbContext();
                foreach (var item in dbContext.Users.Where(e => e.BoxId.ToString() == AdminPage.BoxId_String_To_Search))
                {
                    BoxId_To_Search_Exist = true;
                }
                if (BoxId_To_Search_Exist)
                {
                    new AdminFastSearch().ShowDialog();
                    InitList();
                }
                else MessageBox.Show("查无此盒！");
            }
            else MessageBox.Show("请先填写需要搜寻的盒子编号！");
        }
    }
}
