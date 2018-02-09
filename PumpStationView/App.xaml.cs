using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using PumpStationView.View;
using PumpStationView.ViewModel;
using PumpStationBase.DAO;

namespace PumpStationView
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            UnitOfWork _uf = new UnitOfWork();
            
            MainView view = new MainView();

            MainViewModel MainVM = new MainViewModel(_uf);
            view.DataContext = MainVM;
            view.Show();
            
        }

    }
}
