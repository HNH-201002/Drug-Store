using DrugStore.ViewModel;
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

namespace DrugStore.Menu_Elements.Sales_management
{
    public partial class ManageOrderWindow : Window
    {
        float sum = 0;
        private OrderManage orderManages = new OrderManage();
        private OrderViewModel orderViewModel = new OrderViewModel();
        public ManageOrderWindow(OrderManage Order, OrderViewModel orderViewModel)
        {
            InitializeComponent();
            orderManages = Order;
            this.orderViewModel = orderViewModel;
            this.DataContext = Order;
        }

        private void UpdateOrderList()
        {
            sum = 0;
            listViewOrder.ItemsSource = null;
            listViewOrder.ItemsSource = orderManages.Order;
            foreach (Order order in orderManages.Order)
            {
                if (order != null)
                {
                    sum += order.Sum;
                }
            }
            TxtSumOrder.Text = sum.ToString();
        }
        private void UpQuantity_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Order order = (Order)btn.DataContext;
            order.Quantity++;
            if (orderManages.Order.Contains(order))
            {
                int index = orderManages.Order.IndexOf(order);
                orderManages.Order[index] = order;
            }
            UpdateOrderList();
            orderViewModel.SaveOrderData();
        }

        private void DownQuantity_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Order order = (Order)btn.DataContext;
            order.Quantity--;
            if (orderManages.Order.Contains(order))
            {
                int index = orderManages.Order.IndexOf(order);
                orderManages.Order[index] = order;
            }
            UpdateOrderList();
            orderViewModel.SaveOrderData();
        }
        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Order order = (Order)btn.DataContext;
            orderManages.Order.Remove(order);
            UpdateOrderList();
            orderViewModel.SaveOrderData();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            orderViewModel.DeleteOrder(orderManages);
            orderViewModel.SaveOrderData();
            this.Hide();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            OrderManage updatedOrder = new OrderManage();
            updatedOrder = orderManages;

            orderViewModel.EditOrder(orderManages, updatedOrder);
            orderViewModel.SaveOrderData();
            this.Hide();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
