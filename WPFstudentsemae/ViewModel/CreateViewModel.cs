using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFstudentsemae.Data;
using WPFstudentsemae.Model;

namespace WPFstudentsemae.ViewModel
{
    internal class CreateViewModel : INotifyPropertyChanged
    {
        public ICommand AddStudentCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private string _surname;
        private string _lastname;
        private DateTime _birth;
        private string _group;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public DateTime Birth
        {
            get => _birth;
            set
            {
                _birth = value;
                OnPropertyChanged(nameof(Birth));
            }
        }

        public string Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
            }
        }

        public CreateViewModel()
        {
            AddStudentCommand = new RelayCommand(AddStudent);
        }

        private void AddStudent(object parameter)
        {
            using (var db = new Databoy())
            {
                var student = new Student 
                {
                    Name = Name,
                    Surname = Surname,
                    Patronymic = Lastname,
                    DateOfBirth = Birth,
                    Group = Group
                };

                db.MainStudents.Add(student);
                db.SaveChanges();

                MessageBox.Show("Студент успешно добавлен! Возрадуйся же, тушканчик!");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
