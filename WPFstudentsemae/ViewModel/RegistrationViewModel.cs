using System;
using System.Windows.Input;
using WPFstudentsemae.Model;
using WPFstudentsemae.Data;
using System.Windows;
using System.ComponentModel;
namespace WPFstudentsemae.ViewModel
{

    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _email;
        private string _password;
        private string _repeatPassword;
        private string _firstName;
        private string _lastName;
        private string _patronymic;
        private GenderType? _gender;
        private DateTime? _dateOfBirth;
        private string _group;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string RepeatPassword
        {
            get => _repeatPassword;
            set { _repeatPassword = value; OnPropertyChanged(nameof(RepeatPassword)); }
        }

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        public string Patronymic
        {
            get => _patronymic;
            set { _patronymic = value; OnPropertyChanged(nameof(Patronymic)); }
        }

        public GenderType? Gender
        {
            get => _gender;
            set { _gender = value; OnPropertyChanged(nameof(Gender)); }
        }

        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); }
        }

        public string Group
        {
            get => _group;
            set { _group = value; OnPropertyChanged(nameof(Group)); }
        }

        public ICommand RegisterCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegistrationViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(RepeatPassword) ||
                string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Patronymic) ||
                Gender == null ||
                DateOfBirth == null ||
                string.IsNullOrWhiteSpace(Group))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Password != RepeatPassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new Databoy())
            {
                if (db.MainStudents.Any(s => s.Username == Username || s.Email == Email))
                {
                    MessageBox.Show("Пользователь с таким логином или почтой уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newStudent = new Student
                {
                    Username = Username,
                    Email = Email,
                    Password = Password,
                    Name = FirstName,
                    Surname = LastName,
                    Patronymic = Patronymic,
                    Gender = Gender.Value,
                    DateOfBirth = DateOfBirth.Value,
                    Group = Group
                };

                db.MainStudents.Add(newStudent);
                db.SaveChanges();
            }

            MessageBox.Show("Регистрация успешна", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
