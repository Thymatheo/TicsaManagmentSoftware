using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
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

        private void ___ProducerMenuItem__Click(object sender, RoutedEventArgs e) {
            ___MainContentControl_.Content = new ProducerViewModel();
        }

        private void ___GammeTypeMenuItem__Click(object sender, RoutedEventArgs e) {
            ___MainContentControl_.Content = new GammeTypeViewModel();
        }

        private void ___GammeMenuItem__Click(object sender, RoutedEventArgs e) {
            ___MainContentControl_.Content = new GammeViewModel();
        }
    }
}
