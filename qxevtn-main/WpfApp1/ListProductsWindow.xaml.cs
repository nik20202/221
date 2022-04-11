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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ListProductsWindow.xaml
    /// </summary>
    public partial class ListProductsWindow : Window
    {
        private User user = null;
        public ListProductsWindow(User user)
        {
            InitializeComponent();

            if (user != null)
            {
                this.user = user;
                this.lblRole.Content = user.Role.RoleName;
            }

            load();

            cmbSort.ItemsSource = new List<string>() { "по возрастанию", "по убыванию" };
            cmbSort.SelectedIndex = 0;
            cmbFilt.ItemsSource = new List<string>() { "Все диапазоны", "0-9,99%", "10-14,99%", "15% и более" };
            cmbFilt.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void load()
        {
            var data = Instances.db.Products.ToList();

            var all_count = data.Count;

            if (cmbSort.SelectedItem != null)
            {
                switch (cmbSort.SelectedIndex)
                {
                    case 0:
                        data = data.OrderBy(q => q.ProductCost).ToList();
                        break;
                    case 1:
                        data = data.OrderByDescending(q => q.ProductCost).ToList();
                        break;
                }
            }            
            
            if (cmbFilt.SelectedItem != null)
            {
                switch (cmbFilt.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        data = data.Where(q => q.ProductDiscountAmount >= 0).ToList();
                        data = data.Where(q => q.ProductDiscountAmount < 10).ToList();
                        break;
                    case 2:
                        data = data.Where(q => q.ProductDiscountAmount >= 10).ToList();
                        data = data.Where(q => q.ProductDiscountAmount < 15).ToList();
                        break;
                    case 3:
                        data = data.Where(q => q.ProductDiscountAmount >= 15).ToList();
                        break;
                }
            }

            if (txtSearch.Text.Length != 0)
            {
                data = data.Where(q => q.ProductName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            this.listViewProducts.ItemsSource = data;

            lblCount.Content = $"{data.Count} из {all_count}";
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            load();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            load();

        }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            load();
        }
    }
}
