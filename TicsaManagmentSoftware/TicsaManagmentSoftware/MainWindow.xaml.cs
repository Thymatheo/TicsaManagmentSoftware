using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;
using TicsaManagmentSoftware.ViewModel;

namespace TicsaManagmentSoftware {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public static IServiceProvider Service { get; set; }
        public IConfiguration Configuration { get; set; }

        static MainWindow() {
            IServiceCollection service = new ServiceCollection();
            service.Locate();
            Service = service.BuildServiceProvider();
        }
        public MainWindow() {
            InitializeComponent();
        }

        private void ___ClientMenuItem__Click(object sender, RoutedEventArgs e) {
            ___MainContentControl_.Content = new ClientViewModel();
        }
    }
}
