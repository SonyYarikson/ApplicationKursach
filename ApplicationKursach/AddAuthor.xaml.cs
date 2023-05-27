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
    /// Логика взаимодействия для AddAuthor.xaml
    /// </summary>
    public partial class AddAuthor : Page
    {
        public AddAuthor()
        {
            InitializeComponent();
        }
        private static Authors author = new Authors();
        private void SaveAuthor_click(object sender, RoutedEventArgs e)
        {
            author.Name = AuthorName.Text;
            author.Description = AuthorDescription.Text;
            KURSACHEntities.GetContext().Authors.Add(author);
            KURSACHEntities.GetContext().SaveChanges();
            AddAuthorFrame.Navigate(new AddMusicPage());
        }

        private void AuthorPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ваше Изображение|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(imagePath);

                author.Photo = imageData;
            }
            AuthorPhoto.Visibility = Visibility.Hidden;
        }
    }
}
