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
    public class KhachHang_View:BaseViewModel
    {
        private ObservableCollection<KHACH_HANG> _listkh;
        public ObservableCollection<KHACH_HANG> listkh
        {
            get { return _listkh; }
            set
            {
                _listkh = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        private int _idKH;
        public int idKH
        {
            get { return _idKH; }
            set
            {
                _idKH = value;
                OnPropertyChanged();
            }
        }
        private string _tenKH;
        public string tenKH
        {
            get { return _tenKH; }
            set
            {
                _tenKH = value;
                OnPropertyChanged();
            }
        }
        private KHACH_HANG _selectedItem;
        public KHACH_HANG selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if(selectedItem!=null)
                {
                    idKH = selectedItem.ID_KHACHHANG;
                    tenKH = selectedItem.TEN_KHACHHANG;
                }
            }
        }
        private void Reset()
        {
            idKH = 0;
            tenKH = null;
        }
        public KhachHang_View()
        {
            listkh = new ObservableCollection<KHACH_HANG>(DataProvider.Ins.DB.KHACH_HANG);
            //thêm mới khách hàng 
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (selectedItem != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    KHACH_HANG kh = new KHACH_HANG() { ID_KHACHHANG = idKH, TEN_KHACHHANG = tenKH };
                    DataProvider.Ins.DB.KHACH_HANG.Add(kh);
                    DataProvider.Ins.DB.SaveChanges();
                    listkh.Add(kh);
                    MessageBox.Show("Đã thêm thành công", "Thông Báo");
                    Reset();
                }
                catch
                {
                    MessageBox.Show("Thêm thất bại", "Thông Báo");
                }
            });
            //xoa
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (selectedItem != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    KHACH_HANG  P = new KHACH_HANG();
                    P = (from ph in DataProvider.Ins.DB.KHACH_HANG where ph.ID_KHACHHANG == selectedItem.ID_KHACHHANG select ph).Single();

                    DataProvider.Ins.DB.KHACH_HANG.Remove(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listkh.Remove(P);
                    MessageBox.Show("Xóa thành công", "Thông Báo");
                    Reset();

                }
                catch
                {
                    MessageBox.Show("Xóa thất bại", "Thông Báo");
                }
            });
            //sua
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (selectedItem == null)
                    return false;
                var Ph = DataProvider.Ins.DB.KHACH_HANG.Where(x => x.ID_KHACHHANG == idKH);
                if (Ph == null || Ph.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.KHACH_HANG.Where(x => x.ID_KHACHHANG == selectedItem.ID_KHACHHANG).SingleOrDefault();
                    unit.TEN_KHACHHANG = tenKH;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                    listkh = new ObservableCollection<KHACH_HANG>(DataProvider.Ins.DB.KHACH_HANG);
                    Reset();
                }
                catch
                {
                    MessageBox.Show("Sửa thất bại", "Thông Báo");
                }

            });
            //quay lại
            ResetCommand = new RelayCommand<object>((p) =>
            {
                if (tenKH == null )
                    return false;
                return true;
            }, (p) =>
            {
                Reset();
            });
            Reset();
        }
    }
}
