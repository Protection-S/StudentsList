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
using System.Windows.Shapes;
using WPFstudentsemae.ViewModel;

namespace WPFstudentsemae.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            this.DataContext = new RegistrationViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegistrationViewModel viewModel)
            {
                if (sender is PasswordBox passwordBox)
                {
                    if (passwordBox.Name == "txtPassword")
                    {
                        viewModel.Password = passwordBox.Password;
                    }
                    else if (passwordBox.Name == "txtRepeatPassword")
                    {
                        viewModel.RepeatPassword = passwordBox.Password;
                    }
                }
            }
        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
