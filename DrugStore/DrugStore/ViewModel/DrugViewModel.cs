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
using System.Xml.Linq;

namespace DrugStore.ViewModel
{
    public class DrugViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Drug> _drugs;
        public BinarySearchTree<Drug> _binarySearchTree;

        private string _dataFolderPath;
        private string _drugDataFilePath = "Drug.json";
        SettingUserControl settingUserControl = new SettingUserControl();
        public DrugViewModel()
        {
            _binarySearchTree = new BinarySearchTree<Drug>();
            _drugs = new ObservableCollection<Drug>();
            LoadDrugData();
            foreach (Drug drug in Drugs)
            {
                _binarySearchTree.AddOrUpdate(drug);
            }
        }
        public ObservableCollection<Drug> Drugs
        {
            get { return _drugs; }
            set
            {
                _drugs = value;
                OnPropertyChanged();
            }
        }
        public void AddDrug(Drug drug)
        {
            Drugs.Add(drug);
            _binarySearchTree.AddOrUpdate(drug);
            OnPropertyChanged((nameof(Drugs)));
        }


        public void DeleteDrug(Drug drug)
        {
            _binarySearchTree.DeleteNode(drug);
            Drugs.Remove(drug);
            OnPropertyChanged(nameof(Drugs));
        }
        public void SaveDrugData()
        {
            _dataFolderPath = settingUserControl.GetFileAddress(_drugDataFilePath);
            if (string.IsNullOrEmpty(_dataFolderPath))
            {
                MessageBox.Show("Please go to the settings and specify the location to save the file");
                return;
            }
            var Data = new Data { Drugs = Drugs.ToList() };
            var json = JsonConvert.SerializeObject(Data);
            var filePath = _dataFolderPath;
            File.WriteAllText(filePath, json);
        }

        public void LoadDrugData()
        {
            _dataFolderPath = settingUserControl.GetFileAddress(_drugDataFilePath);
            if (string.IsNullOrEmpty(_dataFolderPath))
            {
                //MessageBox.Show("You don't have data to load or you haven't specified where to save the file");
                return;
            }
            var filePath = _dataFolderPath;
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var drugData = JsonConvert.DeserializeObject<Data>(json);
                Drugs.Clear();
                foreach (var drug in drugData.Drugs)
                {
                    Drugs.Add(drug);
                }
            }
            else
            {
                MessageBox.Show("Drug data file does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        public List<Drug> Search(string name)
        {
            List<Drug> ts = _binarySearchTree.Search<Drug>(name, _binarySearchTree.root);
            return ts;
        }
        public List<Drug> FilterByType(string type)
        {
            List<Drug> ts = _binarySearchTree.FilterByType<Drug>(type, _binarySearchTree.root);
            return ts;
        }
        public void Clear()
        {
            Drugs.Clear();
        }
        public void EditDrug(Drug originalDrug, Drug updatedDrug)
        {
            DeleteDrug(originalDrug);
            AddDrug(updatedDrug);
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
