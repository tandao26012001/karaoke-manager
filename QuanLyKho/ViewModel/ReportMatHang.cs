using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyKho.Model;

using LiveCharts;

namespace QuanLyKho.ViewModel
{
    public class ReportMatHang:BaseViewModel
    {
        private string[] _AxisListNameMH;
        public string[] AxisListNameMH
        { 
            get { return _AxisListNameMH; } 
        set
            {
                _AxisListNameMH = value;
                OnPropertyChanged();
            }
        }
        private ChartValues<int> _ColumnSeriesMHCount;
        public ChartValues<int> ColumnSeriesMHCount
        {
            get { return _ColumnSeriesMHCount; }
            private set
            {
                _ColumnSeriesMHCount = value;
                OnPropertyChanged(nameof(ColumnSeriesMHCount));
            }
        }
        public SeriesCollection senderChart { get; set; }
        public ReportMatHang()
        {
            ObservableCollection<DEMSLMATHANG_Result> ListThongKe = new
            ObservableCollection<DEMSLMATHANG_Result>(DataProvider.Ins.DB.DEMSLMATHANG());
            ColumnSeriesMHCount = new ChartValues<int> { };
            foreach (var item in ListThongKe)
                ColumnSeriesMHCount.Add(int.Parse(item.SOLUONG.ToString()));
            AxisListNameMH = ListThongKe.Select(c => c.TEN_MATHANG).ToArray();
        }

    }
}
