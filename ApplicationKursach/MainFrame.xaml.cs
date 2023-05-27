using System.Windows;
using System.Windows.Controls;

namespace ApplicationKursach
{
    /// <summary>
    /// Логика взаимодействия для MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {
        public MainFrame()
        {
            InitializeComponent();
            Music.Navigate(new Music());
            if (Authorize.registration.Role == "User")
            {
                Add_Button.Visibility = Visibility.Hidden;
            }
            CurrentUser.DataContext = Authorize.registration;
        }

        private void Playlist_Button_Click(object sender, RoutedEventArgs e)
        {
            Music.Navigate(new Playlists());
            Manager.Music = Music;
        }

        private void Albums_Button_Click(object sender, RoutedEventArgs e)
        {
            Music.Navigate(new Album());
        }

        private void Music_Button_Click(object sender, RoutedEventArgs e)
        {
            Music.Navigate(new Music());
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Music.Navigate(new AddMusicPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Authorize.registration = null;
            MainFrameAll.Navigate(new Authorize());
        }

        private void AddPlaylist_Click(object sender, RoutedEventArgs e)
        {
            Music.Navigate(new AddPlaylist());
        }
    }
}
