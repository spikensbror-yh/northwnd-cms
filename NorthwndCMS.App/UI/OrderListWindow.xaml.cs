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
using NorthwndCMS.Data;

namespace NorthwndCMS.App.UI
{
    /// <summary>
    /// Interaction logic for OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        public Northwind Northwind { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }
        public Pagination<Order> Page { get; private set; }

        public OrderListWindow(Northwind northwind, IEnumerable<Order> orders)
        {
            InitializeComponent();

            Northwind = northwind;
            Orders = orders;

            Page = new Pagination<Order>(Orders);
            OrderList.ItemsSource = Page.Current();
            PageLabel.Content = Page.ToString();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.ItemsSource = Page.Next();
            PageLabel.Content = Page.ToString();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.ItemsSource = Page.Previous();
            PageLabel.Content = Page.ToString();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = OrderList.SelectedItems;
            foreach (Order order in selected)
            {
                Northwind.Orders.DeleteOnSubmit(order);
            }

            Northwind.SubmitChanges();
            OrderList.Items.Refresh();
        }
    }
}
