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
using NorthwndCMS.Data;

namespace NorthwndCMS.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Northwind _Northwind;

        public MainWindow()
        {
            InitializeComponent();
            _Northwind = new Northwind((string)Properties.Settings.Default["Database"]);
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new UI.OrderListWindow(_Northwind.Orders.ToList());
            window.Show();
        }
    }
}
