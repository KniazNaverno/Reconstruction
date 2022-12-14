using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Reconstruction;


namespace Reconstruction.ViewModels
{
    public class RegistrationWindow : BaseViewModel
    {
        private User _user = new User();
        private RelayCommand _submitRegistration;
        private User _place;
        private string _password;
        private string _login;
        private string _surname;
        private string _name;
        private string _patronymic;
        private string _phoneNumber;
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
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                _patronymic = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SumbitRegistration
        {
            get
            {
                return _submitRegistration ??
                    (_submitRegistration = new RelayCommand((x) =>
                    {
                        if (_user.IdUsers == 0)
                        {
                            _user.Login = _login;
                            
                            _user.Password = _password;
                            
                            _user.Surname = _surname;
                            
                            _user.Name = _name;
                            
                            _user.Patronymic = _patronymic;
                            
                            _user.PhoneNumber = _phoneNumber;
                            
                            Helper.GetContext().Users.Add(_user);
                            try
                            {
                                Helper.GetContext().SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Данные не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            if (_user.Login != null & _user.Password != null & _user.Surname != null & _user.Name != null & _user.Patronymic != null & _user.PhoneNumber != null)
                            {
                                MessageBox.Show("Пользователь Зарегистрирован", "Зарегистрирован", MessageBoxButton.OK, MessageBoxImage.Information);
                                MainWindow authorization = new MainWindow();
                                authorization.Show();
                                ((Window)x).Close();
                            }
                        }
                        ((Window)x).Close();
                    }));
            }
        }
    }
}
