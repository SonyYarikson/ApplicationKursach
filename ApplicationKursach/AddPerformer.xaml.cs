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
    /// Логика взаимодействия для AddPerformer.xaml
    /// </summary>
    public partial class AddPerformer : Page
    {
        public AddPerformer()
        {
            InitializeComponent();
        }
        Performers performer = new Performers();
        private void SavePerformer_Click(object sender, RoutedEventArgs e)
        {
            performer.Name = PerformerName.Text;
            KURSACHEntities.GetContext().Performers.Add(performer);
            KURSACHEntities.GetContext().SaveChanges();
            AddPerf.Navigate(new AddMusicPage());
        }
    }
}
