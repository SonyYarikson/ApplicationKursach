using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для PlaylistDescription.xaml
    /// </summary>
    public partial class PlaylistDescription : Page
    {
        public static PlaylistDataGrid _content;
        private static MediaPlayer _player = new MediaPlayer();
        public PlaylistDescription()
        {
            InitializeComponent();
            DataContext = _content;
            MusicInPlaylist.ItemsSource = new KURSACHEntities().SongsInPlaylistsDataGrid.ToList().Where(x => x.Name == _content.Name);
        }

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender as Button != null)
            {
                SongsInPlaylistsDataGrid song = (sender as Button).DataContext as SongsInPlaylistsDataGrid;
                var file = song.song_file;
                string path = System.IO.Directory.GetCurrentDirectory().Remove(System.IO.Directory.GetCurrentDirectory().Length - 10, 10) + @"\media";
                FileInfo finfo = new FileInfo(path + @"\" + DataGridGetData.GetCell(MusicInPlaylist, DataGridGetData.GetSelectedRow(MusicInPlaylist), 3).ToString().Remove(0, 38) + ".mp3");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                if (!File.Exists(path + @"\" + DataGridGetData.GetCell(MusicInPlaylist, DataGridGetData.GetSelectedRow(MusicInPlaylist), 3).ToString().Remove(0, 38) + ".mp3"))
                File.WriteAllBytes(path + @"\" + DataGridGetData.GetCell(MusicInPlaylist, DataGridGetData.GetSelectedRow(MusicInPlaylist), 3).ToString().Remove(0, 38) + ".mp3", file);
                if (!FileChecker.IsFileLocked(finfo))
                {
                    _player.Open(new Uri(path + @"\" + DataGridGetData.GetCell(MusicInPlaylist, DataGridGetData.GetSelectedRow(MusicInPlaylist), 3).ToString().Remove(0, 38) + ".mp3", UriKind.RelativeOrAbsolute));
                    _player.Play();
                    _player.MediaEnded += new EventHandler(myMediaElement_MediaEnded);
                }
            }
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            _player.Stop();
        }
        private void myMediaElement_MediaEnded(object sender, EventArgs e)
        {
            if (_player.Position == _player.NaturalDuration) // проверка, достиг ли плеер конца
            {
                _player.Close();
                SongsInPlaylistsDataGrid song = (sender as Button).DataContext as SongsInPlaylistsDataGrid;
                var file = song.song_file;
                string folderName = "media";
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, folderName);
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                File.WriteAllBytes(path + @"\" + DataGridGetData.GetCell(MusicInPlaylist, DataGridGetData.GetSelectedRow(MusicInPlaylist), 3).ToString().Remove(0, 38) + ".mp3", file);
                _player.Open(new Uri(path + @"\" + DataGridGetData.GetCell(MusicInPlaylist, DataGridGetData.GetSelectedRow(MusicInPlaylist), 3).ToString().Remove(0, 38) + ".mp3", UriKind.RelativeOrAbsolute));
                _player.Play();
            }
        }
        public static MediaState GetMediaState(MediaPlayer myMedia)
        {
            FieldInfo stateField = myMedia.GetType().GetField("_mediaPlayerState", BindingFlags.NonPublic | BindingFlags.Instance);
            MediaState state = (MediaState)stateField.GetValue(myMedia);
            return state;
        }
    }
}
