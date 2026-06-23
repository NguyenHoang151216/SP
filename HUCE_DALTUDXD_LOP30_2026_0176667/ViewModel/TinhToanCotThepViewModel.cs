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
    public class TinhToanCotThepViewModel : INotifyPropertyChanged
    {
        private MongDon _mongDon;
        private DuLieuDat _duLieuDat;

        private TinhToanCotThep _tinhToanCotThep;
        private ChongDamThung _chongDamThung;

        // Constructor
        public TinhToanCotThepViewModel(MongDon mongDon, DuLieuDat duLieuDat, ChongDamThung chongDamThung)
        {
            _mongDon = mongDon ?? new MongDon();
            _duLieuDat = duLieuDat ?? new DuLieuDat();

            _chongDamThung = chongDamThung ?? new ChongDamThung();
            _tinhToanCotThep = TinhToanCotThep.ThongTinCt ?? new TinhToanCotThep();

            // Liên kết các model
            _tinhToanCotThep.MongDon = _mongDon;
            _tinhToanCotThep.DuLieuDat = _duLieuDat;


            // Khởi tạo Command
            TinhToanCommand = new LenhRelay(TinhToan);
            LuuCommand = new LenhRelay(Luu);

            // Khởi tạo giá trị mặc định
            if (TinhToanCotThep.ThongTinCt != null)
            {
                KetQuaTinhToan = "Đã nạp kết quả tính toán đã lưu";
            }

        }




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




        public float CuongDoThep
        {
            get => _mongDon.cuongDoThep;
            set
            {
                if (_mongDon.cuongDoThep != value)
                {
                    _mongDon.cuongDoThep = value;
                    OnPropertyChanged(nameof(CuongDoThep));
                }
            }
        }




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
        // Properties binding với dữ liệu đầu vào



        public double Pong
        {
            get => _tinhToanCotThep.Pong;
            set
            {
                if (_tinhToanCotThep.Pong != value)
                {
                    _tinhToanCotThep.Pong = value;
                    OnPropertyChanged(nameof(Pong));
                }
            }
        }

        public double Bng
        {
            get => _tinhToanCotThep.Bng;
            set
            {
                if (_tinhToanCotThep.Bng != value)
                {
                    _tinhToanCotThep.Bng = value;
                    OnPropertyChanged(nameof(Bng));
                }
            }
        }

        public double Lng
        {
            get => _tinhToanCotThep.Lng;
            set
            {
                if (_tinhToanCotThep.Lng != value)
                {
                    _tinhToanCotThep.Lng = value;
                    OnPropertyChanged(nameof(Lng));
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

        // Properties cho kết quả tính toán theo phương dài
        public double Mlng
        {
            get => _tinhToanCotThep.Mlng;
            set
            {
                if (_tinhToanCotThep.Mlng != value)
                {
                    _tinhToanCotThep.Mlng = value;
                    OnPropertyChanged(nameof(Mlng));
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

        // Properties cho kết quả tính toán theo phương ngắn
        public double Mbng
        {
            get => _tinhToanCotThep.Mbng;
            set
            {
                if (_tinhToanCotThep.Mbng != value)
                {
                    _tinhToanCotThep.Mbng = value;
                    OnPropertyChanged(nameof(Mbng));
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

        // Properties cho các giá trị trung gian (chỉ đọc)






        // Commands
        public ICommand TinhToanCommand { get; }
        public ICommand LuuCommand { get; }

        // Kết quả kiểm tra
        private string _ketQuaTinhToan;
        public string KetQuaTinhToan
        {
            get => _ketQuaTinhToan;
            set
            {
                if (_ketQuaTinhToan != value)
                {
                    _ketQuaTinhToan = value;
                    OnPropertyChanged(nameof(KetQuaTinhToan));
                }
            }
        }

        // Phương thức tính toán chính
        private void TinhToan(object parameter = null)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào




                if (_mongDon.cuongDoThep <= 0)
                {
                    KetQuaTinhToan = "Thông số vật liệu không hợp lệ";
                    return;
                }

                // Tính toán theo phương cạnh dài
                TinhToanTheoPhuongDai();

                // Tính toán theo phương cạnh ngắn
                TinhToanTheoPhuongNgan();

                KetQuaTinhToan = "Tính toán hoàn thành";
            }
            catch (Exception ex)
            {
                KetQuaTinhToan = $"Lỗi tính toán: {ex.Message}";
            }
        }

        private void TinhToanTheoPhuongDai()
        {


            Lng = _mongDon.chieuDaiMong - ((_mongDon.chieuDaiMong - _mongDon.chieuDaiCot) / 2);

            Pong = _chongDamThung.Pomin + (_chongDamThung.Pomax - _chongDamThung.Pomin) * ((_mongDon.chieuDaiMong - Lng) / _mongDon.chieuDaiMong);



            Mlng = (Pong + _chongDamThung.Pomax) / 2 * ((Lng * Lng) / 2) * _mongDon.chieuRongMong;



            FaYeuCauDai = Mlng * 1000000 / ((0.9 * _mongDon.cuongDoThep * _chongDamThung.h0 * 1000));
        }

        private void TinhToanTheoPhuongNgan()
        {


            Bng = ((_mongDon.chieuRongMong - _mongDon.chieuRongCot) / 2);


            Mbng = _chongDamThung.Po + ((Bng * Bng) / 2) * _mongDon.chieuDaiMong;



            FaYeuCauNgan = Mbng * 1000000 / ((0.9 * _mongDon.cuongDoThep * _chongDamThung.h0 * 1000));


        }

        private void Luu(object parameter = null)
        {
            try
            {
                if (Mlng <= 0 || Mbng <= 0 || FaYeuCauDai <= 0 || FaYeuCauNgan <= 0)
                {
                    KetQuaTinhToan = "Vui lòng tính toán trước khi lưu";
                    return;
                }

                _tinhToanCotThep.MongDon = _mongDon;
                _tinhToanCotThep.DuLieuDat = _duLieuDat;
                TinhToanCotThep.ThongTinCt = _tinhToanCotThep;
                KetQuaTinhToan = "Đã lưu kết quả tính toán";
            }
            catch (Exception ex)
            {
                KetQuaTinhToan = $"Lỗi lưu: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
