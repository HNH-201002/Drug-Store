using LiveCharts.Wpf;
using LiveCharts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DrugStore.Menu_Elements.Finance
{
    public partial class TotalAssets : UserControl
    {
        private double _revenue;
        private double _assets;
        SettingUserControl _settingUserControl { get; set; }
        private string OrderJsonName = "Order.Json";
        private string DrugName = "Drug.Json";

        public ChartValues<double> Revenue { get; set; }
        public ChartValues<double> Assets { get; set; }
        public TotalAssets()
        {
            InitializeComponent();
            _settingUserControl = new SettingUserControl();

            // tính toán tổng số tiền của tất cả đơn hàng
            string orderJsonPath = _settingUserControl.GetFileAddress();
            if (!Directory.Exists(orderJsonPath))    
             {
                Revenue = new ChartValues<double> { _revenue };
                Assets = new ChartValues<double> { _assets };
                TxtAssets.Text = "Assets : " + _assets.ToString("#,##0.##") + "đ";
                TxtRevenue.Text = "Revenue : " + _revenue.ToString("#,##0.##") + "đ";
                TxtSum.Text = "Total money : " + (_assets + _revenue).ToString("#,##0.##") + "đ";
                DataContext = this;
                _revenue = 0.0;
                _assets = 0.0;
                return;
            }
            if (!File.Exists(System.IO.Path.Combine(orderJsonPath , OrderJsonName)) || !File.Exists(System.IO.Path.Combine(orderJsonPath, DrugName)))
            {
                Revenue = new ChartValues<double> { _revenue };
                Assets = new ChartValues<double> { _assets };
                TxtAssets.Text = "Assets : " + _assets.ToString("#,##0.##") + "đ";
                TxtRevenue.Text = "Revenue : " + _revenue.ToString("#,##0.##") + "đ";
                TxtSum.Text = "Total money : " + (_assets + _revenue).ToString("#,##0.##") + "đ";
                DataContext = this;
                _revenue = 0.0;
                _assets = 0.0;
                return;
            }

            if (!File.Exists(System.IO.Path.Combine(orderJsonPath , OrderJsonName)))
            {
                return;
            }
            string orderJson = File.ReadAllText(System.IO.Path.Combine(orderJsonPath, OrderJsonName));
            var orderData = JsonConvert.DeserializeObject<Data>(orderJson);
            _revenue = orderData.Orders.Sum(o => o.Sum);

            if (!File.Exists(System.IO.Path.Combine(orderJsonPath, DrugName)))
            {
                return;
            }
            // tính toán tổng số tiền của tất cả thuốc trong kho
            string drugJsonPath = _settingUserControl.GetFileAddress();
            string drugJson = File.ReadAllText(System.IO.Path.Combine(drugJsonPath,DrugName));
            var drugData = JsonConvert.DeserializeObject<Data>(drugJson);
            _assets = drugData.Drugs.Sum(d => d.Price * d.Quantity);

            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            Revenue = new ChartValues<double> { _revenue };
            Assets = new ChartValues<double> { _assets };
            TxtAssets.Text = "Assets : " + _assets.ToString("#,##0.##") + "đ";
            TxtRevenue.Text = "Revenue : " + _revenue.ToString("#,##0.##") + "đ";
            TxtSum.Text = "Total money : " + (_assets + _revenue).ToString("#,##0.##") + "đ";
            DataContext = this;
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        public ObservableCollection<double> RevenueData { get; set; }
        public ObservableCollection<double> AssetsData { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
