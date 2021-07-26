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
using TicsaManagmentSoftware.APIHelper.DTO.GammeType;
using TicsaManagmentSoftware.APIHelper.Model;
using TicsaManagmentSoftware.APIHelper.Services;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.Views {
    /// <summary>
    /// Logique d'interaction pour GammeTypeView.xaml
    /// </summary>
    public partial class GammeTypeView : UserControl {

        private IGammeTypeService Service { get; set; }
        public GammeTypeView() {
            InitializeComponent();
            Service = MainWindow.Service.GetRequiredService<IGammeTypeService>();

        }
        private async Task RefreshList() {
            ___GammeTypesListView_.ItemsSource = (await Service.GetAll()).Data;
        }

        private void ClearForm() {
            ___LabelTextBox_.Text = "";
        }

        private async void ___RefreshGammeTypesButton__Click(object sender, RoutedEventArgs e) {
            await RefreshList();
        }

        private async void ___DeleteGammeTypesButton__Click(object sender, RoutedEventArgs e) {
            object itemSelected = ___GammeTypesListView_.SelectedItem;
            if (itemSelected != null) {
                Response<DtoGammeType> result = await Service.Delete(((DtoGammeType)itemSelected).Id.ToString());
                if (result.Succes) {
                    MessageBox.Show(string.Format("Suppression du type de gamme {0} avec Success", result.Data.Label));
                }
                else {
                    MessageBox.Show(result.Data.ToString());
                }
                await RefreshList();
            }
        }

        private async void ___FinalizeButton__Click(object sender, RoutedEventArgs e) {
            if (___GammeTypeActionComboBox_.SelectedItem != null) {
                switch ((QueryTypeEnum)___GammeTypeActionComboBox_.SelectedItem) {
                    case QueryTypeEnum.Ajout:
                        Response<DtoGammeType> resultPost = await Service.Post(new GammeType() {
                            Label = ___LabelTextBox_.Text,
                        });
                        if (resultPost.Succes) {
                            MessageBox.Show("Ajout du type de gamme avec succes");
                        }
                        else {
                            MessageBox.Show(string.Format("Une erreur est survenue lors de l'ajout du type de gamme \nErreur : {0}", resultPost.Error));
                        }
                        break;
                    case QueryTypeEnum.Modification:
                        if (___GammeTypesListView_.SelectedItem == null) {
                            MessageBox.Show("Veuillez selectionner le type de gamme dont vous souhaitez mettre à jour les informations dans la section gauche de la fenettre");
                        }
                        else {
                            Response<DtoGammeType> resultPut = await Service.Put(new GammeType() {
                                Label = ___LabelTextBox_.Text,
                            }, ((DtoGammeType)___GammeTypesListView_.SelectedItem).Id.ToString());
                            if (resultPut.Succes) {
                                MessageBox.Show("Modification du type de gamme avec succes");
                            }
                            else {
                                MessageBox.Show(string.Format("Une erreur est survenue lors de la modification du type de gamme \nErreur : {0}", resultPut.Error));
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
    }
}
