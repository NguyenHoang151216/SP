using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HUCE_DALTUDXD_LOP30_2026_0176667.Commands;
using HUCE_DALTUDXD_LOP30_2026_0176667.Model;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel
{
    public class BoTriCotThepViewModel : INotifyPropertyChanged
    {
        private CotThepBoTri _cotThepBoTri;
        private ChongDamThung _chongDamThung;
        private MongDon _mongDon;
        private DuLieuDat _duLieuDat;
        private TinhToanCotThep _tinhToanCotThep;

        // Constructor - UPDATED
        public BoTriCotThepViewModel(MongDon mongDon, DuLieuDat duLieuDat, TinhToanCotThep tinhToanCotThep, ChongDamThung chongDamThung)
        {
            _mongDon = mongDon ?? new MongDon();
            _duLieuDat = duLieuDat ?? new DuLieuDat();
            _tinhToanCotThep = tinhToanCotThep ?? new TinhToanCotThep();
            _chongDamThung = chongDamThung ?? new ChongDamThung();

            _cotThepBoTri = CotThepBoTri.ThongTinBoTri ?? new CotThepBoTri();
            _cotThepBoTri.MongDon = _mongDon;
            _cotThepBoTri.DuLieuDat = _duLieuDat;

            InitializeCommands();
        }

        public BoTriCotThepViewModel()
        {
            _cotThepBoTri = CotThepBoTri.ThongTinBoTri ?? new CotThepBoTri();
            _mongDon = new MongDon();
            _chongDamThung = new ChongDamThung();
            _tinhToanCotThep = new TinhToanCotThep();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            TinhToanCommand = new RelayCommand(ExecuteTinhToan);
            LuuCommand = new RelayCommand(ExecuteLuu);
        }

        public float ChieuRongMong
        {
            get => _mongDon.chieuRongMong;
            set
            {
                if (_mongDon.chieuRongMong != value)
                {
                    _mongDon.chieuRongMong = value;
                    OnPropertyChanged(nameof(ChieuRongMong));
                }
            }
        }

        public float ChieuDayLopBaoVe
        {
            get => _chongDamThung.ChieuDayLopBaoVe;
            set
            {
                if (_chongDamThung.ChieuDayLopBaoVe != value)
                {
                    _chongDamThung.ChieuDayLopBaoVe = value;
                    OnPropertyChanged(nameof(ChieuDayLopBaoVe));
                }
            }
        }

        public float ChieuDaiMong
        {
            get => _mongDon.chieuDaiMong;
            set
            {
                if (_mongDon.chieuDaiMong != value)
                {
                    _mongDon.chieuDaiMong = value;
                    OnPropertyChanged(nameof(ChieuDaiMong));
                }
            }
        }

        public float ChieuCaoMong
        {
            get => _mongDon.chieuCaoMong;
            set
            {
                if (_mongDon.chieuCaoMong != value)
                {
                    _mongDon.chieuCaoMong = value;
                    OnPropertyChanged(nameof(ChieuCaoMong));
                }
            }
        }

        public float ChieuSauChonMong
        {
            get => _mongDon.chieuSauChonMong;
            set
            {
                if (_mongDon.chieuSauChonMong != value)
                {
                    _mongDon.chieuSauChonMong = value;
                    OnPropertyChanged(nameof(ChieuSauChonMong));
                }
            }
        }

        #region Properties

        // Cốt thép phương cạnh dài
        public double DuongKinhThepDai
        {
            get => _cotThepBoTri.DuongKinhThepDai;
            set
            {
                if (_cotThepBoTri.DuongKinhThepDai != value)
                {
                    _cotThepBoTri.DuongKinhThepDai = value;
                    OnPropertyChanged();
                    TinhToanCotThepDai();
                }
            }
        }

        public double SoLuongThepDai
        {
            get => _cotThepBoTri.SoLuongThepDai;
            set
            {
                if (_cotThepBoTri.SoLuongThepDai != value)
                {
                    _cotThepBoTri.SoLuongThepDai = value;
                    OnPropertyChanged();
                }
            }
        }

        public double KhoangCachThepDai
        {
            get => _cotThepBoTri.KhoangCachThepDai;
            set
            {
                if (_cotThepBoTri.KhoangCachThepDai != value)
                {
                    _cotThepBoTri.KhoangCachThepDai = value;
                    OnPropertyChanged();
                    TinhToanCotThepDai();
                }
            }
        }

        public double DienTichThepDai
        {
            get => _cotThepBoTri.DienTichThepDai;
            set
            {
                if (_cotThepBoTri.DienTichThepDai != value)
                {
                    _cotThepBoTri.DienTichThepDai = value;
                    OnPropertyChanged();
                }
            }
        }

        public double FaYeuCauNgan
        {
            get => _tinhToanCotThep.FaYeuCauNgan;
            set
            {
                if (_tinhToanCotThep.FaYeuCauNgan != value)
                {
                    _tinhToanCotThep.FaYeuCauNgan = value;
                    OnPropertyChanged(nameof(FaYeuCauNgan));
                }
            }
        }

        // Cốt thép phương cạnh ngắn
        public double DuongKinhThepNgan
        {
            get => _cotThepBoTri.DuongKinhThepNgan;
            set
            {
                if (_cotThepBoTri.DuongKinhThepNgan != value)
                {
                    _cotThepBoTri.DuongKinhThepNgan = value;
                    OnPropertyChanged();
                    TinhToanCotThepNgan();
                }
            }
        }

        public double SoLuongThepNgan
        {
            get => _cotThepBoTri.SoLuongThepNgan;
            set
            {
                if (_cotThepBoTri.SoLuongThepNgan != value)
                {
                    _cotThepBoTri.SoLuongThepNgan = value;
                    OnPropertyChanged();
                }
            }
        }

        public double KhoangCachThepNgan
        {
            get => _cotThepBoTri.KhoangCachThepNgan;
            set
            {
                if (_cotThepBoTri.KhoangCachThepNgan != value)
                {
                    _cotThepBoTri.KhoangCachThepNgan = value;
                    OnPropertyChanged();
                    TinhToanCotThepNgan();
                }
            }
        }

        public double DienTichThepNgan
        {
            get => _cotThepBoTri.DienTichThepNgan;
            set
            {
                if (_cotThepBoTri.DienTichThepNgan != value)
                {
                    _cotThepBoTri.DienTichThepNgan = value;
                    OnPropertyChanged();
                }
            }
        }

        public double FaYeuCauDai
        {
            get => _tinhToanCotThep.FaYeuCauDai;
            set
            {
                if (_tinhToanCotThep.FaYeuCauDai != value)
                {
                    _tinhToanCotThep.FaYeuCauDai = value;
                    OnPropertyChanged(nameof(FaYeuCauDai));
                }
            }
        }

        #endregion

        #region Commands

        public ICommand TinhToanCommand { get; private set; }
        public ICommand LuuCommand { get; private set; }

        #endregion

        #region Private Methods

        private void TinhToanCotThepDai()
        {
            if (DuongKinhThepDai > 0 && KhoangCachThepDai > 0)
            {
                // Tính diện tích một thanh thép (mm²)
                double dienTichMotThanh = Math.PI * (DuongKinhThepDai * DuongKinhThepDai) / 4;

                // Chiều dài có hiệu (m -> mm), trừ 2 lần chiều dày lớp bảo vệ
                double chieuDaiHieuLuc = (_mongDon.chieuDaiMong * 1000) - (2 * _chongDamThung.ChieuDayLopBaoVe * 1000);

                // Tính số lượng thanh thép
                // Số khoảng = chiều dài hiệu lực / khoảng cách
                // Số thanh = số khoảng + 1
                SoLuongThepDai = Math.Ceiling(chieuDaiHieuLuc / KhoangCachThepDai) + 1;

                // Tính tổng diện tích cốt thép (mm²)
                DienTichThepDai = SoLuongThepDai * dienTichMotThanh;
            }
        }

        private void TinhToanCotThepNgan()
        {
            if (DuongKinhThepNgan > 0 && KhoangCachThepNgan > 0)
            {
                // Tính diện tích một thanh thép (mm²)
                double dienTichMotThanh = Math.PI * (DuongKinhThepNgan * DuongKinhThepNgan) / 4;

                // Chiều rộng có hiệu (m -> mm), trừ 2 lần chiều dày lớp bảo vệ
                double chieuRongHieuLuc = (_mongDon.chieuRongMong * 1000) - (2 * _chongDamThung.ChieuDayLopBaoVe * 1000);

                // Tính số lượng thanh thép
                // Số khoảng = chiều rộng hiệu lực / khoảng cách  
                // Số thanh = số khoảng + 1
                SoLuongThepNgan = Math.Ceiling(chieuRongHieuLuc / KhoangCachThepNgan) + 1;

                // Tính tổng diện tích cốt thép (mm²)
                DienTichThepNgan = SoLuongThepNgan * dienTichMotThanh;
            }
        }

        private void ExecuteTinhToan()
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (_mongDon.chieuDaiMong <= 0 || _mongDon.chieuRongMong <= 0)
                {
                    System.Windows.MessageBox.Show("Vui lòng nhập chiều dài và chiều rộng móng hợp lệ!",
                        "Thông báo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    return;
                }

                if (_chongDamThung.ChieuDayLopBaoVe <= 0)
                {
                    System.Windows.MessageBox.Show("Vui lòng nhập chiều dày lớp bảo vệ hợp lệ!",
                        "Thông báo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    return;
                }

                if (DuongKinhThepDai <= 0 || KhoangCachThepDai <= 0 ||
                    DuongKinhThepNgan <= 0 || KhoangCachThepNgan <= 0)
                {
                    System.Windows.MessageBox.Show("Vui lòng nhập đầy đủ thông số cốt thép!",
                        "Thông báo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    return;
                }

                // Thực hiện tính toán tổng thể
                TinhToanCotThepDai();
                TinhToanCotThepNgan();

                // Kiểm tra điều kiện thỏa mãn
                bool thepDaiDat = DienTichThepDai >= _tinhToanCotThep.FaYeuCauDai;
                bool thepNganDat = DienTichThepNgan >= _tinhToanCotThep.FaYeuCauNgan;

                string thongBao = "=== KẾT QUẢ TÍNH TOÁN CỐT THÉP ===\n\n";

                // Thông tin cốt thép cạnh dài
                thongBao += $"CỐT THÉP PHƯƠNG CẠNH DÀI:\n";
                thongBao += $"- Đường kính: Ø{DuongKinhThepDai}mm\n";
                thongBao += $"- Khoảng cách: {KhoangCachThepDai}mm\n";
                thongBao += $"- Số lượng thanh: {SoLuongThepDai} thanh\n";
                thongBao += $"- Diện tích thực tế: {DienTichThepDai:F2} mm²\n";
                thongBao += $"- Diện tích yêu cầu: {FaYeuCauDai:F2} mm²\n";
                thongBao += $"- Kết quả: {(thepDaiDat ? "ĐẠT" : "KHÔNG ĐẠT")}\n";
                if (!thepDaiDat)
                    thongBao += $"  (Thiếu: {FaYeuCauDai - DienTichThepDai:F2} mm²)\n";

                thongBao += $"\nCỐT THÉP PHƯƠNG CẠNH NGẮN:\n";
                thongBao += $"- Đường kính: Ø{DuongKinhThepNgan}mm\n";
                thongBao += $"- Khoảng cách: {KhoangCachThepNgan}mm\n";
                thongBao += $"- Số lượng thanh: {SoLuongThepNgan} thanh\n";
                thongBao += $"- Diện tích thực tế: {DienTichThepNgan:F2} mm²\n";
                thongBao += $"- Diện tích yêu cầu: {FaYeuCauNgan:F2} mm²\n";
                thongBao += $"- Kết quả: {(thepNganDat ? "ĐẠT" : "KHÔNG ĐẠT")}\n";
                if (!thepNganDat)
                    thongBao += $"  (Thiếu: {FaYeuCauNgan - DienTichThepNgan:F2} mm²)\n";

                thongBao += $"\n=== TỔNG KẾT ===\n";
                if (thepDaiDat && thepNganDat)
                {
                    thongBao += "✓ Cốt thép đã được bố trí THỎA MÃN yêu cầu!";
                }
                else
                {
                    thongBao += "✗ Cốt thép CHƯA THỎA MÃN yêu cầu!";
                }

                System.Windows.MessageBox.Show(thongBao, "Kết quả tính toán cốt thép",
                    System.Windows.MessageBoxButton.OK,
                    thepDaiDat && thepNganDat ? System.Windows.MessageBoxImage.Information : System.Windows.MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Lỗi trong quá trình tính toán: {ex.Message}",
                    "Lỗi", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void ExecuteLuu()
        {
            try
            {
                // Kiểm tra dữ liệu trước khi lưu
                if (DienTichThepDai <= 0 || DienTichThepNgan <= 0)
                {
                    System.Windows.MessageBox.Show("Vui lòng thực hiện tính toán trước khi lưu!",
                        "Thông báo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    return;
                }

                _cotThepBoTri.MongDon = _mongDon;
                _cotThepBoTri.DuLieuDat = _duLieuDat;
                CotThepBoTri.ThongTinBoTri = _cotThepBoTri;

                System.Windows.MessageBox.Show("Đã lưu thông tin cốt thép thành công!", "Thông báo",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Lỗi khi lưu: {ex.Message}",
                    "Lỗi", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    #region RelayCommand Implementation

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }

    #endregion
}
