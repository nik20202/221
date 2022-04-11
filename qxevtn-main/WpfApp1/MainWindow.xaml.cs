using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Instances.db.Products.ToList().ForEach(q => {
            //    var directory = Directory.GetFiles(@"C:/Users/User/Desktop/Вариант 2/Сессия 1/Товар_import");

            //    if (directory.FirstOrDefault(w => w.Contains(q.ProductArticleNumber)) != null)
            //    {
            //        q.ProductPhoto = File.ReadAllBytes(directory.FirstOrDefault(w => w.Contains(q.ProductArticleNumber)));
            //        Instances.db.SaveChanges();
            //    }                

            //});

        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var login = txtlogin.Text;
            var pass = txtpass.Password;

            User user;

            if ((user = Instances.db.Users.FirstOrDefault(q => q.UserLogin == login && q.UserPassword == pass)) != null)
            {
                Hide();
                new ListProductsWindow(user).ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }

        }

        private void btnCapt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new ListProductsWindow(null).ShowDialog();
            Show();
        }
    }
}
