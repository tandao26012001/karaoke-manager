using LiveCharts;
using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class ReportChiNhapHang:BaseViewModel
    {
        private string[] _AxisListNameHD;
        public string[] AxisListNameHD
        {
            get { return _AxisListNameHD; }
            set
            {
                _AxisListNameHD = value;
                OnPropertyChanged();
            }
        }


        private ChartValues<int> _ColumnSeriesHDCounts;
        public ChartValues<int> ColumnSeriesHDCounts
        {
            get
            {
                return _ColumnSeriesHDCounts;
            }
            private set
            {
                _ColumnSeriesHDCounts = value;
                OnPropertyChanged(nameof(ColumnSeriesHDCounts));
            }
        }
        //tạo properties chọn tháng

        private int _SelectedItem;
        public int SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }

        //sự kiện chọn ở combobox sẽ hiển thị report tương ứng

        public ICommand SelectionChangedCommand { get; set; }
        public ReportChiNhapHang()
        {
            //khởi tạo 
            SelectedItem = 1;
            ObservableCollection<prDoanThu_Result> ListThongKe = new ObservableCollection<prDoanThu_Result>(DataProvider.Ins.DB.prDoanThu(SelectedItem));
            ColumnSeriesHDCounts = new ChartValues<int> { };
            foreach (var item in ListThongKe)
                ColumnSeriesHDCounts.Add(int.Parse(item.DOANHTHU.ToString()));

            AxisListNameHD = ListThongKe.Select(c => c.TEN_MATHANG).ToArray();
            //khi chọn một dòng của combobox sẽ hiển thi report tương ứng
            SelectionChangedCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    ListThongKe = new ObservableCollection<prDoanThu_Result>(DataProvider.Ins.DB.prDoanThu(SelectedItem));
                    ColumnSeriesHDCounts = new ChartValues<int> { };
                    foreach (var item in ListThongKe)
                        ColumnSeriesHDCounts.Add(int.Parse(item.DOANHTHU.ToString()));
                    AxisListNameHD = ListThongKe.Select(c => c.TEN_MATHANG).ToArray();
                }
                catch
                {
                    MessageBox.Show("Thao tác sai!");
                }
            });
        }

    }
}
