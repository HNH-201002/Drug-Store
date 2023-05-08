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
            if (!Directory.Exists(settingUserControl.GetFileAddress()))
            {
                MessageBox.Show("Please go to the settings and specify the location to save the file");
                return;
            }
            _dataFolderPath = Path.Combine(settingUserControl.GetFileAddress(), _orderDataFilePath);

            var Data = new Data { Orders = Orders.ToList() };
            var json = JsonConvert.SerializeObject(Data);
            File.WriteAllText(_dataFolderPath, json);
        }
        public void LoadOrderData()
        {
            if (!Directory.Exists(settingUserControl.GetFileAddress()))
            {
                return;
            }
            _dataFolderPath = Path.Combine(settingUserControl.GetFileAddress(), _orderDataFilePath);
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
                return;
            }
        }
        public void Clear()
        {
            Orders.Clear();
        }

        public void EditOrder(OrderManage originalOrder, OrderManage updatedOrder)
        {
            updatedOrder.ID = originalOrder.ID;
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
