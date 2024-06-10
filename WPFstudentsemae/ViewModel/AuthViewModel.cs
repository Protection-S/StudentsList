using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPFstudentsemae.Data;
using WPFstudentsemae.Windows;

namespace WPFstudentsemae.ViewModel
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegistrationCommand { get; }

        public AuthViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            NavigateToRegistrationCommand = new RelayCommand(NavigateToRegistration);
        }


        private void NavigateToRegistration(object parameter)
        {
            var registrationWindow = new Registration();
            registrationWindow.Show();
        }

        private void Login(object parameter)
        {
            using (var db = new Databoy())
            {
                var user = db.MainStudents.FirstOrDefault(s => s.Username == Username && s.Password == Password);
                if (user != null)
                {
                    MessageBox.Show("Вы успешно вошли в систему", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
