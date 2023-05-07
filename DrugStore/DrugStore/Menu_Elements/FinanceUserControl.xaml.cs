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
using DrugStore.Menu_Elements;
using DrugStore.Menu_Elements.Finance;
using DrugStore.Menu_Elements.Sales_management;

namespace DrugStore.Menu_Elements
{
    /// <summary>
    /// Interaction logic for FinanceUserControl.xaml
    /// </summary>
    public partial class FinanceUserControl : UserControl
    {

        public FinanceUserControl()
        {
            InitializeComponent();

        }
        private void MenuItem_Click_Header(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = e.OriginalSource as MenuItem; // Ép kiểu thành MenuItem
            if (menuItem != null)
            {
              
            }
        }
        private void MenuItem_Click_Tooltip(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = e.OriginalSource as MenuItem; // Ép kiểu thành MenuItem
            if (menuItem != null)
            {
                switch (menuItem.ToolTip)
                {
                    case "Revenue":
                        FinancialFrame.Content = new Revenue();
                        break;
                    case "Assets":
                        FinancialFrame.Content = new TotalAssets();
                        break;
                    default:
                        // Xử lý cho các MenuItem khác
                        break;
                }
            }
        }

    }
}
