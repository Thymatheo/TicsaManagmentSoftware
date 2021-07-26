using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicsaManagmentSoftware.APIHelper.DTO.Producer;
using TicsaManagmentSoftware.APIHelper.Model;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.Views.Selection {
    /// <summary>
    /// Logique d'interaction pour ProducerSelectionWindow.xaml
    /// </summary>
    public partial class ProducerSelectionWindow : Window, IDisposable {
        private IProducerService Service { get; set; }

        public Producer SelectedProducer { get; set; }
        public ProducerSelectionWindow() {
            InitializeComponent();
            Service = MainWindow.Service.GetRequiredService<IProducerService>();
        }

        private void ___SelectProducerButton__Click(object sender, RoutedEventArgs e) {
            object selectedItem = ___ProducersListView_.SelectedItem;
            if (selectedItem != null) {
                DtoProducer prod = (DtoProducer)___ProducersListView_.SelectedItem;
                SelectedProducer = new Producer() {
                    Address = prod.Address,
                    CompagnieName = prod.CompagnieName,
                    Email = prod.Email,
                    FirstName = prod.FirstName,
                    LastName = prod.LastName,
                    PhoneNumber = prod.PhoneNumber,
                    PostalCode = prod.PostalCode,
                    Id = prod.Id
                };
                Close();
            }
            else
                MessageBox.Show("Veuillez selectionner un producteur !!!");
        }

        private async void ___LoadProducersButton__Click(object sender, RoutedEventArgs e) {

            ___ProducersListView_.ItemsSource = (await Service.GetAll()).Data;
        }

        public void Dispose() {
            Service = null;
            SelectedProducer = null;
        }
    }
}
