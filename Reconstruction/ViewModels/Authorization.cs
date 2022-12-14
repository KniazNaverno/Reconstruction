using Reconstruction.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reconstruction;
using System.Windows;

namespace Reconstruction.ViewModels
{
    public class Authorization : BaseViewModel
    {
        private string _password;
        private string _login;
        private RelayCommand _openWindow;
        private RelayCommand _openWindow2;
        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand OpenWindow
        {
            get
            {
                return _openWindow ??
                    (_openWindow = new RelayCommand((x) =>
                    {
                        Registration registration = new Registration();
                        registration.Show();
                        ((Window)x).Close();
                    }));
            }
        }
        public static int id;
        public RelayCommand OpenWindow2
        {
            get
            {
                return _openWindow2 ??
                    (_openWindow2 = new RelayCommand((x) =>
                    {
                        var user = Helper.GetContext().Users.SingleOrDefault(x => x.Login == Login & x.Password == Password);
                        if (user != null)
                        {
                            HomePage homePage = new HomePage();
                            homePage.Show();
                            ((Window)x).Close();
                        }
                        if (user == null)
                        {
                            MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        Helper.User = user;
                        id = user.IdUsers
                        ;
                    }));
            }
        }
        public Authorization()
        {
            if (Helper.User != null)
            {
                User = Helper.User;
            }
        }
    }
}
