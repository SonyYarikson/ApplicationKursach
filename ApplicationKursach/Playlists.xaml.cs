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

namespace ApplicationKursach
{
    /// <summary>
    /// Логика взаимодействия для Playlists.xaml
    /// </summary>
    public partial class Playlists : Page
    {
        public Playlists()
        {
            InitializeComponent();
            LVPlaylists.ItemsSource = new KURSACHEntities().PlaylistDataGrid.ToList();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            PlaylistDataGrid playlist = (sender as Button).DataContext as PlaylistDataGrid;
            PlaylistDescription._content = playlist;
            Playlist.Navigate(new PlaylistDescription());
        }
    }
}
