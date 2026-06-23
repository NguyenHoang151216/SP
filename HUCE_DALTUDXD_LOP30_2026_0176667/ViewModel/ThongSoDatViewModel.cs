using HUCE_DALTUDXD_LOP30_2026_0176667.Commands;
using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel
{
    public class ThongSoDatViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DuLieuDat> _danhSachDat;
        private string _idDat;
        private string _loaiDat;
        private string _trangThai;
        private double _gocMaSat;
        private double _modunNenEp;
        private double _lucDinh;
        private double _dungTrong;
        private double _chieuDay;
        private DuLieuDat _duLieuDuocChon;

        public ThongSoDatViewModel()
        {
            ThemDatCommand = new LenhRelay(ThemDat);
            XoaDatCommand = new LenhRelay(XoaDat, CoTheXoaDat);
            DanhSachDat = DuLieuDat.ThongTinDat;
            DuLieuDuocChon = DuLieuDat.LayDatDangChon();
        }

        public ObservableCollection<DuLieuDat> DanhSachDat
        {
            get => _danhSachDat;
            set
            {
                _danhSachDat = value;
                OnPropertyChanged(nameof(DanhSachDat));
            }
        }

        public string IdDat
        {
            get => _idDat;
            set
            {
                _idDat = value;
                OnPropertyChanged(nameof(IdDat));
            }
        }

        public string LoaiDat
        {
            get => _loaiDat;
            set
            {
                _loaiDat = value;
                OnPropertyChanged(nameof(LoaiDat));
            }
        }

        public string TrangThai
        {
            get => _trangThai;
            set
            {
                _trangThai = value;
                OnPropertyChanged(nameof(TrangThai));
            }
        }

        public double GocMaSat
        {
            get => _gocMaSat;
            set
            {
                _gocMaSat = value;
                OnPropertyChanged(nameof(GocMaSat));
            }
        }

        public double ModunNenEp
        {
            get => _modunNenEp;
            set
            {
                _modunNenEp = value;
                OnPropertyChanged(nameof(ModunNenEp));
            }
        }

        public double LucDinh
        {
            get => _lucDinh;
            set
            {
                _lucDinh = value;
                OnPropertyChanged(nameof(LucDinh));
            }
        }

        public double DungTrong
        {
            get => _dungTrong;
            set
            {
                _dungTrong = value;
                OnPropertyChanged(nameof(DungTrong));
            }
        }

        public double ChieuDay
        {
            get => _chieuDay;
            set
            {
                _chieuDay = value;
                OnPropertyChanged(nameof(ChieuDay));
            }
        }

        public DuLieuDat DuLieuDuocChon
        {
            get => _duLieuDuocChon;
            set
            {
                _duLieuDuocChon = value;
                DuLieuDat.DatDangChon = value;
                OnPropertyChanged(nameof(DuLieuDuocChon));
                ((LenhRelay)XoaDatCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand ThemDatCommand { get; }
        public ICommand XoaDatCommand { get; }

        private void ThemDat(object parameter)
        {
            var duLieuMoi = new DuLieuDat
            {
                IdDat = DanhSachDat.Count + 1,
                LoaiDat = LoaiDat,
                TrangThai = TrangThai,
                GocMaSat = GocMaSat,
                ModunNenEp = ModunNenEp,
                LucDinh = LucDinh,
                DungTrong = DungTrong,
                ChieuDay = ChieuDay
            };

            DanhSachDat.Add(duLieuMoi);
            DuLieuDuocChon = duLieuMoi;
            XoaDuLieuNhap();
        }

        private void XoaDat(object parameter)
        {
            if (DuLieuDuocChon == null)
                return;

            var dangXoaLopDangChon = DuLieuDuocChon == DuLieuDat.DatDangChon;
            DanhSachDat.Remove(DuLieuDuocChon);
            CapNhatId();
            if (dangXoaLopDangChon)
                DuLieuDuocChon = DanhSachDat.Count > 0 ? DanhSachDat[0] : null;

        }

        private bool CoTheXoaDat(object parameter) => DuLieuDuocChon != null;

        private void CapNhatId()
        {
            for (int i = 0; i < DanhSachDat.Count; i++)
            {
                DanhSachDat[i].IdDat = i + 1;
            }
        }

        private void XoaDuLieuNhap()
        {
            IdDat = string.Empty;
            LoaiDat = string.Empty;
            TrangThai = string.Empty;
            GocMaSat = 0;
            ModunNenEp = 0;
            LucDinh = 0;
            DungTrong = 0;
            ChieuDay = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
