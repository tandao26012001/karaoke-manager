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
    public class CTHDNhapHang_View:BaseViewModel
    {
        private ObservableCollection<CTHD_NHAPHANG> _listcthdnh;
        public ObservableCollection<CTHD_NHAPHANG> listcthdnh
        {
            get { return _listcthdnh; }
            set
            {
                _listcthdnh = value;
                OnPropertyChanged();
            }
        }
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
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public CTHDNhapHang_View()
        {
            listcthdnh = new ObservableCollection<CTHD_NHAPHANG>(DataProvider.Ins.DB.CTHD_NHAPHANG);
            listMH = new ObservableCollection<MAT_HANG>(DataProvider.Ins.DB.MAT_HANG);

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
                    CTHD_NHAPHANG P = new CTHD_NHAPHANG() { ID_MATHANG = IDmathang, ID_HDNHAPHANG = IDHDnhaphang, 
                        SOLUONG = Soluong, DONGIA = Dongia, HANSUDUNG = Hansudung, NGAYNHAP = Ngaynhap };
                    DataProvider.Ins.DB.CTHD_NHAPHANG.Add(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listcthdnh.Add(P);
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
                    CTHD_NHAPHANG P = new CTHD_NHAPHANG();
                    P = (from ph in DataProvider.Ins.DB.CTHD_NHAPHANG where ph.ID_HDNHAPHANG == SelectedItem.ID_HDNHAPHANG && ph.ID_MATHANG == SelectedItem.ID_MATHANG select ph).Single();

                    DataProvider.Ins.DB.CTHD_NHAPHANG.Remove(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listcthdnh.Remove(P);
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
                var Ph = DataProvider.Ins.DB.CTHD_NHAPHANG.Where(x => x.ID_HDNHAPHANG == IDHDnhaphang && x.ID_MATHANG==IDmathang);
                if (Ph == null || Ph.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.CTHD_NHAPHANG.Where(x => x.ID_HDNHAPHANG == SelectedItem.ID_HDNHAPHANG && x.ID_MATHANG==IDmathang).SingleOrDefault();
                    //unit.ID_MATHANG = IDmathang;
                    //unit.ID_HDNHAPHANG = IDHDnhaphang;
                    unit.SOLUONG = Soluong;
                    unit.DONGIA = Dongia;
                    unit.HANSUDUNG = Hansudung;
                    unit.NGAYNHAP = Ngaynhap;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                    listcthdnh = new ObservableCollection<CTHD_NHAPHANG>(DataProvider.Ins.DB.CTHD_NHAPHANG);
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
                if (Tenmathang == null && Dongia == null && Soluong == null && Ngaynhap == null && Hansudung == null && SelectedItem == null)
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
            Tenmathang = null;
            IDHDnhaphang = 0;
            IDmathang = 0;
            Soluong = 0;
            Dongia = 0;
            Hansudung = DateTime.Now;
            Ngaynhap = DateTime.Now;
        }
        private CTHD_NHAPHANG _SelectedItem;
        public CTHD_NHAPHANG SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    IDmathang = SelectedItem.ID_MATHANG;
                   // Tenmathang= SelectedItem.MAT_HANG.TEN_MATHANG;
                    IDHDnhaphang = SelectedItem.ID_HDNHAPHANG;
                    Soluong = (int)SelectedItem.SOLUONG;
                    Dongia = (int)SelectedItem.DONGIA;
                    Hansudung = DateTime.Parse(SelectedItem.HANSUDUNG.ToString());
                    Ngaynhap = DateTime.Parse(SelectedItem.NGAYNHAP.ToString());                }
            }
        }
        private int _IDmathang;
        public int IDmathang
        {
            get { return _IDmathang; }
            set
            {
                _IDmathang = value;
                OnPropertyChanged();
            }
        }
        private string _Tenmathang;
        public string Tenmathang
        {
            get { return _Tenmathang; }
            set { _Tenmathang = value;OnPropertyChanged(); }
        }
        private int _IDHDnhaphang;
        public int IDHDnhaphang
        {
            get { return _IDHDnhaphang; }
            set 
            {
                _IDHDnhaphang = value;
                OnPropertyChanged();
            }
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
        private DateTime _Hansudung;
        public DateTime Hansudung
        {
            get { return _Hansudung; }
            set
            {
                _Hansudung = value;
                OnPropertyChanged();
            }
        }
        private DateTime _Ngaynhap;
        public DateTime Ngaynhap
        {
            get { return _Ngaynhap; }
            set
            {
                _Ngaynhap = value;
                OnPropertyChanged();
            }
        }
    }
}
