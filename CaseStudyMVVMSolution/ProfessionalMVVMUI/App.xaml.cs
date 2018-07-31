using Alstom.Libraries.UI.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProfessionalMVVMUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var viewName = "MainView";
            var viewObject = ViewBuilder.Build<Window>(viewName, isViewModelAvailable: true);

            Application.Current.MainWindow = viewObject;
            Application.Current.MainWindow.Show();
        }
    }
}
