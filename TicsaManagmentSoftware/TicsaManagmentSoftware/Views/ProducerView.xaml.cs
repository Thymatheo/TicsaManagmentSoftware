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
using TicsaManagmentSoftware.APIHelper.DTO.Producer;
using TicsaManagmentSoftware.APIHelper.Model;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.Views {
    /// <summary>
    /// Logique d'interaction pour ProducerView.xaml
    /// </summary>
    public partial class ProducerView : UserControl {
        public IProducerService Service { get; set; }

        public ProducerView() {
            InitializeComponent();
            Service = MainWindow.Service.GetRequiredService<IProducerService>();
        }


        private async Task RefreshList() {
            ___ProducersListView_.ItemsSource = (await Service.GetAll()).Data;
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

        private async void ___DeleteProducersButton__Click(object sender, RoutedEventArgs e) {
            object itemSelected = ___ProducersListView_.SelectedItem;
            if (itemSelected != null) {
                Response<DtoProducer> result = await Service.Delete(((DtoProducer)itemSelected).Id.ToString());
                if (result.Succes) {
                    MessageBox.Show(string.Format("Suppression du producteur {0} {1} avec Success", result.Data.LastName, result.Data.FirstName));
                }
                else {
                    MessageBox.Show(result.Data.ToString());
                }
                await RefreshList();
            }
        }

        private async void ___RefreshProducersButton__Click(object sender, RoutedEventArgs e) {
            await RefreshList();
        }

        private async void ___FinalizeButton__Click(object sender, RoutedEventArgs e) {
            if (___ProducerActionComboBox_.SelectedItem != null) {
                switch ((QueryTypeEnum)___ProducerActionComboBox_.SelectedItem) {
                    case QueryTypeEnum.Ajout:
                        Response<DtoProducer> resultPost = await Service.Post(new Producer() {
                            FirstName = ___FirstNameTextBox_.Text,
                            LastName = ___LastNameTextBox_.Text,
                            CompagnieName = ___CompagnieNameTextBox_.Text,
                            Email = ___EmailTextBox_.Text,
                            PhoneNumber = ___PhoneNumberTextBox_.Text,
                            Address = ___AdddressTextBox_.Text,
                            PostalCode = ___PostalCodeTextBox_.Text
                        });
                        if (resultPost.Succes) {
                            MessageBox.Show("Ajout du producteur avec succes");
                        }
                        else {
                            MessageBox.Show(string.Format("Une erreur est survenue lors de l'ajout du producteur \nErreur : {0}", resultPost.Error));
                        }
                        break;
                    case QueryTypeEnum.Modification:
                        if (___ProducersListView_.SelectedItem == null) {
                            MessageBox.Show("Veuillez selectionner le producteur dont vous souhaitez mettre à jour les informations dans la section gauche de la fenettre");
                        }
                        else {
                            Response<DtoProducer> resultPut = await Service.Put(new Producer() {
                                FirstName = ___FirstNameTextBox_.Text,
                                LastName = ___LastNameTextBox_.Text,
                                CompagnieName = ___CompagnieNameTextBox_.Text,
                                Email = ___EmailTextBox_.Text,
                                PhoneNumber = ___PhoneNumberTextBox_.Text,
                                Address = ___AdddressTextBox_.Text,
                                PostalCode = ___PostalCodeTextBox_.Text
                            }, ((DtoProducer)___ProducersListView_.SelectedItem).Id.ToString());
                            if (resultPut.Succes) {
                                MessageBox.Show("Modification du producteur avec succes");
                            }
                            else {
                                MessageBox.Show(string.Format("Une erreur est survenue lors de la modification du producteur \nErreur : {0}", resultPut.Error));
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
