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
    public class NhaCungCap_View : BaseViewModel
    {
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
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        // hàm dựng
        public NhaCungCap_View()
        {
            ListNhaCungCap = new ObservableCollection<NHACUNGCAP>(DataProvider.Ins.DB.NHACUNGCAPs);
            //them
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
                    NHACUNGCAP P = new NHACUNGCAP() { ID_NHACUNGCAP = IDNhacungcap, TEN_NHACUNGCAP = TenNhacungcap, DIENTHOAI = Dienthoai, DIACHI = Diachi, EMAIL = Email };
                    DataProvider.Ins.DB.NHACUNGCAPs.Add(P);
                    DataProvider.Ins.DB.SaveChanges();
                    ListNhaCungCap.Add(P);
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
                if (selectedItem != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    NHACUNGCAP P = new NHACUNGCAP();
                    P = (from ph in DataProvider.Ins.DB.NHACUNGCAPs where ph.ID_NHACUNGCAP == selectedItem.ID_NHACUNGCAP select ph).Single();
                    DataProvider.Ins.DB.NHACUNGCAPs.Remove(P);
                    DataProvider.Ins.DB.SaveChanges();
                    ListNhaCungCap.Remove(P);
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
                var Ph = DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.ID_NHACUNGCAP == IDNhacungcap);
                if (Ph == null || Ph.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.ID_NHACUNGCAP == selectedItem.ID_NHACUNGCAP).SingleOrDefault();
                    unit.ID_NHACUNGCAP = IDNhacungcap;
                    unit.TEN_NHACUNGCAP = TenNhacungcap;
                    unit.DIACHI = Diachi;
                    unit.DIENTHOAI = Dienthoai;
                    unit.EMAIL = Email;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                    ListNhaCungCap = new ObservableCollection<NHACUNGCAP>(DataProvider.Ins.DB.NHACUNGCAPs);
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
                if (selectedItem == null && IDNhacungcap == 0 && TenNhacungcap == null && Diachi == null && Email == null)
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
            IDNhacungcap = 0;
            TenNhacungcap = null;
            Dienthoai = null;
            Diachi = null;
            Email = null;
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
        private string _Dienthoai;
        public string Dienthoai
        {
            get { return _Dienthoai; }
            set
            {
                _Dienthoai = value;
                OnPropertyChanged();
            }
        }
        private string _Diachi;
        public string Diachi
        {
            get { return _Diachi; }
            set
            {
                _Diachi = value;
                OnPropertyChanged();
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
        }
        private NHACUNGCAP _selectedItem;
        public NHACUNGCAP selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (selectedItem != null)
                {
                    IDNhacungcap = selectedItem.ID_NHACUNGCAP;
                    TenNhacungcap = selectedItem.TEN_NHACUNGCAP;
                    Diachi = selectedItem.DIACHI;
                    Dienthoai = selectedItem.DIENTHOAI;
                    Email = selectedItem.EMAIL;
                }

            }
        }
    }
}
