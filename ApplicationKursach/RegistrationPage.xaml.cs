using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationKursach
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            RegistrationFrame.Navigate(new Authorize());
        }

        private void SingUp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            Registration reg = new Registration();
            bool flag = false;
            currentUser.Login = Login.Text;
            currentUser.Password = Password.Password;
            if (string.IsNullOrWhiteSpace(Login.Text)) errors.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(Password.Password)) errors.AppendLine("Укажите пароль");
            if (errors.Length == 0) 
            { 
            var db = new KURSACHEntities();
            var user = db.Registration.Select(x => x.Login).ToList();
            if (Password.Password == ReturnePas.Password)
            {
                currentUser.Password = Password.Password;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
                    return;
            }
            currentUser.Role = "User";
                foreach (var item in user) if (currentUser.Login == item) flag = true;
                if (flag == false)
                {
                    KURSACHEntities.GetContext().Registration.Add(currentUser);
                    KURSACHEntities.GetContext().SaveChanges();
                    this.Visibility = Visibility.Hidden;
                    RegistrationFrame.Navigate(new Authorize());
                }
                else MessageBox.Show("Пользователь с таким именем уже существует");
            }
            else MessageBox.Show(errors.ToString());
        }

        private Registration currentUser = new Registration();
    }
}
