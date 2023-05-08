using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore.ViewModel
{
    public class FinancialViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _revenue;
        private double _assets;
        SettingUserControl _settingUserControl { get; set; }
        private string OrderJsonName = "Order.Json";
        private string DrugName = "Drug.Json";
        public ObservableCollection<double> RevenueData { get; set; }
        public ObservableCollection<double> AssetsData { get; set; }
        public FinancialViewModel()
        {
            RevenueData = new ObservableCollection<double>();
            AssetsData = new ObservableCollection<double>();

            _settingUserControl = new SettingUserControl();
            // tính toán tổng số tiền của tất cả đơn hàng
            string orderJsonPath = _settingUserControl.GetFileAddress();
            string orderJson = File.ReadAllText(orderJsonPath);
            var orderData = JsonConvert.DeserializeObject<Data>(orderJson);
            _revenue = orderData.Orders.Sum(o => o.Sum);

            // tính toán tổng số tiền của tất cả thuốc trong kho
            string drugJsonPath = _settingUserControl.GetFileAddress();
            string drugJson = File.ReadAllText(drugJsonPath);
            var drugData = JsonConvert.DeserializeObject<Data>(drugJson);
            _assets = drugData.Drugs.Sum(d => d.Price * d.Quantity);

            // gán giá trị cho các PieSeries
            RevenueData.Add(_revenue);
            AssetsData.Add(_assets);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
