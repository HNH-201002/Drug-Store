using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DrugStore.Menu_Elements;

namespace DrugStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Menu.Width = 80;
            Content.Margin = new Thickness(74, 0, 0, 0);
        }
        private void ShowContextMenuCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (sender is TreeViewItem treeViewItem)
            {
                ContextMenu contextMenu = treeViewItem.ContextMenu;
                if (contextMenu != null)
                {
                    contextMenu.PlacementTarget = treeViewItem;
                    contextMenu.Placement = PlacementMode.Left;
                    contextMenu.IsOpen = true;
                }
            }
        }
        private void menuTreeviewToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Menu.Width = double.NaN;
            Content.Margin = new Thickness(132, 0, 0, 0);

            //New Order
            TreeViewItem newOrderItem = FindVisualChild<TreeViewItem>(menuTreeview);
            Image newOrderIcon = FindVisualChild<Image>(NewOrderItem);
            TextBlock newOrderText = FindVisualChild<TextBlock>(NewOrderItem);
            UpdateVisibility(newOrderItem, newOrderIcon, newOrderText);

            //Finance
            TreeViewItem financeItem = FindVisualChild<TreeViewItem>(menuTreeview);
            Image financeIcon = FindVisualChild<Image>(FinanceItem);
            TextBlock financeText = FindVisualChild<TextBlock>(FinanceItem);
            UpdateVisibility(financeItem, financeIcon, financeText);

            //Inventory
            TreeViewItem inventoryItem = FindVisualChild<TreeViewItem>(menuTreeview);
            Image inventoryIcon = FindVisualChild<Image>(InventoryItem);
            TextBlock inventoryText = FindVisualChild<TextBlock>(InventoryItem);
            UpdateVisibility(inventoryItem, inventoryIcon, inventoryText);


            //Customer
            TreeViewItem customerSupportItem = FindVisualChild<TreeViewItem>(menuTreeview);
            Image SettingsIcon = FindVisualChild<Image>(Settings);
            TextBlock SettingsText = FindVisualChild<TextBlock>(Settings);
            UpdateVisibility(customerSupportItem, SettingsIcon, SettingsText);
        }
        private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            if (obj == null)
            {
                return null;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }

                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }

            return null;
        }
        private void UpdateVisibility(TreeViewItem treeViewItem, Image icon, TextBlock textBlock)
        {
            if (icon != null && textBlock != null)
            {
                if (icon.Visibility != Visibility.Collapsed)
                {
                    icon.Visibility = Visibility.Collapsed;
                    textBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    icon.Visibility = Visibility.Visible;
                    textBlock.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void menuTreeviewToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            // Khi toggle button không được kiểm tra, đặt Width của TreeView là Auto để mở rộng lại
            Menu.Width = 80;
            Content.Margin = new Thickness(74, 0, 0, 0);
            //New Order
            TreeViewItem newOrderItem = FindVisualChild<TreeViewItem>(menuTreeview);
            Image newOrderIcon = FindVisualChild<Image>(NewOrderItem);
            TextBlock newOrderText = FindVisualChild<TextBlock>(NewOrderItem);
            UpdateVisibility(newOrderItem, newOrderIcon, newOrderText);

            //Finance
            TreeViewItem financeItem = FindVisualChild<TreeViewItem>(menuTreeview);
            Image financeIcon = FindVisualChild<Image>(FinanceItem);
            TextBlock financeText = FindVisualChild<TextBlock>(FinanceItem);
            UpdateVisibility(financeItem, financeIcon, financeText);

            //Inventory
            TreeViewItem inventoryItem = FindVisualChild<TreeViewItem>(menuTreeview);
            Image inventoryIcon = FindVisualChild<Image>(InventoryItem);
            TextBlock inventoryText = FindVisualChild<TextBlock>(InventoryItem);
            UpdateVisibility(inventoryItem, inventoryIcon, inventoryText);


            //Customer
            TreeViewItem customerSupportItem = FindVisualChild<TreeViewItem>(menuTreeview);
            Image customerSupportIcon = FindVisualChild<Image>(Settings);
            TextBlock customerSupportText = FindVisualChild<TextBlock>(Settings);
            UpdateVisibility(customerSupportItem, customerSupportIcon, customerSupportText);

        }
        private void menuTreeview_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Xử lý sự kiện khi mục được chọn trong menu thay đổi
            TreeView treeView = sender as TreeView;
            //BackGround.Visibility = Visibility.Collapsed;
            if (treeView.SelectedItem != null)
            {
                TreeViewItem selectedItem = treeView.SelectedItem as TreeViewItem;
                string selectedItemTag = selectedItem.Tag as string;
                // Mở cửa sổ tương ứng với tag của mục được chọn
                // Ví dụ:
                switch (selectedItemTag)
                {
                    case "SettingUserControl":
                        MainFrame.Content = new SettingUserControl();
                        break;

                    case "EmployeeWindow":
                        // Mở cửa sổ nhân viên
                        MainFrame.Content = new EmployeeUserControl();
                        break;

                    case "FinanceWindow":
                        // Mở cửa sổ tài chính
                        MainFrame.Content = new FinanceUserControl();
                        break;

                    case "InventoryWindow":
                        // Mở cửa sổ quản lý kho
                        MainFrame.Content = new InventoryUserControl();
                        break;

                    case "NewOrderWindow":
                        // Mở cửa sổ đặt hàng mới
                        MainFrame.Content = new SalesManagementUserControl();
                        break;

                    default:
                        // Mở cửa sổ mặc định nếu không có tag nào phù hợp
                        MainFrame.Content = new DefaultUserControl();
                        break;
                }
            }
        }
    }
}
