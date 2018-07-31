using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ResourcesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var resourceFileName = @"AlstomResources.xaml";
            var resources = (ResourceDictionary)XamlReader.Load(
                XmlReader.Create(
                    File.OpenRead(resourceFileName),
                    new XmlReaderSettings
                    {
                        CheckCharacters = true,
                        ConformanceLevel = ConformanceLevel.Auto,
                        IgnoreComments = true,
                        IgnoreProcessingInstructions = true,
                        IgnoreWhitespace = true
                    }));

            this.Resources.MergedDictionaries.Add(resources);
        }
    }
}
