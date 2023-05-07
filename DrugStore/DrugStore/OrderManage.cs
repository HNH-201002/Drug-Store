using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrugStore
{
    public class OrderManage
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
        private float _sum;
        public float Sum
        {
            get { return _sum; }
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                    RaisePropertyChanged("Sum");
                }
            }
        }
        private DateTime _refundDueDate;
        public DateTime RefundDueDate
        {
            get { return _refundDueDate; }
            set
            {
                if (_refundDueDate != value)
                {
                    _refundDueDate = value;
                    RaisePropertyChanged("HoanDueDate");
                }
            }
        }
        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                if (_orderDate != value)
                {
                    _orderDate = value;
                    RaisePropertyChanged("OrderDate");
                }
            }
        }
        private List<Order> _order;
        public List<Order> Order
        {
            get { return _order; }
            set
            {
                if (_order != value)
                {
                    _order = value;
                    RaisePropertyChanged("Order");
                }
            }
        }
        private Customer _cusomter;
        public Customer Customer
        {
            get { return _cusomter; }
            set
            {
                if (_cusomter != value)
                {
                    _cusomter = value;
                    RaisePropertyChanged("Customer");
                }
            }
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
