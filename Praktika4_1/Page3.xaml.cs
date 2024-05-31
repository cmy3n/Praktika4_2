using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class Page3 : Page
    {
        private PunktVidachiZakazovEntities pvz = new PunktVidachiZakazovEntities();
        public Page3()
        {
            InitializeComponent();

            dg1.ItemsSource = pvz.OrdersClients.ToList();

            cb1.ItemsSource = pvz.OrdersClients.ToList();
            cb1.DisplayMemberPath = "OrderID";
        }

        private void back_page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(search.Text == "")
                {
                    dg1.ItemsSource = pvz.OrdersClients.ToList();
                }
                else
                {
                    dg1.ItemsSource = pvz.OrdersClients.ToList().Where(item => item.ClientID == Convert.ToInt32(search.Text));
                }
            }
            catch
            {

            }
        }

        private void filter_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = pvz.OrdersClients.ToList();
        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cb1.SelectedItem);
                dg1.ItemsSource = pvz.OrdersClients.ToList().Where(item => item.OrderID == id);
            }
            catch
            {

            }
        }
    }
}
