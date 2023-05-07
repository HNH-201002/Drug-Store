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
    /// <summary>
    /// Interaction logic for NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        private DrugViewModel drugViewModel;
        private OrderViewModel orderViewModel;
        private List<Order> orders;
        List<Drug> drugs = new List<Drug>();
        float sum = 0;
        Customer customer;
        public NewOrderWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            orders = new List<Order>();
            orderViewModel = new OrderViewModel();
            drugViewModel = new DrugViewModel();
            drugViewModel.LoadDrugData();
            orderViewModel.LoadOrderData();
            listView.ItemsSource = drugViewModel.Drugs;

        }
        private void ListViewItemSelected(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng đơn hàng được chọn
            Drug selectedOrder = (Drug)listView.SelectedItem;

            // Kiểm tra nếu có đơn hàng được chọn
            if (selectedOrder != null)
            {
                AddToOrder(selectedOrder);
            }
            // Khởi tạo dữ liệu mẫu
        }
        private void UpdateOrderList()
        {
            sum = 0;
            listViewOrder.ItemsSource = null;
            listViewOrder.ItemsSource = orders;
            foreach (Order order in orders)
            {
                if (order != null)
                {
                    sum += order.Sum;
                }
            }
            TxtSumOrder.Text = sum.ToString();
        }

        private void AddToOrder(Drug selectedOrder)
        {
            Order orderElement = new Order();
            orderElement.Avatar = selectedOrder.Avatar;
            orderElement.Name = selectedOrder.Name;
            orderElement.Quantity = 1;
            orderElement.Price = selectedOrder.Price;
            foreach (Order order in orders)
            {
                if (order.Name == selectedOrder.Name)
                {
                    order.Quantity++;
                    UpdateOrderList();
                    return;
                }
            }
            orderElement.ID = orders.Count;
            orders.Add(orderElement);
            UpdateOrderList();
        }

        // Xóa sản phẩm khỏi danh sách đơn hàng
        private void RemoveFromOrder(Order selectedOrder)
        {
            if (orders.Contains(selectedOrder))
            {
                orders.Remove(selectedOrder);
                UpdateOrderList();
            }
        }

        // Sửa thông tin sản phẩm trong danh sách đơn hàng
        private void EditOrderItem(Order selectedOrder, int newQuantity)
        {
            if (orders.Contains(selectedOrder))
            {
                selectedOrder.Quantity = newQuantity;
                UpdateOrderList();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox != null)
            {
                var searchTerm = SearchTextBox.Text;

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    drugs = drugViewModel.Search(searchTerm);
                    listView.ItemsSource = drugs;
                }
                else
                {
                    listView.ItemsSource = drugViewModel.Drugs;
                }
            }
        }

        private void UpQuantity_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Order order = (Order)btn.DataContext;
            order.Quantity++;
            UpdateOrderList();
        }

        private void DownQuantity_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Order order = (Order)btn.DataContext;
            order.Quantity--;
            UpdateOrderList();
        }
        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Order order = (Order)btn.DataContext;
            orders.Remove(order);
            UpdateOrderList();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            SaveCustomerData();
            int days;
            if (TxtTimeRefund.Text == null || !int.TryParse(TxtTimeRefund.Text, out days))
            {
                MessageBox.Show("Invalid Refund Time");
                return;
            }
            this.Hide();
        }
        public void SaveCustomerData()
        {

            OrderManage orderManage = new OrderManage();
            orderManage.Customer = customer;
            orderManage.Order = orders;
            orderManage.Sum = sum;
            orderManage.ID = orderViewModel._linkedList.Count();
            orderManage.OrderDate = DateTime.Now;
            int days;
            if (TxtTimeRefund.Text == null || !int.TryParse(TxtTimeRefund.Text, out days))
            {
                return;
            }
            else
            {
                orderManage.RefundDueDate = DateTime.Now.AddDays(days);
            }
            orderViewModel.AddOrder(orderManage);
            orderViewModel.SaveOrderData();
        }
    }
}
