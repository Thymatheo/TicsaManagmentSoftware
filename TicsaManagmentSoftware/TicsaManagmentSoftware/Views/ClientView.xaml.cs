using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
using TicsaManagmentSoftware.APIHelper;
using TicsaManagmentSoftware.APIHelper.DTO.Clients;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;
using TicsaManagmentSoftware.ViewModel;

namespace TicsaManagmentSoftware.Views {
    /// <summary>
    /// Logique d'interaction pour ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl {
        public IClientService Service { get; private set; }

        public ClientView() {
            InitializeComponent();
            Service = MainWindow.Service.GetRequiredService<IClientService>();
        }

        private async void ___RefreshClientsButton__Click(object sender, RoutedEventArgs e) {
            await RefreshList();
        }

        private async void ___DeleteClientsButton__Click(object sender, RoutedEventArgs e) {
            object itemSelected = ___ProjectSaveListView_.SelectedItem;
            if (itemSelected != null) {
                Response<DtoClient> result = await Service.Delete(((DtoClient)itemSelected).Id.ToString());
                if (result.Succes)
                    MessageBox.Show(string.Format("Suppression du client {0} {1} avec Success", result.Data.LastName, result.Data.FirstName));
                else
                    MessageBox.Show(result.Data.ToString());
                await RefreshList();
            }

        }
        private async Task RefreshList() {
            ___ProjectSaveListView_.ItemsSource = (await Service.GetAll()).Data;
        }
    }
}
