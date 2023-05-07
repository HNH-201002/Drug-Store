using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DrugStore.ViewModel
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<OrderManage> _orders;
        public LinkedList<OrderManage> _linkedList;

        private string _dataFolderPath;
        private string _orderDataFilePath = "Order.json";
        SettingUserControl settingUserControl = new SettingUserControl();
        public OrderViewModel()
        {
            _linkedList = new LinkedList<OrderManage>();
            _orders = new ObservableCollection<OrderManage>();
            LoadOrderData();
            foreach (OrderManage order in Orders)
            {
                _linkedList.Add(order);
            }
        }

        public ObservableCollection<OrderManage> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }

        public void AddOrder(OrderManage order)
        {
            var existingOrder = Orders.FirstOrDefault(o => o.ID == order.ID);
            if (existingOrder != null)
            {
                existingOrder = order;
                _linkedList.Edit(existingOrder.ID, existingOrder);
            }
            else
            {
                // Thêm order mới vào danh sách Orders và LinkedList
                Orders.Add(order);
                _linkedList.Add(order);
            };
            OnPropertyChanged(nameof(Orders));
        }

        public void DeleteOrder(OrderManage order)
        {
            _linkedList.Remove(order);
            Orders.Remove(order);
            OnPropertyChanged(nameof(Orders));
        }
        public List<OrderManage> Search(string searchChar)
        {
            List<OrderManage> foundOrders = new List<OrderManage>();

            foreach (OrderManage order in Orders)
            {
                if (order.Customer != null && order.Customer.Name.Contains(searchChar))
                {
                    foundOrders.Add(order);
                }
            }

            return foundOrders;
        }
        public void SaveOrderData()
        {
            _dataFolderPath = settingUserControl.GetFileAddress(_orderDataFilePath);
            if (string.IsNullOrEmpty(_dataFolderPath))
            {
                MessageBox.Show("Please go to the settings and specify the location to save the file");
                return;
            }
            var Data = new Data { Orders = Orders.ToList() };
            var json = JsonConvert.SerializeObject(Data);
            var filePath = _dataFolderPath;
            File.WriteAllText(filePath, json);
        }
        public void LoadOrderData()
        {
            _dataFolderPath = settingUserControl.GetFileAddress(_orderDataFilePath);
            if (string.IsNullOrEmpty(_dataFolderPath))
            {
                //MessageBox.Show("You don't have data to load or you haven't specified where to save the file");
                return;
            }
            var filePath = _dataFolderPath;
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var orderData = JsonConvert.DeserializeObject<Data>(json);
                Orders.Clear();
                foreach (var order in orderData.Orders)
                {
                    Orders.Add(order);
                }
            }
            else
            {
                MessageBox.Show("Order data file does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        public void Clear()
        {
            Orders.Clear();
        }

        public void EditOrder(OrderManage originalOrder, OrderManage updatedOrder)
        {
            DeleteOrder(originalOrder);
            AddOrder(updatedOrder);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
