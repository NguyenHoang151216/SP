using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using HUCE_DALTUDXD_LOP30_2026_0176667.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HUCE_DALTUDXD_LOP30_2026_0176667.View;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel
{
    public class ChongDamThungViewModel : INotifyPropertyChanged
    {
        private MongDon _mongDon;
        private DuLieuDat _duLieuDat;
        private ChongDamThung _chongDamThung;

        // Constructor
        public ChongDamThungViewModel(MongDon mongDon, DuLieuDat duLieuDat)
        {
            _mongDon = mongDon ?? new MongDon();
            _duLieuDat = duLieuDat ?? new DuLieuDat();
            _chongDamThung = ChongDamThung.ThongTinCdt ?? new ChongDamThung();

            _chongDamThung.MongDon = _mongDon;
            _chongDamThung.DuLieuDat = _duLieuDat;
            CheckResult = _chongDamThung.CheckResult;

            // Khởi tạo Command
            CalculateCommand = new LenhRelay(Calculate);
            SaveResultCommand = new LenhRelay(SaveResult);
        }

        // Properties cho thông số đầu vào
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

        public float ChieuDaiCot
        {
            get => _mongDon.chieuDaiCot;
            set
            {
                if (_mongDon.chieuDaiCot != value)
                {
                    _mongDon.chieuDaiCot = value;
                    OnPropertyChanged(nameof(ChieuDaiCot));
                }
            }
        }

        public float ChieuRongCot
        {
            get => _mongDon.chieuRongCot;
            set
            {
                if (_mongDon.chieuRongCot != value)
                {
                    _mongDon.chieuRongCot = value;
                    OnPropertyChanged(nameof(ChieuRongCot));
                }
            }
        }

        public float h0
        {
            get => _chongDamThung.h0;
            set
            {
                if (_chongDamThung.h0 != value)
                {
                    _chongDamThung.h0 = value;
                    OnPropertyChanged(nameof(h0));
                }
            }
        }

        public float CuongDoBeTong
        {
            get => _mongDon.cuongDoBeTong;
            set
            {
                if (_mongDon.cuongDoBeTong != value)
                {
                    _mongDon.cuongDoBeTong = value;
                    OnPropertyChanged(nameof(CuongDoBeTong));
                }
            }
        }

        // Properties cho kết quả tính toán
        public double Pomax
        {
            get => _chongDamThung.Pomax;
            set
            {
                if (_chongDamThung.Pomax != value)
                {
                    _chongDamThung.Pomax = value;
                    OnPropertyChanged(nameof(Pomax));
                }
            }
        }

        public double Po
        {
            get => _chongDamThung.Po;
            set
            {
                if (_chongDamThung.Po != value)
                {
                    _chongDamThung.Po = value;
                    OnPropertyChanged(nameof(Po));
                }
            }
        }

        public double Pot
        {
            get => _chongDamThung.Pot;
            set
            {
                if (_chongDamThung.Pot != value)
                {
                    _chongDamThung.Pot = value;
                    OnPropertyChanged(nameof(Pot));
                }
            }
        }

        public double Pomin
        {
            get => _chongDamThung.Pomin;
            set
            {
                if (_chongDamThung.Pomin != value)
                {
                    _chongDamThung.Pomin = value;
                    OnPropertyChanged(nameof(Pomin));
                }
            }
        }

        public double Pdt
        {
            get => _chongDamThung.Pdt;
            set
            {
                if (_chongDamThung.Pdt != value)
                {
                    _chongDamThung.Pdt = value;
                    OnPropertyChanged(nameof(Pdt));
                }
            }
        }

        public double Pcdt
        {
            get => _chongDamThung.Pcdt;
            set
            {
                if (_chongDamThung.Pcdt != value)
                {
                    _chongDamThung.Pcdt = value;
                    OnPropertyChanged(nameof(Pcdt));
                }
            }
        }

        // Properties từ MongDon (có thể cần thiết cho tính toán)
        public float N
        {
            get => _mongDon.N;
            set
            {
                if (_mongDon.N != value)
                {
                    _mongDon.N = value;
                    OnPropertyChanged(nameof(N));
                }
            }
        }

        public float Momen
        {
            get => _mongDon.Momen;
            set
            {
                if (_mongDon.Momen != value)
                {
                    _mongDon.Momen = value;
                    OnPropertyChanged(nameof(Momen));
                }
            }
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

        // Kết quả kiểm tra
        private string _checkResult;
        public string CheckResult
        {
            get => _checkResult;
            set
            {
                if (_checkResult != value)
                {
                    _checkResult = value;
                    OnPropertyChanged(nameof(CheckResult));
                }
            }
        }

        // Trạng thái lưu
        private string _saveStatus;
        public string SaveStatus
        {
            get => _saveStatus;
            set
            {
                if (_saveStatus != value)
                {
                    _saveStatus = value;
                    OnPropertyChanged(nameof(SaveStatus));
                }
            }
        }

        // Commands
        public ICommand CalculateCommand { get; }
        public ICommand SaveResultCommand { get; }


        private void Calculate(object parameter = null)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (!ValidateInput())
                    return;


                CalculatePressures();
                CalculatePunchingShear();


                CheckPunchingShear();
            }
            catch (Exception ex)
            {
                CheckResult = $"Lỗi tính toán: {ex.Message}";
            }
        }



        private bool ValidateInput()
        {
            if (_mongDon.chieuRongMong <= 0 || _mongDon.chieuDaiMong <= 0)
            {
                CheckResult = "Kích thước móng không hợp lệ";
                return false;
            }

            if (ChieuRongCot <= 0 || ChieuDaiCot <= 0)
            {
                CheckResult = "Kích thước cột không hợp lệ";
                return false;
            }
            h0 = _mongDon.chieuCaoMong - _chongDamThung.ChieuDayLopBaoVe;
            if (h0 <= 0)
            {
                CheckResult = "Chiều cao làm việc h0 phải > 0";
                return false;
            }

            return true;
        }

        private void CalculatePressures()
        {

            // Tính áp lực trung bình (giống như trong SucChiuTaiViewModel)

            h0 = _mongDon.chieuCaoMong - _chongDamThung.ChieuDayLopBaoVe;
            double gamma_trungbinh = 2; // T/m³
            Po = (_mongDon.N / (_mongDon.chieuRongMong * _mongDon.chieuDaiMong)) +
                        (gamma_trungbinh * _mongDon.chieuSauChonMong);

            // Tính Pomax và Pomin
            double momentTerm = (6 * _mongDon.Momen) /
                               (_mongDon.chieuRongMong * _mongDon.chieuDaiMong * _mongDon.chieuDaiMong);

            Pomax = _chongDamThung.Po + momentTerm;
            Pomin = _chongDamThung.Po - momentTerm;
        }

        private void CalculatePunchingShear()
        {

            _chongDamThung.Ldt = ((_mongDon.chieuDaiMong - _mongDon.chieuDaiCot) / 2) - _chongDamThung.h0;

            Pot = _chongDamThung.Pomin + (_chongDamThung.Pomax - _chongDamThung.Pomin) * ((_mongDon.chieuDaiMong - _chongDamThung.Ldt) / _mongDon.chieuDaiMong);

            // Tính áp lực đâm thủng Pđt
            Pdt = (_chongDamThung.Pomax + _chongDamThung.Pot) / 2 * _chongDamThung.Ldt * _mongDon.chieuRongMong;

            // Tính lực chống đâm thủng Pcđt
            Pcdt = _mongDon.cuongDoBeTong * 1000 * _chongDamThung.h0 * (_mongDon.chieuRongCot + _chongDamThung.h0);
        }

        private void CheckPunchingShear()
        {
            if (Pdt <= Pcdt)
            {
                CheckResult = $"Móng đủ khả năng chống đâm thủng\n" +
                             $"Pđt = {Pdt:F2} T ≤ Pcđt = {Pcdt:F2} T\n";

            }
            else
            {
                CheckResult = $"Móng không đủ khả năng chống đâm thủng\n" +
                             $"Pđt = {Pdt:F2} T > Pcđt = {Pcdt:F2} T\n" +
                             $"Cần tăng chiều dày móng hoặc cường độ bê tông";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void SaveResult(object parameter = null)
        {
            try
            {
                // Kiểm tra xem đã có kết quả tính toán chưa
                if (string.IsNullOrEmpty(CheckResult) || CheckResult.Contains("Lỗi"))
                {
                    SaveStatus = "Vui lòng tính toán trước khi lưu kết quả!";
                    return;
                }

                // Lưu kết quả vào static property để có thể truy cập từ nơi khác
                ChongDamThung.ThongTinCdt = new ChongDamThung
                {

                    ChieuDayLopBaoVe = _chongDamThung.ChieuDayLopBaoVe,
                    h0 = _chongDamThung.h0,

                    Pomax = _chongDamThung.Pomax,
                    Pomin = _chongDamThung.Pomin,
                    Po = _chongDamThung.Po,
                    Pot = _chongDamThung.Pot,
                    Pdt = _chongDamThung.Pdt,
                    Pcdt = _chongDamThung.Pcdt,
                    Ldt = _chongDamThung.Ldt,
                    CheckResult = CheckResult,
                    MongDon = _mongDon,
                    DuLieuDat = _duLieuDat
                };

                SaveStatus = $"Kết quả đã được lưu thành công vào lúc {DateTime.Now:HH:mm:ss dd/MM/yyyy}";

                // Tự động xóa thông báo sau 3 giây
                Task.Delay(3000).ContinueWith(_ => SaveStatus = string.Empty);
            }
            catch (Exception ex)
            {
                SaveStatus = $"Lỗi khi lưu kết quả: {ex.Message}";
            }
        }

    }
}
