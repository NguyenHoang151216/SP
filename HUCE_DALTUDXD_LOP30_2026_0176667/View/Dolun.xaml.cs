using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel;
using System.Windows.Controls;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.View
{
    /// <summary>
    /// Interaction logic for Dolun.xaml
    /// </summary>
    public partial class Dolun : Page
    {
        public Dolun(MongDon mongDon, DuLieuDat duLieuDat)
        {
            InitializeComponent();
            DataContext = new DoLunViewModel(mongDon, duLieuDat);
        }
    }
}
