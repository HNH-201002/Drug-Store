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
    public partial class ManageCustomer : UserControl
    {
        private CustomerViewModel CustomerViewModel;
        private List<Customer> _customers;
        public ManageCustomer()
        {
            InitializeComponent();
            CustomerViewModel = new CustomerViewModel();
            CustomerViewModel.LoadCustomerData();
            listView.ItemsSource = CustomerViewModel.Customers;
        }
        public void LoadFile()
        {
            CustomerViewModel.LoadCustomerData();
        }
        // Định nghĩa lớp Order đại diện cho đối tượng Order
        private void ListViewItemSelected(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng đơn hàng được chọn
            Customer selectedOrder = (Customer)listView.SelectedItem;

            // Kiểm tra nếu có đơn hàng được chọn
            if (selectedOrder != null)
            {

                CustomerWindow customerWindow = new CustomerWindow(selectedOrder, CustomerViewModel);
                customerWindow.Show();
            }
            // Khởi tạo dữ liệu mẫu
        }

        private void NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            NewCustomerWindow newCustomerWindow = new NewCustomerWindow(null);
            newCustomerWindow.Show();
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox != null)
            {
                var searchTerm = SearchTextBox.Text;
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    if (int.TryParse(searchTerm, out int phoneNumber))
                    {
                        // Nếu đầu vào là số, tìm kiếm theo số điện thoại
                        _customers = CustomerViewModel.SearchByPhone(phoneNumber.ToString());
                    }
                    else
                    {
                        // Nếu đầu vào không phải số, tìm kiếm theo tên
                        CultureInfo cultureInfo = CultureInfo.CurrentCulture;
                        TextInfo textInfo = cultureInfo.TextInfo;
                        searchTerm = textInfo.ToTitleCase(searchTerm);
                        _customers = CustomerViewModel.SearchByName(searchTerm);
                    }
                    listView.ItemsSource = _customers;
                }
                else
                {
                    listView.ItemsSource = CustomerViewModel.Customers;
                }
            }
        }
    }
}
