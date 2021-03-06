﻿using System;
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
using System.ComponentModel;

namespace NorthwndCMS.App.UI
{
    /// <summary>
    /// Interaction logic for OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : ListWindow
    {
        #region Properties

        public Northwind Northwind { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }
        public Paginator<Order> Paginator { get; private set; }

        #endregion

        #region Construct

        public OrderListWindow(Northwind northwind, IEnumerable<Order> orders)
        {
            InitializeComponent();

            Northwind = northwind;
            Orders = orders;
            Paginator = new Paginator<Order>(Orders);
            List = OrderList;

            OrderList.ItemsSource = Paginator.Current();
            PageLabel.Content = Paginator.ToString();
        }

        #endregion

        #region Pagination Event Handlers

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.ItemsSource = Paginator.Next();
            PageLabel.Content = Paginator.ToString();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.ItemsSource = Paginator.Previous();
            PageLabel.Content = Paginator.ToString();
        }

        #endregion

        #region CRUD Button Event Handlers

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Order order in OrderList.SelectedItems)
            {
                Northwind.OrderDetails.DeleteAllOnSubmit(order.OrderDetails);
                Northwind.Orders.DeleteOnSubmit(order);
            }
            Northwind.SubmitChanges();

            OrderList.ItemsSource = Paginator.Current();
            PageLabel.Content = Paginator.ToString();
        }

        #endregion
    }
}
