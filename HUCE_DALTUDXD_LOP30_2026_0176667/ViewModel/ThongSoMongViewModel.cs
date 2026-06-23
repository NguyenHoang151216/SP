using HUCE_DALTUDXD_LOP30_2026_0176667.Commands;
using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel
{
    public class ThongSoMongViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<string> _danhSachMacBeTong = new ObservableCollection<string> { "B15", "B20", "B25", "B30" };
        private readonly ObservableCollection<string> _danhSachLoaiThep = new ObservableCollection<string> { "CB240-T", "CB300-V", "CB400-V", "CB500-V" };

        private string _chieuDaiMong = string.Empty;
        private string _chieuRongMong = string.Empty;
        private string _chieuCaoMong = string.Empty;
        private string _chieuSauChonMong = string.Empty;
        private string _taiTrongN = string.Empty;
        private string _taiTrongQ = string.Empty;
        private string _moMenM = string.Empty;
        private string _chieuDaiCot = string.Empty;
        private string _chieuRongCot = string.Empty;
        private string _selectedMacBeTong = string.Empty;
        private string _selectedLoaiThep = string.Empty;
        private float _cuongDoBeTong;
        private float _cuongDoThep;
        private string _luuStatus = string.Empty;
        private MongDon _mongDuocChon;
        private DuLieuDat _datDuocChon;
        private ObservableCollection<MongDon> _danhSachMongTheoDat = new ObservableCollection<MongDon>();

        public ThongSoMongViewModel()
        {
            LuuCommand = new LenhRelay(Luu);
            TaoMoiCommand = new LenhRelay(TaoMoi);
            SelectedMacBeTong = "B20";
            SelectedLoaiThep = "CB400-V";
            DatDuocChon = DuLieuDat.LayDatDangChon();
            MongDuocChon = DatDuocChon?.LayMongDangTinhToan() ?? MongDon.LayMongDangChon();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand LuuCommand { get; }
        public ICommand TaoMoiCommand { get; }

        public ObservableCollection<string> DanhSachMacBeTong => _danhSachMacBeTong;
        public ObservableCollection<string> DanhSachLoaiThep => _danhSachLoaiThep;
        public ObservableCollection<DuLieuDat> DanhSachDat => DuLieuDat.ThongTinDat;
        public ObservableCollection<MongDon> DanhSachMong => _danhSachMongTheoDat;

        public DuLieuDat DatDuocChon
        {
            get => _datDuocChon;
            set
            {
                if (_datDuocChon == value)
                    return;

                _datDuocChon = value;
                DuLieuDat.DatDangChon = value;
                _danhSachMongTheoDat = value?.DanhSachMong ?? new ObservableCollection<MongDon>();
                MongDuocChon = value?.LayMongDangTinhToan();
                OnPropertyChanged(nameof(DatDuocChon));
                OnPropertyChanged(nameof(DanhSachMong));
            }
        }

        public MongDon MongDuocChon
        {
            get => _mongDuocChon;
            set
            {
                if (_mongDuocChon == value)
                    return;

                _mongDuocChon = value;
                MongDon.MongDangChon = value;
                MongDon.ThongTinMong = value;
                if (DatDuocChon != null)
                {
                    DatDuocChon.MongDangTinhToan = value;
                    DuLieuDat.DatDangChon = DatDuocChon;
                }

                NapDuLieuMong(value);
                OnPropertyChanged(nameof(MongDuocChon));
            }
        }

        public string ChieuDaiMong
        {
            get => _chieuDaiMong;
            set => SetStringValue(ref _chieuDaiMong, value, nameof(ChieuDaiMong));
        }

        public string ChieuRongMong
        {
            get => _chieuRongMong;
            set => SetStringValue(ref _chieuRongMong, value, nameof(ChieuRongMong));
        }

        public string ChieuCaoMong
        {
            get => _chieuCaoMong;
            set => SetStringValue(ref _chieuCaoMong, value, nameof(ChieuCaoMong));
        }

        public string ChieuSauChonMong
        {
            get => _chieuSauChonMong;
            set => SetStringValue(ref _chieuSauChonMong, value, nameof(ChieuSauChonMong));
        }

        public string TaiTrongN
        {
            get => _taiTrongN;
            set => SetStringValue(ref _taiTrongN, value, nameof(TaiTrongN));
        }

        public string TaiTrongQ
        {
            get => _taiTrongQ;
            set => SetStringValue(ref _taiTrongQ, value, nameof(TaiTrongQ));
        }

        public string MoMenM
        {
            get => _moMenM;
            set => SetStringValue(ref _moMenM, value, nameof(MoMenM));
        }

        public string ChieuDaiCot
        {
            get => _chieuDaiCot;
            set => SetStringValue(ref _chieuDaiCot, value, nameof(ChieuDaiCot));
        }

        public string ChieuRongCot
        {
            get => _chieuRongCot;
            set => SetStringValue(ref _chieuRongCot, value, nameof(ChieuRongCot));
        }

        public string SelectedMacBeTong
        {
            get => _selectedMacBeTong;
            set
            {
                if (_selectedMacBeTong == value)
                    return;

                _selectedMacBeTong = value;
                CuongDoBeTong = TinhCuongDoBeTong(value);
                OnPropertyChanged(nameof(SelectedMacBeTong));
            }
        }

        public string SelectedLoaiThep
        {
            get => _selectedLoaiThep;
            set
            {
                if (_selectedLoaiThep == value)
                    return;

                _selectedLoaiThep = value;
                CuongDoThep = TinhCuongDoThep(value);
                OnPropertyChanged(nameof(SelectedLoaiThep));
            }
        }

        public float CuongDoBeTong
        {
            get => _cuongDoBeTong;
            set
            {
                if (_cuongDoBeTong == value)
                    return;

                _cuongDoBeTong = value;
                OnPropertyChanged(nameof(CuongDoBeTong));
            }
        }

        public float CuongDoThep
        {
            get => _cuongDoThep;
            set
            {
                if (_cuongDoThep == value)
                    return;

                _cuongDoThep = value;
                OnPropertyChanged(nameof(CuongDoThep));
            }
        }

        public string LuuStatus
        {
            get => _luuStatus;
            set
            {
                if (_luuStatus == value)
                    return;

                _luuStatus = value;
                OnPropertyChanged(nameof(LuuStatus));
            }
        }

        private float TinhCuongDoBeTong(string macBeTong)
        {
            switch (macBeTong)
            {
                case "B15": return 0.75f;
                case "B20": return 0.9f;
                case "B25": return 1.05f;
                case "B30": return 1.15f;
                default: return 0.75f;
            }
        }

        private float TinhCuongDoThep(string loaiThep)
        {
            switch (loaiThep)
            {
                case "CB240-T": return 210f;
                case "CB300-V": return 260f;
                case "CB400-V": return 350f;
                case "CB500-V": return 435f;
                default: return 350f;
            }
        }

        private void Luu(object parameter)
        {
            if (DatDuocChon == null)
            {
                LuuStatus = "Vui long nhap va chon thong so dat truoc khi luu mong.";
                MessageBox.Show(LuuStatus, "Thong bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TaoThongSoMong(out var mongDon, out var loi))
            {
                LuuStatus = loi;
                MessageBox.Show(loi, "Thong bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MongDuocChon != null && DatDuocChon.DanhSachMong.Contains(MongDuocChon))
            {
                CapNhatMong(MongDuocChon, mongDon);
                mongDon = MongDuocChon;
            }
            else
            {
                mongDon.IdMong = DatDuocChon.DanhSachMong.Count + 1;
                mongDon.TenMong = $"Mong {mongDon.IdMong}";
                DatDuocChon.DanhSachMong.Add(mongDon);
            }

            mongDon.LopDat = DatDuocChon;
            DatDuocChon.MongDangTinhToan = mongDon;
            DuLieuDat.DatDangChon = DatDuocChon;
            MongDon.ThongTinMong = mongDon;
            MongDon.MongDangChon = mongDon;
            MongDuocChon = mongDon;
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.SolieuData = mongDon;
                mainWindow.ChonDuLieuTinhToan(mongDon, DatDuocChon);
            }

            LuuStatus = $"Da luu {mongDon.TenHienThi}.";
            MessageBox.Show("Du lieu mong da duoc luu.", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void TaoMoi(object parameter)
        {
            MongDuocChon = null;
            ChieuDaiMong = string.Empty;
            ChieuRongMong = string.Empty;
            ChieuCaoMong = string.Empty;
            ChieuSauChonMong = string.Empty;
            TaiTrongN = string.Empty;
            TaiTrongQ = string.Empty;
            MoMenM = string.Empty;
            ChieuDaiCot = string.Empty;
            ChieuRongCot = string.Empty;
            SelectedMacBeTong = "B20";
            SelectedLoaiThep = "CB400-V";
            LuuStatus = "Dang nhap thong so mong moi.";
        }

        private bool TaoThongSoMong(out MongDon mongDon, out string loi)
        {
            mongDon = new MongDon();

            if (!TryParsePositive(ChieuDaiMong, out var chieuDaiMong)
                || !TryParsePositive(ChieuRongMong, out var chieuRongMong)
                || !TryParsePositive(ChieuCaoMong, out var chieuCaoMong)
                || !TryParsePositive(ChieuSauChonMong, out var chieuSauChonMong)
                || !TryParsePositive(TaiTrongN, out var taiTrongN)
                || !TryParsePositive(ChieuDaiCot, out var chieuDaiCot)
                || !TryParsePositive(ChieuRongCot, out var chieuRongCot))
            {
                loi = "Vui long nhap cac gia tri kich thuoc va tai trong N lon hon 0.";
                return false;
            }

            if (!TryParseOptionalNumber(TaiTrongQ, out var taiTrongQ)
                || !TryParseOptionalNumber(MoMenM, out var moMenM))
            {
                loi = "Vui long nhap tai trong Q va mo men M hop le.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedMacBeTong) || string.IsNullOrWhiteSpace(SelectedLoaiThep))
            {
                loi = "Vui long chon mac be tong va loai cot thep.";
                return false;
            }

            mongDon.chieuDaiMong = chieuDaiMong;
            mongDon.chieuRongMong = chieuRongMong;
            mongDon.chieuCaoMong = chieuCaoMong;
            mongDon.chieuSauChonMong = chieuSauChonMong;
            mongDon.N = taiTrongN;
            mongDon.Q = taiTrongQ;
            mongDon.Momen = moMenM;
            mongDon.chieuDaiCot = chieuDaiCot;
            mongDon.chieuRongCot = chieuRongCot;
            mongDon.macBeTong = SelectedMacBeTong;
            mongDon.macThep = SelectedLoaiThep;
            mongDon.cuongDoBeTong = CuongDoBeTong;
            mongDon.cuongDoThep = CuongDoThep;

            loi = string.Empty;
            return true;
        }

        private void CapNhatMong(MongDon mongCu, MongDon mongMoi)
        {
            mongCu.chieuDaiMong = mongMoi.chieuDaiMong;
            mongCu.chieuRongMong = mongMoi.chieuRongMong;
            mongCu.chieuCaoMong = mongMoi.chieuCaoMong;
            mongCu.chieuSauChonMong = mongMoi.chieuSauChonMong;
            mongCu.N = mongMoi.N;
            mongCu.Q = mongMoi.Q;
            mongCu.Momen = mongMoi.Momen;
            mongCu.chieuDaiCot = mongMoi.chieuDaiCot;
            mongCu.chieuRongCot = mongMoi.chieuRongCot;
            mongCu.macBeTong = mongMoi.macBeTong;
            mongCu.macThep = mongMoi.macThep;
            mongCu.cuongDoBeTong = mongMoi.cuongDoBeTong;
            mongCu.cuongDoThep = mongMoi.cuongDoThep;
            mongCu.LopDat = DatDuocChon;
            OnPropertyChanged(nameof(DanhSachMong));
        }

        private void NapDuLieuMong(MongDon mong)
        {
            if (mong == null)
            {
                ChieuDaiMong = string.Empty;
                ChieuRongMong = string.Empty;
                ChieuCaoMong = string.Empty;
                ChieuSauChonMong = string.Empty;
                TaiTrongN = string.Empty;
                TaiTrongQ = string.Empty;
                MoMenM = string.Empty;
                ChieuDaiCot = string.Empty;
                ChieuRongCot = string.Empty;
                return;
            }

            ChieuDaiMong = mong.chieuDaiMong.ToString(CultureInfo.InvariantCulture);
            ChieuRongMong = mong.chieuRongMong.ToString(CultureInfo.InvariantCulture);
            ChieuCaoMong = mong.chieuCaoMong.ToString(CultureInfo.InvariantCulture);
            ChieuSauChonMong = mong.chieuSauChonMong.ToString(CultureInfo.InvariantCulture);
            TaiTrongN = mong.N.ToString(CultureInfo.InvariantCulture);
            TaiTrongQ = mong.Q.ToString(CultureInfo.InvariantCulture);
            MoMenM = mong.Momen.ToString(CultureInfo.InvariantCulture);
            ChieuDaiCot = mong.chieuDaiCot.ToString(CultureInfo.InvariantCulture);
            ChieuRongCot = mong.chieuRongCot.ToString(CultureInfo.InvariantCulture);
            SelectedMacBeTong = string.IsNullOrWhiteSpace(mong.macBeTong) ? "B20" : mong.macBeTong;
            SelectedLoaiThep = string.IsNullOrWhiteSpace(mong.macThep) ? "CB400-V" : mong.macThep;
        }

        private bool TryParsePositive(string value, out float number)
        {
            return TryParseNumber(value, out number) && number > 0;
        }

        private bool TryParseNumber(string value, out float number)
        {
            value = (value ?? string.Empty).Trim().Replace(',', '.');
            return float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out number);
        }

        private bool TryParseOptionalNumber(string value, out float number)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                number = 0;
                return true;
            }

            return TryParseNumber(value, out number);
        }

        private void SetStringValue(ref string field, string value, string propertyName)
        {
            value ??= string.Empty;
            if (field == value)
                return;

            field = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
