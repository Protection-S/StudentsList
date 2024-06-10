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
using WPFstudentsemae.ViewModel;

namespace WPFstudentsemae.View
{
    /// <summary>
    /// Логика взаимодействия для AddStudentListPage.xaml
    /// </summary>
    public partial class AddStudentListPage : Page
    {
        public AddStudentListPage()
        {
            InitializeComponent();

            DataContext = new CreateViewModel();
        }

    }
}
