using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyKho.Model;

namespace QuanLyKho.ViewModel
{
    public class CTHDPhong_View:BaseViewModel
    {
        private ObservableCollection<CTHD_PHONG> _listCTHDPh;
        public ObservableCollection<CTHD_PHONG> listCTHDPh
        {
            get
            {
                return _listCTHDPh;
            }
            set
            {
                _listCTHDPh = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ReturnCommand { get; set; }
        public CTHDPhong_View()
        {
            listCTHDPh = new ObservableCollection<CTHD_PHONG>(DataProvider.Ins.DB.CTHD_PHONG);

            //them
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItems != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    CTHD_PHONG P = new CTHD_PHONG() { ID_PHONG = IDphong, ID_HDPHONG = IDhdphong, ID_MATHANG = IDmathang, SOLUONG = Soluong, DONGIA = Dongia };
                    DataProvider.Ins.DB.CTHD_PHONG.Add(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listCTHDPh.Add(P);
                    MessageBox.Show("Thêm thành công", "Thông Báo");
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
                if (SelectedItems != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    CTHD_PHONG P = new CTHD_PHONG();
                    P = (from ph in DataProvider.Ins.DB.CTHD_PHONG where ph.ID_PHONG == SelectedItems.ID_PHONG && ph.ID_MATHANG == SelectedItems.ID_MATHANG select ph).Single();

                    DataProvider.Ins.DB.CTHD_PHONG.Remove(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listCTHDPh.Remove(P);
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
                if (SelectedItems == null)
                    return false;
                var Ph = DataProvider.Ins.DB.CTHD_PHONG.Where(x => x.ID_PHONG == IDphong && x.ID_MATHANG==IDmathang);
                if (Ph == null || Ph.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.CTHD_PHONG.Where(x => x.ID_PHONG == SelectedItems.ID_PHONG && x.ID_MATHANG == SelectedItems.ID_MATHANG).SingleOrDefault();
                    //unit.ID_PHONG = IDphong;
                    //unit.ID_MATHANG = IDmathang;
                    unit.ID_HDPHONG = IDhdphong;
                    unit.SOLUONG = Soluong;
                    unit.DONGIA = Dongia;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                    listCTHDPh = new ObservableCollection<CTHD_PHONG>(DataProvider.Ins.DB.CTHD_PHONG);
                    Reset();
                }
                catch
                {
                    MessageBox.Show("Sửa thất bại", "Thông Báo");
                }

            });
            //quay lại
            ReturnCommand = new RelayCommand<object>((p) =>
            {
                if ( Soluong == null && Dongia == null && SelectedItems == null)
                    return false;
                return true;
            }, (p) =>
            {
                Reset();
            });
            Reset();
        }
        private void Reset()
        {
            IDphong = 0;
            IDhdphong = 0;
            IDmathang = 0;
            Soluong = 0;
            Dongia = 0;
            tenmh = null;
        }

        private int _IDphong;
        public int IDphong
        {
            get { return _IDphong; }
            set { _IDphong = value; OnPropertyChanged(); }
        }
        private int _IDmathang;
        public int IDmathang
        {
            get { return _IDmathang; }
            set { _IDmathang = value;OnPropertyChanged(); }
        }
        private int _IDhdphong;
        public int IDhdphong
        {
            get { return _IDhdphong; }
            set { _IDhdphong = value;OnPropertyChanged(); }
        }
        private int _Soluong;
        public int Soluong
        {
            get { return _Soluong; }
            set
            {
                _Soluong = value;
                OnPropertyChanged();
            }
        }
        private int _Dongia;
        public int Dongia
        {
            get { return _Dongia; }
            set
            {
                _Dongia = value;
                OnPropertyChanged();
            }
        }
        private string _tenmh;
        public string tenmh
        {
            get { return _tenmh; }
            set { _tenmh = value;OnPropertyChanged(); }
        }
        private CTHD_PHONG _SelectedItems;
        public CTHD_PHONG SelectedItems
        {
            get { return _SelectedItems; }
            set { _SelectedItems = value;OnPropertyChanged();
                if (SelectedItems != null)
                {
                    IDphong = SelectedItems.ID_PHONG;
                    IDmathang = SelectedItems.ID_MATHANG;
                    IDhdphong = (int)SelectedItems.ID_HDPHONG;
                    Soluong = (int)SelectedItems.SOLUONG;
                    Dongia = (int)SelectedItems.DONGIA;
                    tenmh = SelectedItems.MAT_HANG.TEN_MATHANG;
                }
            }
        }
    }
}
