using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore
{
    public class Drug : INotifyPropertyChanged, IDrug
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("ID");
                }
            }
        }

        private string _avatar;
        public string Avatar
        {
            get { return _avatar; }
            set
            {
                if (_avatar != value)
                {
                    _avatar = value;
                    RaisePropertyChanged("Avatar");
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        private string _drugTypes;
        public string DrugTypes
        {
            get { return _drugTypes; }
            set
            {
                if (_drugTypes != value)
                {
                    _drugTypes = value;
                    RaisePropertyChanged("DrugTypes");
                }
            }
        }

        private float _price;
        public float Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }

        private string _drugUnits;
        public string DrugUnits
        {
            get { return _drugUnits; }
            set
            {
                if (_drugUnits != value)
                {
                    _drugUnits = value;
                    RaisePropertyChanged("DrugUnits");
                }
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    RaisePropertyChanged("Quantity");
                }
            }
        }

        private DateTime _importDate;
        public DateTime ImportDate
        {
            get { return _importDate; }
            set
            {
                if (_importDate != value)
                {
                    _importDate = value;
                    RaisePropertyChanged("ImportDate");
                }
            }
        }

        private DateTime _expiryDate;
        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set
            {
                if (_expiryDate != value)
                {
                    _expiryDate = value;
                    RaisePropertyChanged("ExpiryDate");
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }

        public Drug(int id, string avatar, string name, String drugTypes, float price, string drugUnits, int quantity, DateTime importDate, DateTime expiryDate, string description)
        {
            ID = id;
            Avatar = avatar;
            Name = name;
            DrugTypes = drugTypes;
            Price = price;
            DrugUnits = drugUnits;
            Quantity = quantity;
            ImportDate = importDate;
            ExpiryDate = expiryDate;
            Description = description;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
