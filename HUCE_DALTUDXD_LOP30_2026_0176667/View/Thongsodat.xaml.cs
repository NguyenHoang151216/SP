using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.View
{
    /// <summary>
    /// Interaction logic for Thongsodat.xaml
    /// </summary>
    public partial class Thongsodat : Page
    {
        public Thongsodat()
        {
            InitializeComponent();
            this.DataContext = new ThongSoDatViewModel();
        }
        private void Thongsomong_Click(object sender, RoutedEventArgs e)
        {
            ThongsodatPage.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new Thongsomong());
            ClearNavigationHistory();
        }
        private void ClearNavigationHistory()
        {
            while (MainFrame.CanGoBack)
            {
                MainFrame.RemoveBackEntry();
            }
        }

        private void Luusolieu2_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ThongSoDatViewModel;
            if (viewModel == null) return;

            if (viewModel.DuLieuDuocChon == null && viewModel.DanhSachDat.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập thông số đất trước khi lưu.", "Thông báo");
                return;
            }

            var duLieuDat = viewModel.DuLieuDuocChon ?? viewModel.DanhSachDat[0];
            var mongDon = duLieuDat.LayMongDangTinhToan();
            DuLieuDat.DatDangChon = duLieuDat;

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.DanhSachDat = DuLieuDat.ThongTinDat;
                mainWindow.SolieuData = mongDon;
                mainWindow.ChonDuLieuTinhToan(mongDon, duLieuDat);
            }

            MongDon.MongDangChon = mongDon;
            MongDon.ThongTinMong = mongDon;
            MessageBox.Show("Dữ liệu đất đã được lưu!", "Thông báo");
        }
    }
}
