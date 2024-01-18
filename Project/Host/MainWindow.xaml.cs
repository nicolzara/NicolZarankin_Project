using System.ServiceModel;
using System.Windows;
using WcfServiceLibrary;

namespace Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceHost serviceHost = new ServiceHost(typeof(Service));
            serviceHost.Open();
        }
    }
}
