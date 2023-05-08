using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrugStore.ViewModel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> _customers;
        public HashTableHandle<int, Customer> HashTableHandle { get; set; }

        private string _dataFolderPath;
        private string _customerDataFilePath = "Customer.json";
        SettingUserControl settingUserControl = new SettingUserControl();
        public CustomerViewModel()
        {
            HashTableHandle = new HashTableHandle<int, Customer>();
            _customers = new ObservableCollection<Customer>();
            LoadCustomerData();
            LoadHashTableData();
        }

        private void LoadHashTableData()
        {
            foreach (Customer cusomter in Customers)
            {
                HashTableHandle.Add(cusomter.ID, cusomter);
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        public void Add(Customer customer)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            customer.Name = textInfo.ToTitleCase(customer.Name);

            Customers.Add(customer);
            HashTableHandle.Add(customer.ID, customer);
            OnPropertyChanged(nameof(Customers));
        }


        public void Delete(Customer customer)
        {
            Customers.Remove(customer);
            HashTableHandle.Remove(customer.ID);
            OnPropertyChanged(nameof(Customers));
        }

        public void SaveCustomerData()
        {
            if (!Directory.Exists(settingUserControl.GetFileAddress()))
            {
                MessageBox.Show("Please go to the settings and specify the location to save the file");
                return;
            }
            _dataFolderPath = Path.Combine(settingUserControl.GetFileAddress() , _customerDataFilePath);
            var Data = new Data { Customers = Customers.ToList() };
            var json = JsonConvert.SerializeObject(Data);
            File.WriteAllText(_dataFolderPath, json);
        }

        public void LoadCustomerData()
        {
            if (!Directory.Exists(settingUserControl.GetFileAddress()))
            {
                return;
            }
            _dataFolderPath = Path.Combine(settingUserControl.GetFileAddress() , _customerDataFilePath);
            if (File.Exists(_dataFolderPath))
            {
                var json = File.ReadAllText(_dataFolderPath);
                var customerData = JsonConvert.DeserializeObject<Data>(json);
                if (customerData == null)
                {
                    return;
                }
                Customers.Clear();
                foreach (var customer in customerData.Customers)
                {
                    Customers.Add(customer);
                }
            }
            else
            {
                using (FileStream fs = File.Create(_dataFolderPath))
                {
                    // Khởi tạo dữ liệu mặc định cho file nếu cần
                }

                return;
            }
        }
        public Customer SearchByID(int id)
        {
            Customer results = null;
            LoadCustomerData();
            LoadHashTableData();
            foreach (Customer customer in HashTableHandle.GetValues())
            {
                if (customer.ID == id)
                {
                    results = customer;
                }
            }

            return results;
        }
        public List<Customer> SearchByName(string name)
        {
            List<Customer> results = new List<Customer>();
            LoadCustomerData();
            LoadHashTableData();
            foreach (Customer customer in HashTableHandle.GetValues())
            {
                if (customer.Name.Contains(name))
                {
                    results.Add(customer);
                }
            }

            return results;
        }
        public List<Customer> SearchByPhone(string phone)
        {
            List<Customer> results = new List<Customer>();
            LoadCustomerData();
            LoadHashTableData();
            foreach (Customer customer in HashTableHandle.GetValues())
            {
                if (customer.Phone.Contains(phone))
                {
                    results.Add(customer);
                }
            }

            return results;
        }
        public void Clear()
        {
            Customers.Clear();
        }
        public void Edit(Customer originalCustomer, Customer updatedCustomer)
        {
            updatedCustomer.ID = originalCustomer.ID;
            Delete(originalCustomer);
            Add(updatedCustomer);
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
