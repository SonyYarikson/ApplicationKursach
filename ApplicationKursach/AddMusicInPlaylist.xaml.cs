using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddMusicInPlaylist.xaml
    /// </summary>
    public partial class AddMusicInPlaylist : Page
    {
        private Songs songs = new Songs();
        private Albums albums = new Albums();
        private Playlists playlists = new Playlists();
        public AddMusicInPlaylist()
        {
            InitializeComponent();
            MusicInPlaylist.ItemsSource = KURSACHEntities.GetContext().SongsDataGrid.ToList();
        }

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveMusicInPlaylist_Click(object sender, RoutedEventArgs e)
        {
            //PlaylistFrame.Navigate(new Music());
        }

        private void AddMusic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            var selecteditem = DataGridGetData.GetCell(MusicInPlaylist, DataGridGetData.GetSelectedRow(MusicInPlaylist), 4).ToString().Remove(0, 38);
            playlists.id_playlist = AddPlaylist.playlists.id_playlist;
            playlists.id_user = KURSACHEntities.GetContext().Users.Where(x => x.Username == Authorize.registration.Login).Select(y => y.id_user).FirstOrDefault();
            var song = KURSACHEntities.GetContext().Songs.Where(x => x.Name == selecteditem).Select(y => y.id_song).FirstOrDefault();
            var album = KURSACHEntities.GetContext().Albums.Where(x => x.id_song == song).FirstOrDefault();
            playlists.id_record = album.id_record;
            KURSACHEntities.GetContext().Playlists.Add(playlists);
            KURSACHEntities.GetContext().SaveChanges();
            var button = (sender as Button);
            button.Visibility = Visibility.Hidden;
            
                
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }
    }
}
