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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace MagicalBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AdminLogin().Show();
            //MessageBox.Show("Hello");
            using AppDbContext dbContext = new AppDbContext();
            var data = new Admin
            {
                Username = "11111",
                Password = "22222"
            };
            //var item = dbContext.Admins.Where(m => m.Username == "11111");
            //MessageBox.Show(item.Password);
            //MessageBox.Show($"{findpassword}");
            //dbContext.SaveChanges();
            //e.Handled = true;
            MainWindow mainWindow = new MainWindow();
            Window window = Window.GetWindow(this);//关闭父窗体
            //mainWindow.Show();//无模式，弹出！
            //window.Close();
            // mainWindow.Show();
            // NavigationWindow window = new NavigationWindow();
            // window.Source = new Uri("MainWindow.xaml", UriKind.Relative);
            // window.Show();//无模式，弹出！
        }
        private void ButtonBase_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}
