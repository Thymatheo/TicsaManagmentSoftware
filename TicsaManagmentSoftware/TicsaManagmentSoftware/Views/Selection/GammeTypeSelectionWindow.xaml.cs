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
using TicsaManagmentSoftware.APIHelper.DTO.GammeType;
using TicsaManagmentSoftware.APIHelper.Model;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.Views.Selection {
    /// <summary>
    /// Logique d'interaction pour GammeTypeSelectionWindow.xaml
    /// </summary>
    public partial class GammeTypeSelectionWindow : Window, IDisposable {
        public IGammeTypeService Service { get; set; }
        public GammeType SelectedGammeType { get; set; }

        public GammeTypeSelectionWindow() {
            InitializeComponent();
            Service = MainWindow.Service.GetRequiredService<IGammeTypeService>();
        }

        public void Dispose() {
            Service = null;
            SelectedGammeType = null;
        }

        private async void ___LoadGammeTypesButton__Click(object sender, RoutedEventArgs e) {
            ___GammeTypesListView_.ItemsSource = (await Service.GetAll()).Data;
        }

        private void ___SelectGammeTypeButton__Click(object sender, RoutedEventArgs e) {
            object selectedItem = ___GammeTypesListView_.SelectedItem;
            if (selectedItem != null) {
                DtoGammeType type = (DtoGammeType)selectedItem;
                SelectedGammeType = new GammeType() {
                    Label = type.Label,
                    Id = type.Id
                };
                Close();
            }
            else
                MessageBox.Show("Veuillez selectionner un type de gamme !!!");
        }
    }
}
