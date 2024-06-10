using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WPFstudentsemae.Windows;

namespace WPFstudentsemae.ViewModel
{
    class NavigationViewModel
    {
        public ICommand NavigateToRegistrationCommand { get; }
        public ICommand NavigateToAuthCommand{ get; }

        public NavigationViewModel()
        {
            NavigateToRegistrationCommand = new RelayCommand(NavigateToRegistration);
            NavigateToAuthCommand = new RelayCommand(NavigateToAuth);
        }
        private void NavigateToRegistration(object parameter)
        {
            Registration registrationPage = new Registration();
            registrationPage.Show();
            
            CloseCurrentWindow();
        }

        private void NavigateToAuth(object parameter)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            CloseCurrentWindow();
        }


        private void CloseCurrentWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
