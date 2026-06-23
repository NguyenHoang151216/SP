using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using HUCE_DALTUDXD_LOP30_2026_0176667.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel
{
    public class DoLunViewModel : INotifyPropertyChanged
    {
        private readonly MongDon _mongDon;
        private readonly DuLieuDat _duLieuDat;
        private double _ptx;
        private double? _pgl;

        public DoLunViewModel(MongDon mongDon, DuLieuDat duLieuDat)
        {
            _mongDon = mongDon ?? new MongDon();
            _duLieuDat = duLieuDat ?? new DuLieuDat();
            CapNhatGiaTri();
            TinhToanDoLun = new LenhRelay(TinhPgl);
        }

        public double DungTrongRieng => _duLieuDat.DungTrong;

        public double ChieuSauChonMong => _mongDon.chieuSauChonMong;

        public double Ptx
        {
            get => _ptx;
            private set
            {
                if (_ptx != value)
                {
                    _ptx = value;
                    OnPropertyChanged(nameof(Ptx));
                }
            }
        }

        public double? Pgl
        {
            get => _pgl;
            private set
            {
                if (_pgl != value)
                {
                    _pgl = value;
                    OnPropertyChanged(nameof(Pgl));
                }
            }
        }

        public ICommand TinhToanDoLun { get; }

        private void CapNhatGiaTri()
        {
            Ptx = LayPtxTuSucChiuTai();
            Pgl = null;
        }

        private void TinhPgl(object parameter)
        {
            Pgl = Ptx - (DungTrongRieng * ChieuSauChonMong);
        }

        private double LayPtxTuSucChiuTai()
        {
            var sucChiuTai = SucChiuTai.ThongTinSucChiuTai;
            if (sucChiuTai?.Ptx > 0
                && ReferenceEquals(sucChiuTai.MongDon, _mongDon)
                && ReferenceEquals(sucChiuTai.DuLieuDat, _duLieuDat))
            {
                return sucChiuTai.Ptx;
            }

            if (_mongDon.chieuRongMong <= 0 || _mongDon.chieuDaiMong <= 0)
                return 0;

            const double gammaTrungBinh = 2;
            return (_mongDon.N / (_mongDon.chieuRongMong * _mongDon.chieuDaiMong))
                   + (gammaTrungBinh * _mongDon.chieuSauChonMong);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
