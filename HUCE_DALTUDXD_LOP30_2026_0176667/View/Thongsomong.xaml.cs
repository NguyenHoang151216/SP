using HUCE_DALTUDXD_LOP30_2026_0176667.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.View
{
    /// <summary>
    /// Interaction logic for Thongsomong.xaml
    /// </summary>
    public partial class Thongsomong : Page
    {
        public Thongsomong()
        {
            InitializeComponent();
            DataContext = new ThongSoMongViewModel();
        }

        private void Thongsodat_Click(object sender, RoutedEventArgs e)
        {
            ThongsomongPage.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new Thongsodat());
            ClearNavigationHistory();
        }

        private void ClearNavigationHistory()
        {
            while (MainFrame.CanGoBack)
            {
                MainFrame.RemoveBackEntry();
            }
        }
    }
}
