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
    public class TaskHistoryWindow : BaseViewModel
    {
        private Task _task;
        private RelayCommand _openWindow;
        private ObservableCollection<Task> _tasks;
        private RelayCommand _executeTask;
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
        public ObservableCollection<Task> Tasks
        {

            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }
        public Task Task
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand ExecuteTask
        {
            get
            {
                return _executeTask ??
                    (_executeTask = new RelayCommand((x) =>
                    {
                        if (_task != null)
                        {
                            _task.IdStatus = 3;
                            _task.IdStatusNavigation = Helper.GetContext().Statuses.Find(3);
                            Helper.GetContext().Tasks.Update(_task);
                            Helper.GetContext().SaveChanges();
                            MessageBox.Show("Задание выполнено", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Задание не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                    }));
            }
        }
        public TaskHistoryWindow()
        {
            _tasks = new ObservableCollection<Task>(Helper.GetContext().Tasks.Include(x => x.IdUserWorkerNavigation).Include(x => x.IdUserClientNavigation).Include(x => x.IdStatusNavigation).Where(x => x.IdUserWorker == Authorization.id).OrderBy(x => x.IdStatusNavigation ));
        }
    }
}
