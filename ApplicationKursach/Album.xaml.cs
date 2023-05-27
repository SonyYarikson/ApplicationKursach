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
    /// Логика взаимодействия для Albums.xaml
    /// </summary>
    public partial class Album : Page
    {
        public Album()
        {
            InitializeComponent();
            LVAlbums.ItemsSource = new KURSACHEntities().Album_description.ToList();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Album_description album = (sender as Button).DataContext as Album_description;
            AlbumsDescription._content = album;
            Playlist.Navigate(new AlbumsDescription());
        }
    }
}
