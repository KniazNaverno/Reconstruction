using Reconstruction.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reconstruction.ViewModels
{
    public class HomePageWindow : BaseViewModel
    {
        private RelayCommand _openWindow;
        private RelayCommand _openWindow2;
        private RelayCommand _openWindow3;
        private ObservableCollection<User> _user;
        public RelayCommand OpenWindow
        {
            get
            {
                return _openWindow ??
                    (_openWindow = new RelayCommand((x) =>
                    {
                        Profile profile = new Profile();
                        profile.Show();
                        ((Window)x).Close();
                    }));
            }
        }
        public RelayCommand OpenWindow2
        {
            get
            {
                return _openWindow2 ??
                    (_openWindow2 = new RelayCommand((x) =>
                    {
                        TasksList tasksList = new TasksList();
                        tasksList.Show();
                        ((Window)x).Close();
                    }));
            }
        }
        public RelayCommand OpenWindow3
        {
            get
            {
                return _openWindow3 ??
                    (_openWindow3 = new RelayCommand((x) =>
                    {
                        TaskHistory tasksHistory = new TaskHistory();
                        tasksHistory.Show();
                        ((Window)x).Close();
                    }));
            }
        }
        public ObservableCollection<User> Users
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public HomePageWindow()
        {

            Users = new ObservableCollection<User>(Helper.GetContext().Users.ToList());
        }
    }
}
