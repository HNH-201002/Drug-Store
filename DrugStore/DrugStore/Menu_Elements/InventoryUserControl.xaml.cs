using DrugStore.Menu_Elements.Inventory;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrugStore.Menu_Elements
{
    /// <summary>
    /// Interaction logic for InventoryUserControl.xaml
    /// </summary>
    public partial class InventoryUserControl : UserControl
    {
        public DrugViewModel ViewModel { get; set; }
        DrugViewModel currentDrugViewModel = new DrugViewModel();
        DrugViewModel drugViewModelSearchName = new DrugViewModel();
        DrugViewModel drugViewModelSearchType = new DrugViewModel();
        DrugViewModel drugViewModelFilterPrice = new DrugViewModel();
        DrugViewModel drugViewModelFilterQuantity = new DrugViewModel();
        DrugViewModel drugViewModelFilterExpiry = new DrugViewModel();
        public InventoryUserControl()
        {
            InitializeComponent();
            drugViewModelSearchType.Clear();
            drugViewModelFilterPrice.Clear();
            currentDrugViewModel.Clear();
            drugViewModelFilterExpiry.Clear();
            ViewModel = new DrugViewModel();
            ViewModel.LoadDrugData();
            DataContext = ViewModel;
            cmbProductType.SelectedIndex = 0;
            cmbExpirationOption.SelectedIndex = 0;
            cmbPriceOption.SelectedIndex = 0;
            cmbQuantityOption.SelectedIndex = 0;
        }

        private void ListViewItemSelected(object sender, RoutedEventArgs e)
        {

            Drug selectedOrder = (Drug)drugListView.SelectedItem;

            // Kiểm tra nếu có đơn hàng được chọn
            if (selectedOrder != null)
            {
                InventoryWindow inventoryWindow = new InventoryWindow(selectedOrder, ViewModel);
                inventoryWindow.Show();
            }
            else
            {
                // Thông báo cho người dùng chọn một phần tử trước khi tiếp tục
                MessageBox.Show("Please select an item first.");
            }
        }
        public void LoadFile()
        {

        }
        private void NewData_Click(object sender, RoutedEventArgs e)
        {
            NewDrug newDrug = new NewDrug(ViewModel);
            newDrug.Show();
        }
        private void txtProductCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Xử lý tìm kiếm theo Mã sản phẩm
            // Cập nhật danh sách sản phẩm hiển thị trên ListBox (lstProducts)
        }

        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Xử lý tìm kiếm theo Tên sản phẩm
            // Cập nhật danh sách sản phẩm hiển thị trên ListBox (lstProducts)
        }

        private void cmbPriceOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý sự kiện khi lựa chọn thay đổi trong cmbPriceOption
            // Thêm mã xử lý tương ứng vào đây
        }

        private void cmbQuantityOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý sự kiện khi lựa chọn thay đổi trong cmbQuantityOption
            // Thêm mã xử lý tương ứng vào đây
        }
        private void dpMinExpiration_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý lọc theo Thông tin hết hạn (ngày tối thiểu)
            // Cập nhật danh sách sản phẩm hiển thị trên ListBox (lstProducts)
        }

        private void dpMaxExpiration_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý lọc theo Thông tin hết hạn (ngày tối đa)
            // Cập nhật danh sách sản phẩm hiển thị trên ListBox (lstProducts)
        }

        private void dpMinImportDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý lọc theo Ngày nhập hàng (ngày tối thiểu)
            // Cập n
        }
        private void dpMaxImportDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý lọc theo Ngày nhập hàng (ngày tối đa)
            // Cập nhật danh sách sản phẩm hiển thị trên ListBox (lstProducts)
        }

        private void cmbProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbProductType.SelectedIndex == 0 && !string.IsNullOrWhiteSpace(Search_Text.Text))
            {
                DataContext = drugViewModelSearchName;
                drugViewModelSearchType.Clear();
                return;
            }
            else if (cmbProductType.SelectedIndex == 0 && string.IsNullOrWhiteSpace(Search_Text.Text))
            {
                DataContext = ViewModel;
                drugViewModelSearchType.Clear();
                return;
            }
            if (cmbProductType.SelectedIndex != 0 && !string.IsNullOrWhiteSpace(Search_Text.Text))
            {
                string selectedProductType = cmbProductType.SelectedItem.ToString();
                drugViewModelSearchType.Clear();
                foreach (Drug result in drugViewModelSearchName.Drugs)
                {
                    if (result.DrugTypes.Equals((cmbProductType.SelectedItem as ComboBoxItem).Content.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        drugViewModelSearchType.AddDrug(result);
                    }
                }

                DataContext = drugViewModelSearchType;
            }
            else if (cmbProductType.SelectedIndex != 0 && string.IsNullOrWhiteSpace(Search_Text.Text))
            {
                string selectedProductType = cmbProductType.SelectedItem.ToString();
                drugViewModelSearchType.Clear();
                foreach (Drug result in ViewModel.Drugs)
                {
                    if (result.DrugTypes.Equals((cmbProductType.SelectedItem as ComboBoxItem).Content.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        drugViewModelSearchType.AddDrug(result);
                    }
                }
                DataContext = drugViewModelSearchType;
            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex == 0)
            {
                drugViewModelSearchName.Clear();
                drugViewModelSearchType.Clear();
                DataContext = ViewModel;
            }
            else if (string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex != 0)
            {
                drugViewModelSearchType.Clear();
                foreach (Drug result in ViewModel.Drugs)
                {
                    if (result.DrugTypes.Equals((cmbProductType.SelectedItem as ComboBoxItem).Content.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        drugViewModelSearchType.AddDrug(result);
                    }
                }

                DataContext = drugViewModelSearchType;
            }
            else if (!string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex != 0)
            {
                drugViewModelSearchType.Clear();
                int count = 0;
                string searching = Search_Text.Text;
                List<Drug> searchResults = currentDrugViewModel.Search(searching);
                drugViewModelSearchName.Clear();
                foreach (Drug result in searchResults)
                {
                    drugViewModelSearchName.AddDrug(result);
                    count++;
                }

                string selectedProductType = cmbProductType.SelectedItem.ToString();

                foreach (Drug result in drugViewModelSearchName.Drugs)
                {
                    if (result.DrugTypes.Equals((cmbProductType.SelectedItem as ComboBoxItem).Content.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        drugViewModelSearchType.AddDrug(result);
                    }
                }

                DataContext = drugViewModelSearchType;
            }
            else
            {
                int count = 0;
                string searching = Search_Text.Text;
                if (cmbProductType.SelectedItem == null || cmbProductType.SelectedIndex == 0)
                {
                    cmbProductType.SelectedIndex = 0;
                }

                List<Drug> searchResults = ViewModel.Search(searching);
                drugViewModelSearchName.Clear();
                foreach (Drug result in searchResults)
                {
                    drugViewModelSearchName.AddDrug(result);
                    count++;
                }
                DataContext = drugViewModelSearchName;
            }

        }
        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex == 0)
            {
                HandleSort(ViewModel);

            }
            else if (!string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex == 0)
            {
                HandleSort(drugViewModelSearchName);
            }
            else if (string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex != 0)
            {
                HandleSort(drugViewModelSearchType);
            }
            else
            {
                HandleSort(drugViewModelSearchType);
            }
        }
        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbPriceOption_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbPriceOption.SelectedIndex == 0)
            {
                if (string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex == 0)
                {
                    DataContext = ViewModel;

                }
                else if (!string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex == 0)
                {
                    DataContext = drugViewModelSearchName;
                }
                else if (string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex != 0)
                {
                    DataContext = drugViewModelSearchType;
                }
                else
                {
                    DataContext = drugViewModelSearchType;
                }
            }
        }
        private void HandleSort(DrugViewModel viewModelSort)
        {
            if (txtExpirationDate.Text == "") txtExpirationDate.Text = (0).ToString();
            if (txtQuantity.Text == "") txtQuantity.Text = (0).ToString();
            if (txtPrice.Text == "") txtPrice.Text = (0).ToString();

            if (!int.TryParse(txtExpirationDate.Text, out int expirationDate))
            {
                txtExpirationDate.Text = "0";
            }
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                txtQuantity.Text = "0";
            }
            if (!int.TryParse(txtPrice.Text, out int price))
            {
                txtPrice.Text = "0";
            }
            if (cmbPriceOption.SelectedIndex == 0 && cmbQuantityOption.SelectedIndex == 0 && cmbExpirationOption.SelectedIndex == 0)
            {
                return;
            }
            else if (cmbPriceOption.SelectedIndex != 0 && cmbQuantityOption.SelectedIndex == 0 && cmbExpirationOption.SelectedIndex == 0)
            {
                HandlePriceSort(viewModelSort);
            }
            else if (cmbPriceOption.SelectedIndex == 0 && cmbQuantityOption.SelectedIndex != 0 && cmbExpirationOption.SelectedIndex == 0)
            {
                HandleQuantitySort(viewModelSort);
            }
            else if (cmbPriceOption.SelectedIndex == 0 && cmbQuantityOption.SelectedIndex == 0 && cmbExpirationOption.SelectedIndex != 0)
            {
                HandleExpirySort(viewModelSort);
            }
            else if (cmbPriceOption.SelectedIndex != 0 && cmbQuantityOption.SelectedIndex != 0 && cmbExpirationOption.SelectedIndex == 0)
            {
                HandlePriceSort(viewModelSort);
                HandleQuantitySort(drugViewModelFilterPrice);
            }
            else if (cmbPriceOption.SelectedIndex != 0 && cmbQuantityOption.SelectedIndex == 0 && cmbExpirationOption.SelectedIndex != 0)
            {
                HandlePriceSort(viewModelSort);
                HandleExpirySort(drugViewModelFilterPrice);
            }
            else if (cmbPriceOption.SelectedIndex == 0 && cmbQuantityOption.SelectedIndex != 0 && cmbExpirationOption.SelectedIndex != 0)
            {
                HandleQuantitySort(viewModelSort);
                HandleExpirySort(drugViewModelFilterQuantity);
            }
            else
            {
                HandlePriceSort(viewModelSort);
                HandleQuantitySort(drugViewModelFilterPrice);
                HandleExpirySort(drugViewModelFilterQuantity);
            }
        }

        private void HandlePriceSort(DrugViewModel viewModelSort)
        {
            switch (cmbPriceOption.SelectedIndex) // price
            {
                case 0: //Nothing
                    if (string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex == 0)
                    {
                        DataContext = ViewModel;

                    }
                    else if (!string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex == 0)
                    {
                        DataContext = drugViewModelSearchName;
                    }
                    else if (string.IsNullOrWhiteSpace(Search_Text.Text) && cmbProductType.SelectedIndex != 0)
                    {
                        DataContext = drugViewModelSearchType;
                    }
                    else
                    {
                        DataContext = drugViewModelSearchType;
                    }
                    break;
                case 1: //Greater than
                    drugViewModelFilterPrice.Clear();
                    foreach (Drug result in viewModelSort.Drugs)
                    {
                        if (result.Price > float.Parse(txtPrice.Text))
                        {
                            drugViewModelFilterPrice.AddDrug(result);
                        }
                    }
                    DataContext = drugViewModelFilterPrice;
                    break;
                case 2: //less than
                    drugViewModelFilterPrice.Clear();
                    foreach (Drug result in viewModelSort.Drugs)
                    {
                        if (result.Price < float.Parse(txtPrice.Text))
                        {
                            drugViewModelFilterPrice.AddDrug(result);
                        }
                    }
                    DataContext = drugViewModelFilterPrice;
                    break;
                case 3: //equal
                    drugViewModelFilterPrice.Clear();
                    foreach (Drug result in viewModelSort.Drugs)
                    {
                        if (result.Price == float.Parse(txtPrice.Text))
                        {
                            drugViewModelFilterPrice.AddDrug(result);
                        }
                    }
                    DataContext = drugViewModelFilterPrice;
                    break;
                default:
                    break;
            }
        }
        private void HandleQuantitySort(DrugViewModel viewModelSort)
        {
            switch (cmbQuantityOption.SelectedIndex) // product
            {
                case 0: //Nothing
                    DataContext = viewModelSort;
                    break;
                case 1: //Greater than
                    drugViewModelFilterQuantity.Clear();
                    foreach (Drug result in viewModelSort.Drugs)
                    {
                        if (result.Quantity > int.Parse(txtQuantity.Text))
                        {
                            drugViewModelFilterQuantity.AddDrug(result);
                        }
                    }
                    DataContext = drugViewModelFilterQuantity;
                    break;
                case 2: //less than
                    drugViewModelFilterQuantity.Clear();
                    foreach (Drug result in viewModelSort.Drugs)
                    {
                        if (result.Quantity < int.Parse(txtQuantity.Text))
                        {
                            drugViewModelFilterQuantity.AddDrug(result);
                        }
                    }
                    DataContext = drugViewModelFilterQuantity;
                    break;
                case 3: //equal
                    drugViewModelFilterQuantity.Clear();
                    foreach (Drug result in viewModelSort.Drugs)
                    {
                        if (result.Quantity == int.Parse(txtQuantity.Text))
                        {
                            drugViewModelFilterQuantity.AddDrug(result);
                        }
                    }
                    DataContext = drugViewModelFilterQuantity;
                    break;
                default:
                    break;
            }
        }
        private void HandleExpirySort(DrugViewModel viewModelSort)
        {

            switch (cmbExpirationOption.SelectedIndex) // product
            {
                case 0: //Nothing
                    DataContext = viewModelSort;
                    break;
                case 1: //Greater than
                    drugViewModelFilterExpiry.Clear();
                    foreach (Drug result in viewModelSort.Drugs)
                    {
                        if (CalculateRemainDay(result) >= int.Parse(txtExpirationDate.Text))
                        {
                            drugViewModelFilterExpiry.AddDrug(result);
                        }
                    }
                    DataContext = drugViewModelFilterExpiry;
                    break;
                case 2: //expired
                    drugViewModelFilterExpiry.Clear();
                    foreach (Drug result in viewModelSort.Drugs)
                    {
                        if (CalculateRemainDay(result) < 0)
                        {
                            drugViewModelFilterExpiry.AddDrug(result);
                        }
                    }
                    DataContext = drugViewModelFilterExpiry;
                    break;
                default:
                    break;
            }
        }

        private int CalculateRemainDay(Drug result)
        {
            DateTime expiryDate = result.ExpiryDate;
            DateTime currentDate = DateTime.Now;

            int remainingDays = (expiryDate - currentDate).Days;

            if (remainingDays <= 0)
            {
                return remainingDays;
            }

            int remainingYears = expiryDate.Year - currentDate.Year;
            int remainingMonths = expiryDate.Month - currentDate.Month;

            if (remainingMonths < 0)
            {
                remainingYears--;
                remainingMonths += 12;
            }

            int remainingDaysInMonths = DateTime.DaysInMonth(currentDate.Year, currentDate.Month) - currentDate.Day;
            remainingDaysInMonths += expiryDate.Day;

            if (remainingMonths > 1)
            {
                for (int i = 1; i < remainingMonths; i++)
                {
                    remainingDaysInMonths += DateTime.DaysInMonth(currentDate.Year, currentDate.Month + i);
                }
            }

            remainingDays += remainingDaysInMonths + (remainingYears * 365);

            return remainingDays;
        }
    }
}
