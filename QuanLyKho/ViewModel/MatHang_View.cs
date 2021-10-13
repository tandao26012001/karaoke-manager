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
    public class MatHang_View : BaseViewModel
    {
        public ObservableCollection<MAT_HANG> _listMH;
        public ObservableCollection<MAT_HANG> listMH
        {
            get
            {
                return _listMH;
            }
            set
            {
                _listMH = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<NHACUNGCAP> _listNhaCungCap;

        public ObservableCollection<NHACUNGCAP> ListNhaCungCap
        {
            get
            {
                return _listNhaCungCap;
            }
            set
            {
                _listNhaCungCap = value;
                OnPropertyChanged();
            }
        }
        public string Ten_MatHang { get; set; }
        public MatHang_View()
        {
            listMH = new ObservableCollection<MAT_HANG>(DataProvider.Ins.DB.MAT_HANG);
            ListNhaCungCap = new ObservableCollection<NHACUNGCAP>(DataProvider.Ins.DB.NHACUNGCAPs);
            //them
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    MAT_HANG P = new MAT_HANG() { ID_MATHANG = Idmathang, DONVITINH = Donvitinh, TEN_MATHANG = Tenmathang, ID_NHACUNGCAP = IDNhacungcap };
                    DataProvider.Ins.DB.MAT_HANG.Add(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listMH.Add(P);
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
                if (SelectedItem != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    MAT_HANG P = new MAT_HANG();
                    P = (from ph in DataProvider.Ins.DB.MAT_HANG where ph.ID_MATHANG == SelectedItem.ID_MATHANG select ph).Single();
                    DataProvider.Ins.DB.MAT_HANG.Remove(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listMH.Remove(P);
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
                if (SelectedItem == null)
                    return false;
                var Ph = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MATHANG == Idmathang);
                if (Ph == null || Ph.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.MAT_HANG.Where(x => x.ID_MATHANG == SelectedItem.ID_MATHANG).SingleOrDefault();
                    unit.ID_NHACUNGCAP = IDNhacungcap;
                    unit.TEN_MATHANG = Tenmathang;
                    unit.DONVITINH = Donvitinh;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                    listMH = new ObservableCollection<MAT_HANG>(DataProvider.Ins.DB.MAT_HANG);
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
                if (SelectedItem == null &&  Idmathang == 0 && TenNhacungcap == null && Donvitinh == null && Tenmathang == null)
                    return false;
                return true;
            }, (p) =>
            {
                Reset();
            });
            Reset();
        }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        private void Reset()
        {
            Idmathang = 0;
            IDNhacungcap = 0;
            TenNhacungcap = null;
            Tenmathang = null;
            Donvitinh = null;
        }
        private int _IDmathang;
        public int Idmathang
        {
            get { return _IDmathang; }
            set { _IDmathang = value;OnPropertyChanged(); }
        }
        private string _Tenmathang;
        public string Tenmathang
        {
            set { _Tenmathang = value;OnPropertyChanged(); }
            get { return _Tenmathang; }
        }
        private int _IDNhacungcap;
        public int IDNhacungcap
        {
            get { return _IDNhacungcap; }
            set
            {
                _IDNhacungcap = value;
                OnPropertyChanged();
            }
        }
        private string _TenNhacungcap;
        public string TenNhacungcap
        {
            get { return _TenNhacungcap; }
            set
            {
                _TenNhacungcap = value;
                OnPropertyChanged();
            }
        }
        private string _Donvitinh;
        public string Donvitinh
        {
            get { return _Donvitinh; }
            set { _Donvitinh = value;OnPropertyChanged(); }
        }
        private MAT_HANG _SelectedItem;
        public MAT_HANG SelectedItem
        {
            get { return _SelectedItem; }
            set 
            {
                _SelectedItem = value;OnPropertyChanged();
                if (SelectedItem != null)
                {
                    IDNhacungcap = (int)SelectedItem.ID_NHACUNGCAP;
                    Idmathang = SelectedItem.ID_MATHANG;
                    Tenmathang = SelectedItem.TEN_MATHANG;
                    TenNhacungcap = SelectedItem.NHACUNGCAP.TEN_NHACUNGCAP;
                    Donvitinh = SelectedItem.DONVITINH;
                }
            }
        }
    }
}
