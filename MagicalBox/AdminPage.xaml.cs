using MagicalBox.Database;
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
            initList();
        }

        private void initList()
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
            initList();
        }
        private void addInfo_Click(object sender, RoutedEventArgs e)
        {
            new AddUserInfo().ShowDialog();
        }
    }
}
