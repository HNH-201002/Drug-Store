using DrugStore.Menu_Elements.Sales_management;
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
    /// Interaction logic for SalesManagementUserControl.xaml
    /// </summary>
    public partial class SalesManagementUserControl : UserControl
    {
        public SalesManagementUserControl()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Header(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = e.OriginalSource as MenuItem; // Ép kiểu thành MenuItem
            if (menuItem != null)
            {
                switch (menuItem.Header)
                {
                    case "Old customers": // Tên của MenuItem
                        MainSalesManagementFrame.Content = new OldCustomerUserControl();
                        break;
                    case "Manage Order":
                        MainSalesManagementFrame.Content = new ManageOrder();
                        break;
                    default:
                        // Xử lý cho các MenuItem khác
                        break;
                }
            }
        }
        private void MenuItem_Click_Tooltip(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = e.OriginalSource as MenuItem; // Ép kiểu thành MenuItem
            if (menuItem != null)
            {
                switch (menuItem.ToolTip)
                {
                    case "Manage Order":
                        MainSalesManagementFrame.Content = new ManageOrder();
                        break;
                    case "Manage Customer":
                        MainSalesManagementFrame.Content = new ManageCustomer();
                        break;
                    case "Create new sales order":
                        MainSalesManagementFrame.Content = new OldCustomerUserControl();
                        break;
                    default:
                        // Xử lý cho các MenuItem khác
                        break;
                }
            }
        }
    }
}
