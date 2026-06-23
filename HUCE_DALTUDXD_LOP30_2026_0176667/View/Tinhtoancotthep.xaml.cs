using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel;
using System.Windows.Controls;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.View
{
    /// <summary>
    /// Interaction logic for Tinhtoancotthep.xaml
    /// </summary>
    public partial class Tinhtoancotthep : Page
    {
        public Tinhtoancotthep(MongDon mongDon, DuLieuDat duLieuDat, ChongDamThung chongDamThung)
        {
            InitializeComponent();
            DataContext = new TinhToanCotThepViewModel(mongDon, duLieuDat, chongDamThung);
        }
    }
}
