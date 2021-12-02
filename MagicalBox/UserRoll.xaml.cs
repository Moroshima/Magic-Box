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
using System.Threading;

namespace MagicalBox
{
    /// <summary>
    /// UserRoll.xaml 的交互逻辑
    /// </summary>
    public partial class UserRoll : Window
    {
        public UserRoll()
        {
            InitializeComponent();
        }

        private void Roll_Button_Click(object sender, RoutedEventArgs e)
        {
            string Real_Roll_Result = null;
            Random random = new Random();
            int User_Roll_Result = random.Next(1, 101); //生成1~101之间的随机数，不包括101
            if (User_Roll_Result >= 90) Real_Roll_Result = "一等奖";
            else if (User_Roll_Result >= 75) Real_Roll_Result = "二等奖";
            else if (User_Roll_Result >= 50) Real_Roll_Result = "三等奖";
            else Real_Roll_Result = "谢谢参与";
            //for (int i = 0; i < 15; i++)
            //{
            //    User_Roll_Display.Text = "一等奖";
            //    User_Roll_Display.Text = "二等奖";
            //    User_Roll_Display.Text = "三等奖";
            //    User_Roll_Display.Text = "谢谢参与";
            //}
            User_Roll_Display.Text = Real_Roll_Result;
            MessageBox.Show("恭喜手机号码为"+ UserLogin.Global_User_Phone_Number +"的乘客抽中\"" + Real_Roll_Result + "\"!");
            MessageBox.Show("请点击确定以退出该系统！");
            Window window = Window.GetWindow(this);    //关闭父窗体
            window.Close();
        }
    }
}
