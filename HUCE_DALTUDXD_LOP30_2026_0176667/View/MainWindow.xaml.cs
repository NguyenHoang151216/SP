using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using HUCE_DALTUDXD_LOP30_2026_0176667.Model;
using HUCE_DALTUDXD_LOP30_2026_0176667.View;

namespace HUCE_DALTUDXD_LOP30_2026_0176667
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatSelector.ItemsSource = DuLieuDat.ThongTinDat;
            CapNhatDanhSachMongDangChon(DuLieuDat.LayDatDangChon());
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            anhnen.Visibility = Visibility.Visible;
            tieude.Visibility = Visibility.Visible;
            login.Visibility = Visibility.Visible;
            MainFrame.Content = null;
            ClearNavigationHistory();
        }
        private void Nhapsolieu_Click(object sender, RoutedEventArgs e)
        {
            anhnen.Visibility = Visibility.Collapsed;
            tieude.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new Thongsomong());
            ClearNavigationHistory();
        }


        private void SucchiutaiButton_Click(object sender, RoutedEventArgs e)
        {
            anhnen.Visibility = Visibility.Collapsed;
            tieude.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Collapsed;
            var mongDon = LayMongDangTinh();
            var duLieuDat = LayLopDatTinhToan(mongDon);
            MainFrame.Navigate(new Succhiutai(mongDon, duLieuDat));
            ClearNavigationHistory();
        }


        private void DolunButton_Click(object sender, RoutedEventArgs e)
        {
            anhnen.Visibility = Visibility.Collapsed;
            tieude.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Collapsed;
            var mongDon = LayMongDangTinh();
            var duLieuDat = LayLopDatTinhToan(mongDon);
            MainFrame.Navigate(new Dolun(mongDon, duLieuDat));
            ClearNavigationHistory();
        }


        private void ChongdamthungButton_Click(object sender, RoutedEventArgs e)
        {
            anhnen.Visibility = Visibility.Collapsed;
            tieude.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Collapsed;
            var mongDon = LayMongDangTinh();
            var duLieuDat = LayLopDatTinhToan(mongDon);
            MainFrame.Navigate(new Chongdamthung(mongDon, duLieuDat));
            ClearNavigationHistory();
        }

        private void TinhtoanButton_Click(object sender, RoutedEventArgs e)
        {
            anhnen.Visibility = Visibility.Collapsed;
            tieude.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Collapsed;
            var mongDon = LayMongDangTinh();
            var duLieuDat = LayLopDatTinhToan(mongDon);
            var chongDamThung = ChongDamThung.ThongTinCdt;
            MainFrame.Navigate(new Tinhtoancotthep(mongDon, duLieuDat, chongDamThung));
            ClearNavigationHistory();
        }


        private void BotriButton_Click(object sender, RoutedEventArgs e)
        {
            anhnen.Visibility = Visibility.Collapsed;
            tieude.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Collapsed;

            var mongDon = LayMongDangTinh();
            var duLieuDat = LayLopDatTinhToan(mongDon);
            var tinhToanCotThep = TinhToanCotThep.ThongTinCt;
            var chongDamThung = ChongDamThung.ThongTinCdt;
            MainFrame.Navigate(new Botricotthep(mongDon, duLieuDat, tinhToanCotThep, chongDamThung));
            ClearNavigationHistory();
        }

        private void CheckMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CheckPopup.IsOpen = !CheckPopup.IsOpen;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MongSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MongSelector.SelectedItem is MongDon mongDon)
            {
                MongDon.MongDangChon = mongDon;
                MongDon.ThongTinMong = mongDon;
                var duLieuDat = mongDon.LayLopDatTinhToan();
                if (duLieuDat != null)
                {
                    DuLieuDat.DatDangChon = duLieuDat;
                    duLieuDat.MongDangTinhToan = mongDon;
                    if (DatSelector.SelectedItem != duLieuDat)
                        DatSelector.SelectedItem = duLieuDat;
                }

                SolieuData = mongDon;
                DanhSachDat = DuLieuDat.ThongTinDat;
            }
        }

        private void DatSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatSelector.SelectedItem is DuLieuDat duLieuDat)
            {
                DuLieuDat.DatDangChon = duLieuDat;
                CapNhatDanhSachMongDangChon(duLieuDat);
            }
        }

        public void ChonDuLieuTinhToan(MongDon mongDon, DuLieuDat duLieuDat = null)
        {
            duLieuDat ??= mongDon?.LayLopDatTinhToan() ?? DuLieuDat.LayDatDangChon();
            if (duLieuDat != null)
                DuLieuDat.DatDangChon = duLieuDat;

            if (mongDon == null)
            {
                DatSelector.SelectedItem = duLieuDat;
                CapNhatDanhSachMongDangChon(duLieuDat);
                return;
            }

            MongDon.MongDangChon = mongDon;
            MongDon.ThongTinMong = mongDon;
            mongDon.LopDat = duLieuDat;
            if (duLieuDat != null)
                duLieuDat.MongDangTinhToan = mongDon;

            SolieuData = mongDon;
            DanhSachDat = DuLieuDat.ThongTinDat;

            DatSelector.SelectedItem = duLieuDat;
            CapNhatDanhSachMongDangChon(duLieuDat);
            MongSelector.SelectedItem = mongDon;
        }

        private void CapNhatDanhSachMongDangChon(DuLieuDat duLieuDat)
        {
            MongSelector.ItemsSource = duLieuDat?.DanhSachMong;
            var mongDangTinhToan = duLieuDat?.LayMongDangTinhToan();

            if (duLieuDat != null && mongDangTinhToan != null)
                duLieuDat.MongDangTinhToan = mongDangTinhToan;

            MongSelector.SelectedItem = mongDangTinhToan;
        }

        private void ClearNavigationHistory()
        {
            while (MainFrame.CanGoBack)
            {
                MainFrame.RemoveBackEntry();
            }
        }

        private MongDon LayMongDangTinh()
        {
            var mongDon = MongDon.LayMongDangChon();
            if (mongDon == null)
            {
                MessageBox.Show("Vui lòng nhập và chọn thông số móng trước khi tính toán.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                mongDon = new MongDon();
            }

            return mongDon;
        }

        private DuLieuDat LayLopDatTinhToan(MongDon mongDon)
        {
            var duLieuDat = mongDon?.LayLopDatTinhToan();
            duLieuDat ??= DuLieuDat.LayDatDangChon();

            if (duLieuDat == null)
            {
                MessageBox.Show("Vui lòng nhập và chọn thông số đất trước khi tính toán.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                duLieuDat = new DuLieuDat();
            }

            return duLieuDat;
        }

        public MongDon SolieuData { get; set; }
        public ObservableCollection<DuLieuDat> DanhSachDat { get; set; }
        public MainWindow(ObservableCollection<DuLieuDat> danhSachDat, MongDon solieuData)
        {
            DanhSachDat = danhSachDat;
            SolieuData = solieuData;
        }
        private void RunCalculationButton_Click(object sender, RoutedEventArgs e)
        {
            SolieuData = LayMongDangTinh();
            DanhSachDat = DuLieuDat.ThongTinDat;
            var viewModel = new MainWindow(DanhSachDat, SolieuData);


            var solieuWindow = new SolieuWindow
            {
                DataContext = viewModel
            };

            solieuWindow.Show();
        }
    }

}
