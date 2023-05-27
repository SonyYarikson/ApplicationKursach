using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationKursach
{
    /// <summary>
    /// Логика взаимодействия для Authorize.xaml
    /// </summary>
    public partial class Authorize : Page
    {
        private KURSACHEntities _currentBase = new KURSACHEntities();
        public Authorize()
        {
            InitializeComponent();
        }
        public static Registration registration;
        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.db.Registration.FirstOrDefault(a => a.Login == Login.Text && a.Password == Password.Password);

            if (CurrentUser != null)
            {
                registration = KURSACHEntities.GetContext().Registration.Where(y => y.Login == Login.Text).FirstOrDefault();
                Manager.LoginFrame.Navigate(new MainFrame());
            }
            else
            {
                MessageBox.Show("Данного пользователя не существует");
            }
            
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizePage.Navigate(new RegistrationPage());
        }
    }
}
