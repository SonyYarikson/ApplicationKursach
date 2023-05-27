using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace ApplicationKursach
{
    /// <summary>
    /// Логика взаимодействия для AddMusicPage.xaml
    /// </summary>
    public partial class AddMusicPage : Page
    {
        public AddMusicPage()
        {
            InitializeComponent();
            //AuthorName.ItemsSource = KURSACHEntities.GetContext().Authors.ToList();
            //PerformerName.ItemsSource = KURSACHEntities.GetContext().Performers.ToList();
            //AddAlbum.ItemsSource = KURSACHEntities.GetContext().Album_description.ToList();
        }
        Albums album = new Albums();
        Songs song = new Songs();
        Performers performers = new Performers();
        Authors authors = new Authors();
        Performers_and_Albums performers_and_albums = new Performers_and_Albums();
        Album_description album_Description = new Album_description();
        private void Savebutton_Click(object sender, RoutedEventArgs e)
        {
            var author = AuthorName.SelectedItem as Authors;
            var albumdes = AddAlbum.SelectedItem as Album_description;
            var performerses= PerformerName.SelectedItem as Performers;

            song.Name = SongName.Text;
            song.id_Author = author.id_Author;
            song.Genre = SongGenre.Text;
            KURSACHEntities.GetContext().Songs.Add(song);
            album.id_song = song.id_song;
            album.id_album = albumdes.id_album;
            KURSACHEntities.GetContext().Albums.Add(album);
            performers_and_albums.id_performer = performerses.id_performer;
            performers_and_albums.id_record = album.id_record;
            KURSACHEntities.GetContext().Performers_and_Albums.Add(performers_and_albums);
           
            try
            {
                KURSACHEntities.GetContext().SaveChanges();
                MessageBox.Show("ИНФОРМАЦИЯ СОХРАНЕНА");
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


        private void Filelist_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ваша композиция|*.mp3";

            if (openFileDialog.ShowDialog() == true)
            {
                string musicPath = openFileDialog.FileName;
                byte[] musicData = File.ReadAllBytes(musicPath);
                album.song_file = musicData;

            }

            Filelist2.Visibility = Visibility.Hidden;
        }

        private void FilelistPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ваше Изображение|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(imagePath);

                song.Cover = imageData;
            }
            Filelist.Visibility = Visibility.Hidden;
        }

        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            
            AddNew.Navigate(new AddAuthor());
        }

        private void PerformerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selected = PerformerName.SelectedItem as Performers;
            //performers.Name = selected.Name;
        }

        private void AddNewAlbum_Click(object sender, RoutedEventArgs e)
        {
            AddNew.Navigate(new AddAlbum());
        }

        private void AddMusic_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AuthorName.ItemsSource = KURSACHEntities.GetContext().Authors.ToList();
                PerformerName.ItemsSource = KURSACHEntities.GetContext().Performers.ToList();
                AddAlbum.ItemsSource = KURSACHEntities.GetContext().Album_description.ToList();
            }
        }

        private void AddPerformer_Click(object sender, RoutedEventArgs e)
        {
            AddNew.Navigate(new AddPerformer());
        }
    }
}
