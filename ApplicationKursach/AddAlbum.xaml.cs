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
    /// Логика взаимодействия для AddAlbum.xaml
    /// </summary>
    public partial class AddAlbum : Page
    {
        public AddAlbum()
        {
            InitializeComponent();
        }
        Album_description album_Description = new Album_description();
        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ваше Изображение|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(imagePath);

                album_Description.Cover = imageData;
            }
            AddPhoto.Visibility = Visibility.Hidden;
        }

        private void SaveAlbum_click(object sender, RoutedEventArgs e)
        {
            album_Description.Name = AlbumName.Text;
            KURSACHEntities.GetContext().Album_description.Add(album_Description);
            KURSACHEntities.GetContext().SaveChanges();
            AddnewAlbum.Navigate(new AddMusicPage());
        }
    }
}
