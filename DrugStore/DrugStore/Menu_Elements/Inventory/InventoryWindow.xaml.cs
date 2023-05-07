using DrugStore.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class InventoryWindow : Window
    {
        private Drug _originalDrug;
        private Drug _newDrug;
        private DrugViewModel _drugViewModel;
        private bool isDrugChanged = false;

        int id;
        int quantity;
        DateTime importDate;
        DateTime expirationDate;
        string drugName;
        string drugType;
        string drugUnit;
        string description;
        string imagePath;
        float price;
        public InventoryWindow(Drug drugs, DrugViewModel drugViewModel)
        {
            InitializeComponent();
            this._originalDrug = drugs;
            txtProductName.Text = drugs.Name;

            int indexProductType = cmbProductType.Items.IndexOf(cmbProductType.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == drugs.DrugTypes));
            cmbProductType.SelectedIndex = indexProductType;
            txtPrice.Text = drugs.Price.ToString();

            int indexProductUnit = cmbProductUnit.Items.IndexOf(cmbProductUnit.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == drugs.DrugUnits));
            cmbProductUnit.SelectedIndex = indexProductUnit;
            txtQuantity.Text = drugs.Quantity.ToString();
            ImportDatePicker.SelectedDate = drugs.ImportDate;
            ExpirationDatePicker.SelectedDate = drugs.ExpiryDate;
            Description.Text = drugs.Description;
            Console.WriteLine(drugs.Avatar);
            ButtonAvatar.DataContext = new { AvatarPath = drugs.Avatar };
            imagePath = drugs.Avatar;
            _drugViewModel = drugViewModel;
        }

        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDrugChanged = true;
        }

        private void cmbProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isDrugChanged = true;
        }

        private void cmbPriceOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isDrugChanged = true;
        }

        private void cmbQuantityOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isDrugChanged = true;
        }
        private void dpExpiration_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            isDrugChanged = true;
        }
        private void dpImportDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            isDrugChanged = true;
        }
        private void CreateButton_Click(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Mở hộp thoại chọn đường dẫn đến ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*jpgeg;*.jpg;*.png;*.bmp)|*jpgeg;*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;

                Button button = (Button)sender;
                Image image = (Image)button.Template.FindName("PART_Image", button);
                image.Source = new BitmapImage(new Uri(imagePath));

            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (isDrugChanged)
            {
                drugName = txtProductName.Text;
                drugType = cmbProductType.Text;
                if (!float.TryParse(txtPrice.Text, out price))
                {
                    // Nếu giá trị của txtPrice không thể chuyển đổi sang kiểu float, xử lý lỗi tại đây
                    MessageBox.Show("Giá tiền không hợp lệ!");
                    return;
                }

                drugUnit = cmbProductUnit.Text;
                if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
                {
                    // Nếu giá trị của txtQuantity không thể chuyển đổi sang kiểu int hoặc là số âm, xử lý lỗi tại đây
                    MessageBox.Show("Số lượng không hợp lệ!");
                    return;
                }

                importDate = ImportDatePicker.SelectedDate.GetValueOrDefault();
                expirationDate = ExpirationDatePicker.SelectedDate.GetValueOrDefault();
                description = Description.Text;


                // Kiểm tra các giá trị có null hay không phù hợp trước khi thêm vào inventoryData
                if (string.IsNullOrEmpty(drugName) || string.IsNullOrEmpty(drugType) || string.IsNullOrEmpty(drugUnit) || string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }
                int countNode = _drugViewModel._binarySearchTree.CountNodes();
                id = countNode;
                // Tạo đối tượng Drug
                _newDrug = new Drug(id, imagePath, drugName, drugType, price, drugUnit, quantity, importDate, expirationDate, description);

                _drugViewModel.EditDrug(_originalDrug, _newDrug);
                this.Hide();
            }
            else
            {
                this.Hide();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int countNode = _drugViewModel._binarySearchTree.CountNodes();
            id = countNode;
            _drugViewModel.DeleteDrug(_originalDrug);
            _drugViewModel.SaveDrugData();
            this.Hide();
        }
    }
}
