using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TicsaManagmentSoftware.APIHelper;
using TicsaManagmentSoftware.APIHelper.DTO.Gamme;
using TicsaManagmentSoftware.APIHelper.Model;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;
using TicsaManagmentSoftware.Views.Selection;

namespace TicsaManagmentSoftware.Views {
    /// <summary>
    /// Logique d'interaction pour GammeView.xaml
    /// </summary>
    public partial class GammeView : UserControl {
        private IGammeService Service { get; set; }
        public GammeView() {
            InitializeComponent();
            Service = MainWindow.Service.GetRequiredService<IGammeService>();
        }

        private async Task RefreshList() {
            ___GammesListView_.ItemsSource = (await Service.GetAll()).Data;
        }

        private async void ___RefreshGammesButton__Click(object sender, System.Windows.RoutedEventArgs e) {
            await RefreshList();
        }

        private async void ___DeleteGammesButton__Click(object sender, System.Windows.RoutedEventArgs e) {
            object itemSelected = ___GammesListView_.SelectedItem;
            if (itemSelected != null) {
                Response<DtoGamme> result = await Service.Delete(((DtoGamme)itemSelected).Id.ToString());
                if (result.Succes) {
                    MessageBox.Show(string.Format("Suppression du type de gamme {0} avec Success", result.Data.Label));
                }
                else {
                    MessageBox.Show(result.Data.ToString());
                }
                await RefreshList();
            }
        }

        private async void ___FinalizeButton__Click(object sender, System.Windows.RoutedEventArgs e) {
            if (___GammeActionComboBox_.SelectedItem != null) {
                switch ((QueryTypeEnum)___GammeActionComboBox_.SelectedItem) {
                    case QueryTypeEnum.Ajout:
                        Response<DtoGamme> resultPost = await Service.Post(new Gamme() {
                            Label = ___LabelTextBox_.Text,
                            Description = ___DescriptionTextBox_.Text,
                            Cost = double.Parse(___CostTextBox_.Text),
                            Stock = int.Parse(___StockTextBox_.Text),
                            CostHisto = "",
                            StockHisto = "",
                            IdProducer = ((Producer)___ProducerSelectedTextBlock_.DataContext).Id,
                            IdType = ((GammeType)___GammeTypeSelectedTextBlock_.DataContext).Id,
                        });
                        if (resultPost.Succes) {
                            MessageBox.Show("Ajout de la gamme avec succes");
                        }
                        else {
                            MessageBox.Show(string.Format("Une erreur est survenue lors de l'ajout de la gamme \nErreur : {0}", resultPost.Error));
                        }
                        break;
                    case QueryTypeEnum.Modification:
                        if (___GammesListView_.SelectedItem == null) {
                            MessageBox.Show("Veuillez selectionner de la gamme dont vous souhaitez mettre à jour les informations dans la section gauche de la fenettre");
                        }
                        else {
                            Response<DtoGamme> resultPut = await Service.Put(new DtoGammeUpdate() {
                                Label = ___LabelTextBox_.Text,
                                Description = ___DescriptionTextBox_.Text,
                                Cost = string.IsNullOrEmpty(___CostTextBox_.Text) ? 0.0 : double.Parse(___CostTextBox_.Text),
                                Stock = string.IsNullOrEmpty(___StockTextBox_.Text) ? 0 : int.Parse(___StockTextBox_.Text),
                                IdProducer = ___ProducerSelectedTextBlock_.DataContext is Producer ? ((Producer)___ProducerSelectedTextBlock_.DataContext).Id : 0,
                                IdType = ___ProducerSelectedTextBlock_.DataContext is GammeType ? ((GammeType)___GammeTypeSelectedTextBlock_.DataContext).Id : 0,
                            }, ((DtoGamme)___GammesListView_.SelectedItem).Id.ToString());
                            if (resultPut.Succes) {
                                MessageBox.Show("Modification de la gamme avec succes");
                            }
                            else {
                                MessageBox.Show(string.Format("Une erreur est survenue lors de la modification de la gamme \nErreur : {0}\n{1}", resultPut.Data, resultPut.Error));
                            }
                            break;
                        }
                        break;
                }
                await RefreshList();
                ClearForm();
            }
            else {
                MessageBox.Show("Veuillez choisir un type d'action à effectuer en haut de cette section");
            }
        }

        private void ClearForm() {
            ___LabelTextBox_.Text = "";
            ___DescriptionTextBox_.Text = "";
            ___CostTextBox_.Text = "";
            ___StockTextBox_.Text = "";
            ___ProducerSelectedTextBlock_.Text = null;
            ___GammeTypeSelectedTextBlock_.Text = null;
        }

        private void ___ProducerButton__Click(object sender, RoutedEventArgs e) {
            using (ProducerSelectionWindow window = new ProducerSelectionWindow()) {
                window.ShowDialog();
                ___ProducerSelectedTextBlock_.DataContext = window.SelectedProducer;
            }
        }

        private void ___GammeTypeButton__Click(object sender, RoutedEventArgs e) {
            using (GammeTypeSelectionWindow window = new GammeTypeSelectionWindow()) {
                window.ShowDialog();
                ___GammeTypeSelectedTextBlock_.DataContext = window.SelectedGammeType;
            }
        }

        private void ___ShowStockHistMenuItem__Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(((DtoGamme)___GammesListView_.SelectedItem).StockHisto);
        }

        private void ___ShowCostHistMenuItem__Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(((DtoGamme)___GammesListView_.SelectedItem).CostHisto);
        }
    }
}

