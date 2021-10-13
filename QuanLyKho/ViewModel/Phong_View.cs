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
    public class Phong_View : BaseViewModel
    {
        private ObservableCollection<PHONG> _listPhong;
        public ObservableCollection<PHONG> listPhong
        {
            get
            {
                return _listPhong;
            }
            set
            {
                _listPhong = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<LOAI_PHONG> _listLoaiPhong;
        public ObservableCollection<LOAI_PHONG> listLoaiPhong
        {
            get
            {
                return _listLoaiPhong;
            }
            set
            {
                _listLoaiPhong = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand ShowHD { get; set; }

        private void Reset()
        {
            IDPhong = 0;
            SelectedTenLP = null;
            SoPhong = null;
            Gia = 0;
            TrangThai = null;
            SucChua = null;
        }
        public Phong_View()
        {
            listPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            listLoaiPhong = new ObservableCollection<LOAI_PHONG>(DataProvider.Ins.DB.LOAI_PHONG);
            //them
            AddCommand = new RelayCommand<object>((p) =>
              {
                  if (SelectedTenLP != null)
                  {
                      return true;
                  }
                  return false;
              }, (p) =>
              {
                  try
                  {
                      PHONG P = new PHONG() { ID_PHONG = IDPhong, ID_LOAIPHONG = SelectedTenLP.ID_LOAIPHONG, SO_PHONG = SoPhong, TRANGTHAI = TrangThai, SUCCHUA = SucChua, GIAPHONG = Gia };
                      DataProvider.Ins.DB.PHONGs.Add(P);
                      DataProvider.Ins.DB.SaveChanges();
                      listPhong.Add(P);
                      MessageBox.Show("Da them thanh cong", "Thông Báo");
                      Reset();
                  }
                  catch
                  {
                      MessageBox.Show("Da them that bai", "Thông Báo");
                  }
              });
            //xoa
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedTenLP != null)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                try
                {
                    PHONG P = new PHONG();
                    P = (from ph in DataProvider.Ins.DB.PHONGs where ph.ID_PHONG == SelectedItem.ID_PHONG select ph).Single();

                    DataProvider.Ins.DB.PHONGs.Remove(P);
                    DataProvider.Ins.DB.SaveChanges();
                    listPhong.Remove(P);
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
                var Ph = DataProvider.Ins.DB.PHONGs.Where(x => x.ID_PHONG == IDPhong);
                if (Ph == null || Ph.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.PHONGs.Where(x => x.ID_PHONG == SelectedItem.ID_PHONG).SingleOrDefault();
                    unit.ID_PHONG = IDPhong;
                    unit.ID_LOAIPHONG = SelectedTenLP.ID_LOAIPHONG;
                    unit.SO_PHONG = SoPhong;
                    unit.TRANGTHAI = TrangThai;
                    unit.SUCCHUA = SucChua;
                    unit.GIAPHONG = Gia;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông Báo");
                    listPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
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
                 if (SelectedTenLP == null && SoPhong == null && TrangThai == null && Gia == null && SucChua == null && SelectedItem == null)
                     return false;
                 return true;
             }, (p) =>
             {
                 Reset();
             });
            Reset();
        }
        private string _SoPhong;
        public string SoPhong
        {
            get
            {
                return _SoPhong;
            }
            set
            {
                _SoPhong = value;
                OnPropertyChanged();
            }
        }
        private LOAI_PHONG _SelectedTenLP;
        public LOAI_PHONG SelectedTenLP
        {
            get
            {
                return _SelectedTenLP;
            }
            set
            {
                _SelectedTenLP = value;
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
        private string _TrangThai;
        public string TrangThai
        {
            get
            {
                return _TrangThai;
            }
            set
            {
                _TrangThai = value;
                OnPropertyChanged();
            }
        }
        private string _SucChua;
        public string SucChua
        {
            get
            {
                return _SucChua;
            }
            set
            {
                _SucChua = value;
                OnPropertyChanged();
            }
        }
        private int _Gia;
        public int Gia
        {
            get
            {
                return _Gia;
            }
            set
            {
                _Gia = value;
                OnPropertyChanged();
            }
        }
        private PHONG _SelectedItem;
        public PHONG SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    IDPhong = SelectedItem.ID_PHONG;
                    SelectedTenLP = SelectedItem.LOAI_PHONG;
                    SoPhong = SelectedItem.SO_PHONG;
                    TrangThai = SelectedItem.TRANGTHAI;
                    SucChua = SelectedItem.SUCCHUA;
                    Gia = (int)SelectedItem.GIAPHONG;
                }
            }
        }
    }
}
