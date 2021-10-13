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
    public class NhanVien_View:BaseViewModel
    {
        private ObservableCollection<NHANVIEN> _listNv;
        public ObservableCollection<NHANVIEN> listNv
        {
            get{return _listNv;}

            set
            {
                _listNv = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ReturnCommand { get; set; }
        private void Reset()
        {
            IDNhanvien = 0;
            Hoten = null;
            username= null;
            password = null;
            diachi = null;
            gt = null;
            sdt = null;
            cmnd = null;
            ttgd = null;
            quyen = null;
        }
        public NhanVien_View()
        {
            listNv = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
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
                    NHANVIEN N = new NHANVIEN() { ID_NHANVIEN = IDNhanvien, TAIKHOAN = username, MATKHAU = password,
                    HOTEN = Hoten, DIACHI = diachi, GIOITINH = gt,SDT=sdt,CMND=cmnd,TINHTRANGGD=ttgd,QUYEN=quyen };
                    DataProvider.Ins.DB.NHANVIENs.Add(N);
                    DataProvider.Ins.DB.SaveChanges();
                    listNv.Add(N);
                    MessageBox.Show("Đã thêm thành công", "Thông Báo");
                    Reset();
                }
                catch
                {
                    MessageBox.Show("Đã thêm thất bại", "Thông Báo");
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
                    NHANVIEN P = new NHANVIEN();
                    P = (from ph in DataProvider.Ins.DB.NHANVIENs where ph.ID_NHANVIEN == SelectedItem.ID_NHANVIEN select ph).Single();

                    DataProvider.Ins.DB.NHANVIENs.Remove(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listNv.Remove(P);
                    MessageBox.Show("Đã xóa thành công", "Thông Báo");
                    Reset();

                }
                catch
                {
                    MessageBox.Show("Đã xóa thất bại", "Thông Báo");
                }
            });
            //sua
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                var Ph = DataProvider.Ins.DB.NHANVIENs.Where(x => x.ID_NHANVIEN == IDNhanvien);
                if (Ph == null || Ph.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.NHANVIENs.Where(x => x.ID_NHANVIEN == SelectedItem.ID_NHANVIEN).SingleOrDefault();
                    unit.ID_NHANVIEN = IDNhanvien;
                    unit.TAIKHOAN = username;
                    unit.MATKHAU = password;
                    unit.HOTEN = Hoten;
                    unit.DIACHI = diachi;
                    unit.GIOITINH = gt;
                    unit.SDT = sdt;
                    unit.CMND = cmnd;
                    unit.TINHTRANGGD = ttgd;
                    unit.QUYEN = quyen;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                    listNv = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
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
                if (username == null && password == null && Hoten == null && diachi == null 
                && gt == null && sdt == null && cmnd == null && ttgd == null && quyen == null)
                    return false;
                return true;
            }, (p) =>
            {
                Reset();
            });
            Reset();
        }
        private int _IDNhanvien;
        public int IDNhanvien
        {
            get { return _IDNhanvien; }
            set
            {
                _IDNhanvien = value;
                OnPropertyChanged();
            }
        }
        private string _Hoten;
        public string Hoten
        {
            get { return _Hoten; }
            set
            {
                _Hoten = value;
                OnPropertyChanged();
            }
        }
        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private string _diachi;
        public string diachi
        {
            get { return _diachi; }
            set
            {
                _diachi = value;
                OnPropertyChanged();
            }
        }
        private string _gt;
        public string gt
        {
            get { return _gt; }
            set
            {
                _gt = value;
                OnPropertyChanged();
            }
        }
        private string _sdt;
        public   string sdt
        {
            get { return _sdt; }
            set
            {
                _sdt = value;
                OnPropertyChanged();
            }
        }
        private string _cmnd;
        public string cmnd
        {
            get { return _cmnd; }
            set
            {
                _cmnd = value;
                OnPropertyChanged();
            }
        }
        private string _ttgd;
        public string ttgd
        {
            get { return _ttgd; }
            set
            {
                _ttgd = value;
                OnPropertyChanged();
            }
        }
        private string _quyen;
        public string quyen
        {
            get { return _quyen; }
            set
            {
                _quyen = value;
                OnPropertyChanged();
            }
        }
        private NHANVIEN _SelectedItem;
        public NHANVIEN SelectedItem
        {
            get{ return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    IDNhanvien = SelectedItem.ID_NHANVIEN;
                    Hoten = SelectedItem.HOTEN;
                    username = SelectedItem.TAIKHOAN;
                    password = SelectedItem.MATKHAU;
                    diachi = SelectedItem.DIACHI;
                    gt = SelectedItem.GIOITINH;
                    sdt = SelectedItem.SDT;
                    cmnd = SelectedItem.CMND;
                    ttgd = SelectedItem.TINHTRANGGD;
                    quyen = SelectedItem.QUYEN;
                }
            }
        }
    }
}
