﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alstom.Libraries.UI.ViewComponents
{
    /// <summary>
    /// Interaction logic for HeaderViewComponent.xaml
    /// </summary>
    public partial class HeaderViewComponent : UserControl
    {
        public HeaderViewComponent()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var message = "Do you wish to close the application now?";
            var caption = "Application Shutdown";
            var userConfirmationResult =
                MessageBox.Show(message, caption, MessageBoxButton.OKCancel);

            if (userConfirmationResult == MessageBoxResult.OK)
                Application.Current.Shutdown();
        }
    }
}
