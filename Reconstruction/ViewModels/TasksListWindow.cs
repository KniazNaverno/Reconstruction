using Microsoft.EntityFrameworkCore;
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
    public class TasksListWindow : BaseViewModel
    {
        private Task _task;
        private ObservableCollection<Task> _tasks;
        private RelayCommand _respondToATask;
        private RelayCommand _openWindow;
        public Task Task
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Task> Tasks
        {

            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand RespondToATask
        {
            get
            {
                return _respondToATask ??
                    (_respondToATask = new RelayCommand((x) =>
                    {
                        if (_task != null)
                        {
                            _task.IdUserWorker = Authorization.id;
                            _task.IdStatus = 1;
                            //Helper.GetContext().Entry(Task).Reference(x => x.IdStatusNavigation);
                            Task.IdStatusNavigation = Helper.GetContext().Statuses.Find(1);
                            MessageBox.Show("Задание выбрано", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Задание не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        Helper.GetContext().Tasks.Update(_task);
                        Helper.GetContext().SaveChanges();
                    }));
            }
        }
        public RelayCommand OpenWindow
        {
            get
            {
                return _openWindow ??
                    (_openWindow = new RelayCommand((x) =>
                    {
                        HomePage homePage = new HomePage();
                        homePage.Show();
                        ((Window)x).Close();
                    }));
            }
        }
        public TasksListWindow()
        {
            _tasks = new ObservableCollection<Task>(Helper.GetContext().Tasks.Include(x => x.IdUserWorkerNavigation).Include(x => x.IdUserClientNavigation).Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 2));
        }
    }
}
