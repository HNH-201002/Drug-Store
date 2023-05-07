using DrugStore.ViewModel;
using Microsoft.Win32;
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

namespace DrugStore.Menu_Elements.Inventory
{
    public partial class NewDrug : Window
    {
        Drug drug;

        int id;
        int quantity;
        DateTime importDate;
        DateTime expirationDate;
        string drugName;
        string drugType;
        string drugUnit;
        string description;
        string pathImage;
        float price;
        private DrugViewModel _viewModel;

        public NewDrug(DrugViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
        }
        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Xử lý tìm kiếm theo Tên sản phẩm
            // Cập nhật danh sách sản phẩm hiển thị trên ListBox (lstProducts)
        }

        private void cmbProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý lọc theo Loại sản phẩm
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
        private void dpExpiration_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý lọc theo Thông tin hết hạn (ngày tối thiểu)
            // Cập nhật danh sách sản phẩm hiển thị trên ListBox (lstProducts)
        }
        private void dpImportDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý lọc theo Ngày nhập hàng (ngày tối thiểu)
            // Cập n
        }
        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Mở hộp thoại chọn đường dẫn đến ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*jpgeg;*.jpg;*.png;*.bmp)|*jpgeg;*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // Lấy đường dẫn đến ảnh được chọn
                string imagePath = openFileDialog.FileName;


                Button button = (Button)sender;
                Image image = (Image)button.Template.FindName("PART_Image", button);
                image.Source = new BitmapImage(new Uri(imagePath));

                pathImage = imagePath;
                TextBlock textChooseAvatar = (TextBlock)button.Template.FindName("TextChooseAvatar", button);
                textChooseAvatar.Text = "";

            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            drugName = txtDrugName.Text;
            drugType = cmbDrugType.Text;
            if (!float.TryParse(txtPrice.Text, out price))
            {
                // Nếu giá trị của txtPrice không thể chuyển đổi sang kiểu float, xử lý lỗi tại đây
                MessageBox.Show("Giá tiền không hợp lệ!");
                return;
            }

            drugUnit = cmbDrugUnit.Text;
            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
            {
                // Nếu giá trị của txtQuantity không thể chuyển đổi sang kiểu int hoặc là số âm, xử lý lỗi tại đây
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            importDate = dpImportDate.SelectedDate.GetValueOrDefault();
            expirationDate = dpExpirationDate.SelectedDate.GetValueOrDefault();
            description = txtDescription.Text;

            // Kiểm tra các giá trị có null hay không phù hợp trước khi thêm vào inventoryData
            if (string.IsNullOrEmpty(drugName) || string.IsNullOrEmpty(drugType) || string.IsNullOrEmpty(drugUnit) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(pathImage))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            int countNode = _viewModel._binarySearchTree.CountNodes();

            id = (countNode + 1);
            // Tạo đối tượng Drug
            drug = new Drug(id, pathImage, drugName, drugType, price, drugUnit, quantity, importDate, expirationDate, description);

            _viewModel.AddDrug(drug);

            _viewModel.SaveDrugData();

            this.Hide();
        }
    }
}
