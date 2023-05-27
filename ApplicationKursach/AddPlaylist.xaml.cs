using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace ApplicationKursach
{
    /// <summary>
    /// Логика взаимодействия для AddPlaylist.xaml
    /// </summary>
    public partial class AddPlaylist : Page
    {
        public static Playlist_description playlists = new Playlist_description();
        public AddPlaylist()
        {
            InitializeComponent();
        }

        private void PlaylistPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ваше Изображение|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(imagePath);

                playlists.Cover = imageData;
            }
            PlaylistPhoto.Visibility = Visibility.Hidden;
        }

        private void SavePlaylist_click(object sender, RoutedEventArgs e)
        {
            playlists.Name = PlaylistName.Text;
            KURSACHEntities.GetContext().Playlist_description.Add(playlists);
            KURSACHEntities.GetContext().SaveChanges();
            SavePlay.Navigate(new AddMusicInPlaylist());
        }

    }
}
