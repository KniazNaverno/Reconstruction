using Reconstruction.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reconstruction.ViewModels
{
    public class ProfieWindow : BaseViewModel
    {
        private RelayCommand _openWindow;
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
    }
}
