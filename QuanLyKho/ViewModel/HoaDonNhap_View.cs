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
    public class HoaDonNhap_View : BaseViewModel
    {
        private ObservableCollection<HD_NHAPHANG> _listHDNhap;
        public ObservableCollection<HD_NHAPHANG> listHDNhap
        {
            get { return _listHDNhap; }
            set { _listHDNhap = value; OnPropertyChanged(); }
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
        public ICommand ResetCommand { get; set; }
        public ICommand ShowHD { get; set; }
        public HoaDonNhap_View()
        {
            listnv = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            listHDNhap = new ObservableCollection<HD_NHAPHANG>(DataProvider.Ins.DB.HD_NHAPHANG);
            //quay lai
            ResetCommand = new RelayCommand<object>((p) =>
            {
                if (tenNV == null && Selecteditem == null)
                    return false;
                return true;
            }, (p) =>
            {
                Reset();
            });
            //show cthd nhap hang
            ShowHD = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => { OutputWindow hd = new OutputWindow(); hd.ShowDialog(); });
        }
        private int _IDhdnhap;
        public int IDhdnhap
        {
            get { return _IDhdnhap; }
            set { _IDhdnhap = value; OnPropertyChanged(); }
        }
        private int _IDnv;
        public int IDnv
        {
            get { return _IDnv; }
            set { _IDnv = value; OnPropertyChanged(); }
        }
        private string _tenNV;
        public string tenNV
        {
            get { return _tenNV; }
            set
            {
                _tenNV = value;
                OnPropertyChanged();
            }
        }
        private HD_NHAPHANG _Selecteditem;
        public HD_NHAPHANG Selecteditem
        {
            get { return _Selecteditem; }
            set
            {
                _Selecteditem = value;
                OnPropertyChanged();
                if (Selecteditem != null)
                {
                    IDhdnhap = Selecteditem.ID_HDNHAPHANG;
                    tenNV = Selecteditem.NHANVIEN.HOTEN;
                }
            }
        }
        private void Reset()
        {
            IDnv = 0;
            IDhdnhap = 0;
            tenNV = null;
        }
        
    }
}