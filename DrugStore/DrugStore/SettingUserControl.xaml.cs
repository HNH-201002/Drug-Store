using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DrugStore
{
    /// <summary>
    /// Interaction logic for SettingUserControl.xaml
    /// </summary>
    public partial class SettingUserControl : UserControl
    {
        public string _filePath;
        private string _FilePath;
        public SettingUserControl()
        {
            InitializeComponent();
            LoadFileAddress();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderDialog.Description = "Select folder to save file";
            folderDialog.RootFolder = Environment.SpecialFolder.MyComputer; // chỉ định thư mục cơ sở
            folderDialog.ShowNewFolderButton = true; // cho phép tạo mới thư mục

            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderPath = folderDialog.SelectedPath;
                PathTextBox.Text = folderPath;
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (PathTextBox.Text == _filePath)
            {
                return;
            }
            string filePath = PathTextBox.Text; // Lấy đường dẫn từ TextBox
            string fileName = "AddressSaveFile.json";
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            // Kiểm tra đường dẫn có hợp lệ không
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Please enter a valid file path.");
                return;
            }

            try
            {
                // Lưu file tại đường dẫn được chỉ định
                var json = JsonConvert.SerializeObject(filePath); // Chuyển đổi nội dung sang định dạng JSON
                File.WriteAllText(System.IO.Path.Combine(folderPath, fileName), json); // Lưu vào file tại đường dẫn và tên file được chỉ định

                MessageBox.Show("File saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}");
            }
        }
        private void LoadFileAddress()
        {
            string fileName = "AddressSaveFile.json";
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = System.IO.Path.Combine(folderPath, fileName);
            if (!File.Exists(filePath))
            {
                //MessageBox.Show("Make sure that you have specified the location to save the file");
                return;
            }
            string json = File.ReadAllText(filePath);

            string path = json.Replace("\\\\", "\\");
            path = path.Replace("\"", "");
            PathTextBox.Text = $@"{path}";

            _filePath = json;
            _FilePath = @PathTextBox.Text;
        }
        public string GetFileAddress(string nameFile)
        {
            LoadFileAddress();
            if (File.Exists(System.IO.Path.Combine(_FilePath, nameFile)))
            {
                return System.IO.Path.Combine(_FilePath, nameFile);
            }
            else
            {
                return null;
            }
        }

    }
}
