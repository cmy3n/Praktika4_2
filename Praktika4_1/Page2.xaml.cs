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

namespace Praktika4_1
{
    public partial class Page2 : Page
    {
        private PunktVidachiZakazovEntities pvz = new PunktVidachiZakazovEntities();
        public Page2()
        {
            InitializeComponent();

            dg1.ItemsSource = pvz.Orders.ToList();

            cb1.ItemsSource = pvz.Orders.ToList();
            cb1.DisplayMemberPath = "Order_Number";
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void back_page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = pvz.Orders.ToList().Where(item => item.Products.Contains(search.Text));
        }

        private void filter_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = pvz.Orders.ToList();
        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var number = cb1.SelectedItem as Orders;
                dg1.ItemsSource = pvz.Orders.ToList().Where(item => item as Orders == number);
            }
            catch
            {

            }
        }
    }
}
