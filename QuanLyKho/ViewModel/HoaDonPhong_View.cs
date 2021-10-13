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
    public class HoaDonPhong_View : BaseViewModel
    {
        private ObservableCollection<HD_PHONG> _listhdp;
        public ObservableCollection<HD_PHONG> listhdp
        {
            get { return _listhdp; }
            set
            {
                _listhdp = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<NHANVIEN> _listnv;
        public ObservableCollection<NHANVIEN> listnv
        {
            get { return _listnv; }
            set
            {
                _listnv = value;
                OnPropertyChanged();
            }
        }
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
        public ICommand ShowHD { get; set; }
//        public ICommand ShowRP { get; set; }
        public ICommand ResetCommand { get; set; }
        public HoaDonPhong_View()
        {
            listhdp = new ObservableCollection<HD_PHONG>(DataProvider.Ins.DB.HD_PHONG);
            listnv = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            listkh = new ObservableCollection<KHACH_HANG>(DataProvider.Ins.DB.KHACH_HANG);

            //show chi tiết hóa đơn của tất cả các phòng
            ShowHD = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => { DetailWindow hd = new DetailWindow(); hd.ShowDialog(); });
            //report

            //quay lai
            ResetCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null && tenKH == null && Hoten==null)
                    return false;
                return true;
            }, (p) =>
            {
                Reset();
            });
            Reset();
        }
        private HD_PHONG _SelectedItem;
        public HD_PHONG SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem!=null)
                {
                    IDhoadonphong = SelectedItem.ID_HDPHONG;
                    Hoten = SelectedItem.NHANVIEN.HOTEN;
                    IDPhong = (int)SelectedItem.ID_PHONG;
                    tenKH = SelectedItem.KHACH_HANG.TEN_KHACHHANG;
                    giovao = (int)SelectedItem.GIOVAO;
                    giora = (int)SelectedItem.GIORA;
                }
            }
        }
        private void Reset()
        {
            IDhoadonphong = 0;
            Hoten = null;
            IDPhong = 0;
            tenKH = null;
            giovao = 0;
            giora = 0;
        }
        private int _IDhoadonphong;
        public int IDhoadonphong
        {
            get { return _IDhoadonphong; }
            set { _IDhoadonphong = value;OnPropertyChanged(); }
        }

        //private int _IDNhanvien;
        //public int IDNhanvien
        //{
        //    get { return _IDNhanvien; }
        //    set
        //    {
        //        _IDNhanvien = value;
        //        OnPropertyChanged();
        //    }
        //}
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
        private int _IDPhong;
        public int IDPhong
        {
            get
            {
                return _IDPhong;
            }
            set
            {
                _IDPhong = value;
                OnPropertyChanged();
            }
        }
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
        private int _giovao;
        public int giovao
        {
            get { return _giovao;}
            set { _giovao = value;OnPropertyChanged(); }
        }
        private int _giora;
        public int giora
        {
            get { return _giora; }
            set { _giora = value; OnPropertyChanged(); }
        }
    }
}   
