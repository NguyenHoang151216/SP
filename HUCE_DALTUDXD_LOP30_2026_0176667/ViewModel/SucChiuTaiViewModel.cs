using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using HUCE_DALTUDXD_LOP30_2026_0176667.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel
{
    public class SucChiuTaiViewModel : INotifyPropertyChanged
    {
        private MongDon _mongDon;
        private DuLieuDat _duLieuDat;
        private SucChiuTai _sucChiuTai;

        // Constructor - UPDATED
        public SucChiuTaiViewModel(MongDon mongDon, DuLieuDat duLieuDat)
        {

            _mongDon = mongDon ?? new MongDon();
            _duLieuDat = duLieuDat ?? new DuLieuDat();
            _sucChiuTai = new SucChiuTai();


            _sucChiuTai.MongDon = _mongDon;
            _sucChiuTai.DuLieuDat = _duLieuDat;

            // Khởi tạo Command
            TinhToanCommand = new LenhRelay(TinhToan);

            // Khởi tạo giá trị mặc định chỉ cho SucChiuTai
            InitializeCalculationDefaults();

            // Tự động tra cứu hệ số theo góc ma sát hiện tại
            UpdateCoefficients();
        }

        // UPDATED - Chỉ khởi tạo giá trị cho tính toán, không thay đổi dữ liệu gốc
        private void InitializeCalculationDefaults()
        {
            // Chỉ khởi tạo giá trị mặc định cho SucChiuTai
            if (_sucChiuTai.Fs == 0)
                _sucChiuTai.Fs = 2.5;

            _sucChiuTai.Alpha2 = 1; // Luôn khởi tạo
        }

        // UPDATED - Tách riêng việc cập nhật hệ số
        private void UpdateCoefficients()
        {
            var heso = HeSoTraCuu.LayHeSoTheoGocMaSat(_duLieuDat.GocMaSat);
            _sucChiuTai.Ngamma = heso.Ngamma;
            _sucChiuTai.Nq = heso.Nq;
            _sucChiuTai.Nc = heso.Nc;

        }

        // Properties binding với MongDon - Trực tiếp binding với dữ liệu gốc
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

        // Properties binding với DuLieuDat 
        public double GocMaSat
        {
            get => _duLieuDat.GocMaSat;
            set
            {
                _duLieuDat.GocMaSat = value;
                // Tự động tra cứu hệ số khi góc ma sát thay đổi
                var heso = HeSoTraCuu.LayHeSoTheoGocMaSat(value);
                _sucChiuTai.Ngamma = heso.Ngamma;
                _sucChiuTai.Nq = heso.Nq;
                _sucChiuTai.Nc = heso.Nc;
                OnPropertyChanged(nameof(GocMaSat));
                OnPropertyChanged(nameof(Ngamma));
                OnPropertyChanged(nameof(Nq));
                OnPropertyChanged(nameof(Nc));
            }
        }

        public double LucDinh
        {
            get => _duLieuDat.LucDinh;
            set
            {
                if (_duLieuDat.LucDinh != value)
                {
                    _duLieuDat.LucDinh = value;
                    OnPropertyChanged(nameof(LucDinh));
                }
            }
        }

        public double TrongLuongRieng
        {
            get => _duLieuDat.DungTrong;
            set
            {
                if (_duLieuDat.DungTrong != value)
                {
                    _duLieuDat.DungTrong = value;
                    OnPropertyChanged(nameof(TrongLuongRieng));
                }
            }
        }

        public double ChieuSauDat
        {
            get => _duLieuDat.ChieuDay;
            set
            {
                if (_duLieuDat.ChieuDay != value)
                {
                    _duLieuDat.ChieuDay = value;
                    OnPropertyChanged(nameof(ChieuSauDat));
                }
            }
        }

        // Properties binding với SucChiuTai
        public double Fs
        {
            get => _sucChiuTai.Fs;
            set
            {
                if (_sucChiuTai.Fs != value)
                {
                    _sucChiuTai.Fs = value;
                    OnPropertyChanged(nameof(Fs));
                }
            }
        }

        public double Ngamma
        {
            get => _sucChiuTai.Ngamma;
            set
            {
                if (_sucChiuTai.Ngamma != value)
                {
                    _sucChiuTai.Ngamma = value;
                    OnPropertyChanged(nameof(Ngamma));
                }
            }
        }


        public double Nq
        {
            get => _sucChiuTai.Nq;
            set
            {
                if (_sucChiuTai.Nq != value)
                {
                    _sucChiuTai.Nq = value;
                    OnPropertyChanged(nameof(Nq));
                }
            }
        }

        public double Nc
        {
            get => _sucChiuTai.Nc;
            set
            {
                if (_sucChiuTai.Nc != value)
                {
                    _sucChiuTai.Nc = value;
                    OnPropertyChanged(nameof(Nc));
                }
            }
        }

        public double Ptx
        {
            get => _sucChiuTai.Ptx;
            set
            {
                if (_sucChiuTai.Ptx != value)
                {
                    _sucChiuTai.Ptx = value;
                    OnPropertyChanged(nameof(Ptx));
                }
            }
        }

        public double Pmax
        {
            get => _sucChiuTai.Pmax;
            set
            {
                if (_sucChiuTai.Pmax != value)
                {
                    _sucChiuTai.Pmax = value;
                    OnPropertyChanged(nameof(Pmax));
                }
            }
        }

        public double Pmin
        {
            get => _sucChiuTai.Pmin;
            set
            {
                if (_sucChiuTai.Pmin != value)
                {
                    _sucChiuTai.Pmin = value;
                    OnPropertyChanged(nameof(Pmin));
                }
            }
        }

        public double Rd
        {
            get => _sucChiuTai.Rd;
            set
            {
                if (_sucChiuTai.Rd != value)
                {
                    _sucChiuTai.Rd = value;
                    OnPropertyChanged(nameof(Rd));
                }
            }
        }

        // Properties cho kết quả kiểm tra - Giữ nguyên
        private bool _kiemTra1;
        public bool KiemTra1
        {
            get => _kiemTra1;
            set
            {
                if (_kiemTra1 != value)
                {
                    _kiemTra1 = value;
                    OnPropertyChanged(nameof(KiemTra1));
                    OnPropertyChanged(nameof(NenKetQua));
                }
            }
        }

        private bool _kiemTra2;
        public bool KiemTra2
        {
            get => _kiemTra2;
            set
            {
                if (_kiemTra2 != value)
                {
                    _kiemTra2 = value;
                    OnPropertyChanged(nameof(KiemTra2));
                    OnPropertyChanged(nameof(NenKetQua));
                }
            }
        }

        private string _ketQuaKiemTra;
        public string KetQuaKiemTra
        {
            get => _ketQuaKiemTra;
            set
            {
                if (_ketQuaKiemTra != value)
                {
                    _ketQuaKiemTra = value;
                    OnPropertyChanged(nameof(KetQuaKiemTra));
                }
            }
        }

        public string NenKetQua
        {
            get
            {
                if (KiemTra1 && KiemTra2)
                    return "Green";
                else
                    return "Red";
            }
        }

        // Command - Giữ nguyên
        public ICommand TinhToanCommand { get; }


        private void TinhToan(object parameter = null)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (_mongDon.chieuRongMong <= 0 || _mongDon.chieuDaiMong <= 0 || _mongDon.chieuCaoMong <= 0)
                {
                    KetQuaKiemTra = "Dữ liệu kích thước móng không hợp lệ";
                    return;
                }

                if (_duLieuDat.DungTrong <= 0)
                {
                    KetQuaKiemTra = "Trọng lượng riêng đất phải > 0";
                    return;
                }

                // Tính toán các hệ số    
                _sucChiuTai.Alpha1 = 1 - 0.2 * (_mongDon.chieuRongMong / _mongDon.chieuDaiMong);
                _sucChiuTai.Alpha2 = 1;
                _sucChiuTai.Alpha3 = 1 + 0.2 * (_mongDon.chieuRongMong / _mongDon.chieuDaiMong);

                // Tính Ptx (áp lực trung bình)

                double gamma_trungbinh = 2; // T/m³
                Ptx = (_mongDon.N / (_mongDon.chieuRongMong * _mongDon.chieuDaiMong)) +
                      (gamma_trungbinh * _mongDon.chieuSauChonMong);

                // Tính Rd (sức chịu tải thiết kế)

                Rd = (1.0 / _sucChiuTai.Fs) * (
                    0.5 * _sucChiuTai.Alpha1 * _duLieuDat.DungTrong / 10 * _mongDon.chieuRongMong * _sucChiuTai.Ngamma +
                    _sucChiuTai.Alpha2 * _duLieuDat.DungTrong / 10 * _mongDon.chieuSauChonMong * _sucChiuTai.Nq +
                    _sucChiuTai.Alpha3 * _duLieuDat.LucDinh * _sucChiuTai.Nc
                );

                // Tính Pmax và Pmin (áp lực lớn nhất và nhỏ nhất)
                // Pmax = Ptx + 6*M/(B*L²)
                // Pmin = Ptx - 6*M/(B*L²)
                double momentTerm = (6 * _mongDon.Momen) / (_mongDon.chieuRongMong * _mongDon.chieuDaiMong * _mongDon.chieuDaiMong);
                Pmax = Ptx + momentTerm;
                Pmin = Ptx - momentTerm;

                // Kiểm tra điều kiện
                // Điều kiện 1: Ptx ≤ Rd
                KiemTra1 = Ptx <= Rd;

                // Điều kiện 2: Pmax ≤ 1.2 * Rd
                KiemTra2 = Pmax <= 1.2 * Rd;

                // Kết quả kiểm tra
                KetQuaKiemTra = (KiemTra1 && KiemTra2) ?
                    "Nền đất đủ sức chịu tải" :
                    "Nền đất không đủ sức chịu tải";

                SucChiuTai.ThongTinSucChiuTai = _sucChiuTai;

                // Thông báo kết quả chi tiết - Đã có OnPropertyChanged trong setter
            }
            catch (Exception ex)
            {
                KetQuaKiemTra = $"Lỗi tính toán: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
