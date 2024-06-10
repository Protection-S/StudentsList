using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFstudentsemae.View;

namespace WPFstudentsemae
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentsListClick(object sender, RoutedEventArgs e)
        {
            Opener.Navigate(new StudentsListPage());
        }

        private void AddStudentsClick(object sender, RoutedEventArgs e)
        {
            Opener.Navigate(new AddStudentListPage());
        }

        private void Opener_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}