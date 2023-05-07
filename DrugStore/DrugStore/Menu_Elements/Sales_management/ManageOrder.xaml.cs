using DrugStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DrugStore.Menu_Elements.Sales_management
{
    public partial class ManageOrder : UserControl
    {
        private OrderViewModel OrderViewModel { get; set; }
        private List<OrderManage> orderManages;
        public ManageOrder()
        {
            InitializeComponent();
            OrderViewModel = new OrderViewModel();
            OrderViewModel.LoadOrderData();
            this.DataContext = OrderViewModel;
        }

        private void ListViewItemSelected(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng đơn hàng được chọn
            OrderManage selectedOrder = (OrderManage)listView.SelectedItem;

            // Kiểm tra nếu có đơn hàng được chọn
            if (selectedOrder != null)
            {

                ManageOrderWindow manageOrderWindow = new ManageOrderWindow(selectedOrder, OrderViewModel);
                manageOrderWindow.Show();
            }
            // Khởi tạo dữ liệu mẫu
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox != null)
            {
                var searchTerm = SearchTextBox.Text;
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    // Nếu đầu vào không phải số, tìm kiếm theo tên
                    CultureInfo cultureInfo = CultureInfo.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;
                    searchTerm = textInfo.ToTitleCase(searchTerm);
                    orderManages = OrderViewModel.Search(searchTerm);

                    listView.ItemsSource = orderManages;
                }
                else
                {
                    listView.ItemsSource = OrderViewModel.Orders;
                }
            }
        }
    }
}
