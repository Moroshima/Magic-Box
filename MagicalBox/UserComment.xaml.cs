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
    /// UserComment.xaml 的交互逻辑
    /// </summary>
    public partial class UserComment : Window
    {
        public UserComment()
        {
            InitializeComponent();
        }

        private void User_Yes_To_Comment(object sender, RoutedEventArgs e)
        {
            if (Feedback_Box.Text != null)
            {
                using AppDbContext dbContext = new AppDbContext();
                foreach (var item in dbContext.Users.Where(e => e.IdCard == UserLogin.Global_User_IdCard_Number))
                {
                    item.Comment = Feedback_Box.Text;
                }
                dbContext.SaveChanges();
                MessageBox.Show("感谢您的反馈，接下来将跳转到抽奖页面！");
                new UserRoll().Show();
                Window window = Window.GetWindow(this);    //关闭父窗体
                window.Close();
            }
            else MessageBox.Show("请填写您的反馈或选择返回！");
        }

        private void User_Suddenly_Unwilling_To_Comment(object sender, RoutedEventArgs e)
        {
            new UserWillingToComment().Show();
            Window window = Window.GetWindow(this);    //关闭父窗体
            window.Close();
        }

    }
}
