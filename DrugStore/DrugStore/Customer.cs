using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore
{
    public class Customer : INotifyPropertyChanged
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
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    RaisePropertyChanged("Gender");
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    RaisePropertyChanged("Phone");
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    RaisePropertyChanged("Email");
                }
            }
        }

        private DateTime _startAccount;
        public DateTime StartAccount
        {
            get { return _startAccount; }
            set
            {
                if (_startAccount != value)
                {
                    _startAccount = value;
                    RaisePropertyChanged("StartAccount");
                }
            }
        }

        private string _medicalHistory;
        public string MedicalHistory
        {
            get { return _medicalHistory; }
            set
            {
                if (_medicalHistory != value)
                {
                    _medicalHistory = value;
                    RaisePropertyChanged("MedicalHistory");
                }
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    RaisePropertyChanged("Status");
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

        public Customer(int id, string avatar, string name, string gender, string phone, string email, DateTime startAccount, string medicalHistory, string status)
        {
            _id = id;
            _avatar = avatar;
            _name = name;
            _gender = gender;
            _phone = phone;
            _email = email;
            _startAccount = startAccount;
            _medicalHistory = medicalHistory;
            _status = status;
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
