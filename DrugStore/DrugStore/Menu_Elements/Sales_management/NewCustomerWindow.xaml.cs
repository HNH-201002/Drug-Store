using DrugStore.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NewCustomerWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        int id;
        string name;
        string gender;
        int phone;
        string email;
        DateTime startAcc;
        string description;
        string status;
        string pathImage;
        private CustomerViewModel _viewModel;
        private OldCustomerUserControl _userControl;
        Customer customer;
        public NewCustomerWindow(OldCustomerUserControl oldCustomerUserControl)
        {
            InitializeComponent();
            _userControl = new OldCustomerUserControl();
            if (oldCustomerUserControl != null)
            {
                _userControl = oldCustomerUserControl;
            }
            _viewModel = new CustomerViewModel();
        }
        private void NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            name = txtCustomerName.Text;
            gender = cmbGender.Text;
            if (!int.TryParse(txtPhone.Text, out phone) || txtPhone.Text.Length < 10)
            {
                // Nếu giá trị của txtPhone không thể chuyển đổi sang kiểu int hoặc số điện thoại không đủ 9 số, xử lý lỗi tại đây
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }
            email = txtEmail.Text;
            bool isValidEmail = Regex.IsMatch(email, @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");
            if (!isValidEmail)
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!");
                return;
            }
            startAcc = DateTime.Now;
            description = txtDescription.Text;
            status = txtStatus.Text;

            id = _viewModel.Customers.Count;
            if (string.IsNullOrEmpty(pathImage))
            {
                // If pathImage is null or empty, set it to the default image path
                pathImage = "Resources\\Icon\\DefaultAvatar.jpg";
            }

            // Tạo đối tượng Drug
            customer = new Customer(id, pathImage, name, gender, phone.ToString(), email, startAcc, description, status);

            _viewModel.Add(customer);

            _viewModel.SaveCustomerData();
            _userControl.LoadFile();
            this.Hide();
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
    }
}
