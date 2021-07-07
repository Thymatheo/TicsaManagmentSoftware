using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TicsaManagmentSoftware.APIHelper.DTO.Clients;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.ViewModel {
    public class ClientViewModel : INotifyPropertyChanged {
        private IEnumerable<DtoClient> _Clients;

        public ClientViewModel() {

        }

        public IEnumerable<DtoClient> Clients {
            get {
                return _Clients;
            }
            set {
                if (value != _Clients) {
                    _Clients = value;
                    OnPropertyChanged("Clients");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
