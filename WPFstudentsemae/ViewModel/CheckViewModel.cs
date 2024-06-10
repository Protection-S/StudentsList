using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFstudentsemae.Data;
using WPFstudentsemae.Model;
namespace WPFstudentsemae.ViewModel
{
    internal class CheckViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students; 

        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public CheckViewModel()
        {
            using (var context = new Databoy())
            {
                Students = new ObservableCollection<Student>(context.MainStudents.ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
