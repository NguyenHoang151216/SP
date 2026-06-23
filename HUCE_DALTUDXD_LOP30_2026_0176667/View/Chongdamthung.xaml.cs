using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.View
{

    public partial class Chongdamthung : Page
    {
        public Chongdamthung(MongDon mongDon, DuLieuDat duLieuDat)
        {
            InitializeComponent();
            var viewModel = new ChongDamThungViewModel(mongDon, duLieuDat);
            this.DataContext = viewModel;
        }

    }
}
