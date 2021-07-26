using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TicsaManagmentSoftware.APIHelper;
using TicsaManagmentSoftware.APIHelper.DTO.Clients;
using TicsaManagmentSoftware.APIHelper.Model;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

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
            object itemSelected = ___ClientsListView_.SelectedItem;
            if (itemSelected != null) {
                Response<DtoClient> result = await Service.Delete(((DtoClient)itemSelected).Id.ToString());
                if (result.Succes) {
                    MessageBox.Show(string.Format("Suppression du client {0} {1} avec Success", result.Data.LastName, result.Data.FirstName));
                }
                else {
                    MessageBox.Show(result.Data.ToString());
                }
                await RefreshList();
            }

        }
        private async Task RefreshList() {
            ___ClientsListView_.ItemsSource = (await Service.GetAll()).Data;
        }

        private void ClearForm() {
            ___FirstNameTextBox_.Text = "";
            ___LastNameTextBox_.Text = "";
            ___CompagnieNameTextBox_.Text = "";
            ___EmailTextBox_.Text = "";
            ___PhoneNumberTextBox_.Text = "";
            ___AdddressTextBox_.Text = "";
            ___PostalCodeTextBox_.Text = "";
        }

        private async void ___FinalizeButton__Click(object sender, RoutedEventArgs e) {
            if (___ClientActionComboBox_.SelectedItem != null) {
                switch ((QueryTypeEnum)___ClientActionComboBox_.SelectedItem) {
                    case QueryTypeEnum.Ajout:
                        Response<DtoClient> resultPost = await Service.Post(new Client() {
                            FirstName = ___FirstNameTextBox_.Text,
                            LastName = ___LastNameTextBox_.Text,
                            CompagnieName = ___CompagnieNameTextBox_.Text,
                            Email = ___EmailTextBox_.Text,
                            PhoneNumber = ___PhoneNumberTextBox_.Text,
                            Address = ___AdddressTextBox_.Text,
                            PostalCode = ___PostalCodeTextBox_.Text
                        });
                        if (resultPost.Succes) {
                            MessageBox.Show("Ajout du client avec succes");
                        }
                        else {
                            MessageBox.Show(string.Format("Une erreur est survenue lors de l'ajout du client \nErreur : {0}", resultPost.Error));
                        }
                        break;
                    case QueryTypeEnum.Modification:
                        if (___ClientsListView_.SelectedItem == null) {
                            MessageBox.Show("Veuillez selectionner le client dont vous souhaitez mettre à jour les informations dans la section gauche de la fenettre");
                        }
                        else {
                            Response<DtoClient> resultPut = await Service.Put(new Client() {
                                FirstName = ___FirstNameTextBox_.Text,
                                LastName = ___LastNameTextBox_.Text,
                                CompagnieName = ___CompagnieNameTextBox_.Text,
                                Email = ___EmailTextBox_.Text,
                                PhoneNumber = ___PhoneNumberTextBox_.Text,
                                Address = ___AdddressTextBox_.Text,
                                PostalCode = ___PostalCodeTextBox_.Text
                            }, ((DtoClient)___ClientsListView_.SelectedItem).Id.ToString());
                            if (resultPut.Succes) {
                                MessageBox.Show("Modification du client avec succes");
                            }
                            else {
                                MessageBox.Show(string.Format("Une erreur est survenue lors de la modification du client \nErreur : {0}", resultPut.Error));
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
