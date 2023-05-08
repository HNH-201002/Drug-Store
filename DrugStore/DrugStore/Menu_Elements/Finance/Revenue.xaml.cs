using LiveCharts.Wpf;
using LiveCharts;
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
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using System.Windows.Markup;

namespace DrugStore.Menu_Elements.Finance
{
    public partial class Revenue : UserControl
    {
        SettingUserControl _settingUserControl { get; set; }
        private string nameFile = "Order.Json";
        public Revenue()
        {
            InitializeComponent();
            _settingUserControl = new SettingUserControl();
            if (!Directory.Exists(_settingUserControl.GetFileAddress()))
            {
                return;
            }
            string filePath = System.IO.Path.Combine(_settingUserControl.GetFileAddress(),nameFile);
            // Deserialize the JSON data into an object.
            if (!File.Exists(filePath))
            {
                return;
            }
            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<Data>(json);
            CmbSelect.SelectedIndex = 0;
            var ordersByDate = data.Orders
       .GroupBy(order => order.OrderDate.Date)
       .Select(group => new {
           Date = group.Key,
           Orders = group.Select(order => new {
               OrderDate = order.OrderDate.ToString("dd/MM/yyyy HH:mm:ss"),
               Sum = order.Sum
           })
       });

            // Convert the results to a chart-friendly format.
            var seriesCollection = new SeriesCollection();
            var labels = new List<string>();
            foreach (var orderGroup in ordersByDate)
            {
                var chartData = new ChartValues<double>();
                var orderLabels = new List<string>();
                foreach (var order in orderGroup.Orders)
                {
                    chartData.Add(order.Sum);
                    orderLabels.Add(order.OrderDate);
                }
                seriesCollection.Add(new ColumnSeries { Title = orderGroup.Date.ToString("dd/MM/yyyy"), Values = chartData });
                labels.AddRange(orderLabels);
            }

            // Bind the chart data to the chart control.
            cartesianChart.Series = seriesCollection;
            cartesianChart.AxisX[0].Labels = labels.Distinct().ToArray();

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _settingUserControl = new SettingUserControl();
            string filePath = System.IO.Path.Combine(_settingUserControl.GetFileAddress(), nameFile);
            if (!File.Exists(filePath)) { return; }
            // Deserialize the JSON data into an object.
            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<Data>(json);
            float totalMoney = 0;
            switch (CmbSelect.SelectedIndex)
            {
                case 0: //Hour
                    var ordersByDate = data.Orders
                        .GroupBy(order => order.OrderDate.Date)
                        .Select(group => new {
                            Date = group.Key,
                            Orders = group.Select(order => new {
                                OrderDate = order.OrderDate.ToString("dd/MM/yyyy HH:mm:ss"),
                                Sum = order.Sum
                            })
                        });

                    // Convert the results to a chart-friendly format.
                    var seriesCollection = new SeriesCollection();
                    var labels = new List<string>();
                    foreach (var orderGroup in ordersByDate)
                    {
                        var chartData = new ChartValues<double>();
                        var orderLabels = new List<string>();
                        foreach (var order in orderGroup.Orders)
                        {
                            chartData.Add(order.Sum);
                            orderLabels.Add(order.OrderDate);
                            totalMoney += order.Sum;
                        }
                        seriesCollection.Add(new ColumnSeries { Title = orderGroup.Date.ToString("dd/MM/yyyy"), Values = chartData });
                        labels.AddRange(orderLabels);
                    }

                    // Bind the chart data to the chart control.
                    cartesianChart.Series = seriesCollection;
                    cartesianChart.AxisX[0].Labels = labels.Distinct().ToArray();
                    TotalMoney.Text = "Total Money : " + totalMoney.ToString("#,##0.##") + "đ";
                    break;
                case 1: //Day
                    var ordersByDay = data.Orders
                        .GroupBy(order => order.OrderDate.Date)
                        .Select(group => new
                        {
                            Date = group.Key,
                            Sum = group.Sum(order => order.Sum)
                        });

                    // Convert the results to a chart-friendly format.
                    var seriesCollectionDay = new SeriesCollection();
                    var labelsDay = new List<string>();
                    foreach (var orderGroup in ordersByDay)
                    {
                        seriesCollectionDay.Add(new ColumnSeries { Title = orderGroup.Date.ToString("dd/MM/yyyy"), Values = new ChartValues<double> { orderGroup.Sum } });
                        labelsDay.Add(orderGroup.Date.ToString("dd/MM/yyyy"));
                    }

                    // Bind the chart data to the chart control.
                    cartesianChart.Series = seriesCollectionDay;
                    cartesianChart.AxisX[0].Labels = labelsDay.ToArray();
                    break;
                case 2: // Week
                    var ordersByWeek = data.Orders
                        .GroupBy(order => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                        order.OrderDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                        .Select(group => new
                        {
                            Week = group.Key,
                            StartDate = GetStartDateOfWeek(group.Key),
                            EndDate = GetEndDateOfWeek(group.Key),
                            Sum = group.Sum(order => order.Sum)
                        });

                    // Convert the results to a chart-friendly format.
                    var seriesCollectionWeek = new SeriesCollection();
                    var labelsWeek = new List<string>();
                    foreach (var orderGroup in ordersByWeek)
                    {
                        seriesCollectionWeek.Add(new ColumnSeries { Title = $"Week {orderGroup.Week} ({orderGroup.StartDate:dd/MM/yyyy} - {orderGroup.EndDate:dd/MM/yyyy})", Values = new ChartValues<double> { orderGroup.Sum } });
                        labelsWeek.Add($"Week {orderGroup.Week}");
                        totalMoney += orderGroup.Sum;
                    }

                    // Bind the chart data to the chart control.
                    cartesianChart.Series = seriesCollectionWeek;
                    cartesianChart.AxisX[0].Labels = labelsWeek.ToArray();
                    TotalMoney.Text = "Total Money : " + totalMoney.ToString("#,##0.##") + "đ";
                    break;
                case 3: // Month
                    var ordersByMonth = data.Orders
                        .GroupBy(order => order.OrderDate.Month)
                        .Select(group => new
                        {
                            Month = group.Key,
                            Sum = group.Sum(order => order.Sum)
                        });

                    var seriesCollectionMonth = new SeriesCollection();
                    var labelsMonth = new List<string>();
                    foreach (var orderGroup in ordersByMonth)
                    {
                        var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(orderGroup.Month);
                        seriesCollectionMonth.Add(new ColumnSeries { Title = monthName, Values = new ChartValues<double> { orderGroup.Sum } });
                        labelsMonth.Add(monthName);
                        totalMoney += orderGroup.Sum;
                    }

                    cartesianChart.Series = seriesCollectionMonth;
                    cartesianChart.AxisX[0].Labels = labelsMonth.ToArray();
                    TotalMoney.Text = "Total Money : " + totalMoney.ToString("#,##0.##") + "đ";
                    break;
                case 4: //year
                    var ordersByYear = data.Orders
                        .GroupBy(order => order.OrderDate.Year)
                        .Select(group => new
                        {
                            Year = group.Key,
                            Sum = group.Sum(order => order.Sum)
                        });

                    // Convert the results to a chart-friendly format.
                    var seriesCollectionYear = new SeriesCollection();
                    var labelsYear = new List<string>();
                    foreach (var orderGroup in ordersByYear)
                    {
                        seriesCollectionYear.Add(new ColumnSeries { Title = orderGroup.Year.ToString(), Values = new ChartValues<double> { orderGroup.Sum } });
                        labelsYear.Add(orderGroup.Year.ToString());
                        totalMoney += orderGroup.Sum;
                    }

                    // Bind the chart data to the chart control.
                    cartesianChart.Series = seriesCollectionYear;
                    cartesianChart.AxisX[0].Labels = labelsYear.ToArray();
                    TotalMoney.Text = "Total Money : " + totalMoney.ToString("#,##0.##") + "đ";
                    break;
            }

        }

        private DateTime GetStartDateOfWeek(int weekNumber)
        {
            DateTime jan1 = new DateTime(DateTime.Now.Year, 1, 1);
            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek + 7;
            DateTime firstMonday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            var firstWeek = cal.GetWeekOfYear(firstMonday, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            var weekNum = weekNumber;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstMonday.AddDays(weekNum * 7);
            return result;
        }

        // Helper method to get the end date of a week based on the week number.
        private DateTime GetEndDateOfWeek(int weekNumber)
        {
            var startDateOfWeek = GetStartDateOfWeek(weekNumber);
            var endDateOfWeek = startDateOfWeek.AddDays(6);
            return endDateOfWeek;
        }

    }
}
