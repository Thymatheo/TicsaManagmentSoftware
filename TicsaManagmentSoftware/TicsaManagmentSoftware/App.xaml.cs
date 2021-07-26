using System.Windows;

namespace TicsaManagmentSoftware {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show(string.Format("An unhandled exception just occurred: {0}\nStackTrace: {1}", e.Exception.Message, e.Exception.StackTrace), "No Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
