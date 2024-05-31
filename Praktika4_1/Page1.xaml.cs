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
    public partial class Page1 : Page
    {
        private PunktVidachiZakazovEntities pvz = new PunktVidachiZakazovEntities();
        public Page1()
        {
            InitializeComponent();

            dg1.ItemsSource = pvz.Clients.ToList();

            cb1.ItemsSource = pvz.Clients.ToList();
            cb1.DisplayMemberPath = "ClientSurname";
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = pvz.Clients.ToList().Where(item => item.ClientName.Contains(search.Text));
        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var surname = cb1.SelectedItem as Clients;
                dg1.ItemsSource = pvz.Clients.ToList().Where(item => item as Clients == surname);
            }
            catch
            {

            }
        }

        private void filter_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = pvz.Clients.ToList();
        }
    }
}
