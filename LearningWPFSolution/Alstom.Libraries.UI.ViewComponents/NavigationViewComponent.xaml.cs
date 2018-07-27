using System;
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
    /// Interaction logic for NavigationViewComponent.xaml
    /// </summary>
    public partial class NavigationViewComponent : UserControl
    {
        public NavigationViewComponent()
        {
            InitializeComponent();
        }

        private void HandleHomeMouseDown(object sender, MouseButtonEventArgs e)
        {
            HandleNavigation(new HomeContentViewComponent());
        }

        private void HandleCustomersMouseDown(object sender, MouseButtonEventArgs e)
        {
            HandleNavigation(new CustomersContentViewComponent());
        }

        private void HandleNavigation(object content)
        {
            var parentControl = this.Parent as ContentControl;

            if (parentControl != default(ContentControl))
            {
                var layout = parentControl.Parent as Grid;

                if (layout != default(Grid))
                {
                    var contentControl = (ContentControl)parentControl.FindName("CONTENT_REGION");

                    if (contentControl != default(ContentControl))
                    {
                        contentControl.Content = content;
                    }
                }
            }
        }
    }
}
