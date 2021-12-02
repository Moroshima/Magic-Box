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
    /// UserJudgePage.xaml 的交互逻辑
    /// </summary>
    public partial class UserJudgePage : Window
    {
        public UserJudgePage()
        {
            InitializeComponent();
        }

        private void Uncomment_Button_Click(object sender, RoutedEventArgs e)
        {
            int selection = 0;
            ChangeDbSatisfaction(selection);
        }

        private void Unsatisfied_Button_Click(object sender, RoutedEventArgs e)
        {
            int selection = 1;
            ChangeDbSatisfaction(selection);
        }

        private void Satisfied_Button_Click(object sender, RoutedEventArgs e)
        {
            int selection = 2;
            ChangeDbSatisfaction(selection);
        }

        private void ChangeDbSatisfaction(int inputData)
        {
            using AppDbContext dbContext = new AppDbContext();
            foreach (var item in dbContext.Users.Where(e => e.IdCard == UserLogin.Global_User_IdCard_Number))
            {
                item.Satisfaction = (Model.Satisfaction?)inputData;
                //passwordFromDb = item.Password;
                //MessageBox.Show(item.Password);
            }
            dbContext.SaveChanges();
            MessageBox.Show("评价成功！");
            new UserWillingToComment().Show();
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
        }
    }
}
