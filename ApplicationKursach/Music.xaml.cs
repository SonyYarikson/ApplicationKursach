using System;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Navigation;

namespace ApplicationKursach
{
    /// <summary>
    /// Логика взаимодействия для Music.xaml
    /// </summary>
    public partial class Music : Page
    {
        private static MediaPlayer _player = new MediaPlayer();
        public Music()
        {
            InitializeComponent();
            //MusicGrid.ItemsSource = new KURSACHEntities().SongsDataGrid.ToList();
        }
        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {

            SongsDataGrid song = (sender as Button).DataContext as SongsDataGrid;
            var file = song.song_file;
            string path = System.IO.Directory.GetCurrentDirectory().Remove(System.IO.Directory.GetCurrentDirectory().Length - 10, 10) + @"\media";
            FileInfo finfo = new FileInfo(path + @"\" + DataGridGetData.GetCell(MusicGrid, DataGridGetData.GetSelectedRow(MusicGrid), 3).ToString().Remove(0, 38) + ".mp3");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + @"\" + DataGridGetData.GetCell(MusicGrid, DataGridGetData.GetSelectedRow(MusicGrid), 3).ToString().Remove(0, 38) + ".mp3"))
                File.WriteAllBytes(path + @"\" + DataGridGetData.GetCell(MusicGrid, DataGridGetData.GetSelectedRow(MusicGrid), 3).ToString().Remove(0, 38) + ".mp3", file);
            if (!FileChecker.IsFileLocked(finfo))
            {
                _player.Open(new Uri(path + @"\" + DataGridGetData.GetCell(MusicGrid, DataGridGetData.GetSelectedRow(MusicGrid), 3).ToString().Remove(0, 38) + ".mp3", UriKind.RelativeOrAbsolute));
                _player.Play();
                _player.MediaEnded += new EventHandler(myMediaElement_MediaEnded);
            }
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            _player.Close();
        }

        // Обработчик событий MediaEnded
        private void myMediaElement_MediaEnded(object sender, EventArgs e)
        {
            if (_player.Position == _player.NaturalDuration) // проверка, достиг ли плеер конца
            {
                _player.Close();
                if (sender as Button != null)
                {
                    SongsDataGrid song = (sender as Button).DataContext as SongsDataGrid;
                    var file = song.song_file;
                    string folderName = "media";
                    string path = System.IO.Path.Combine(Environment.CurrentDirectory, folderName);
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    File.WriteAllBytes(path + @"\" + DataGridGetData.GetCell(MusicGrid, DataGridGetData.GetSelectedRow(MusicGrid), 3).ToString().Remove(0, 38) + ".mp3", file);
                    _player.Open(new Uri(path + @"\" + DataGridGetData.GetCell(MusicGrid, DataGridGetData.GetSelectedRow(MusicGrid), 3).ToString().Remove(0, 38) + ".mp3", UriKind.RelativeOrAbsolute));
                    _player.Play();
                }
            }
        }
        public static MediaState GetMediaState(MediaPlayer myMedia)
        {
            FieldInfo stateField = myMedia.GetType().GetField("_mediaPlayerState", BindingFlags.NonPublic | BindingFlags.Instance);
            MediaState state = (MediaState)stateField.GetValue(myMedia);
            return state;
        }

        private void Music_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                KURSACHEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MusicGrid.ItemsSource = new KURSACHEntities().SongsDataGrid.ToList();
            }
        }
    }
}
