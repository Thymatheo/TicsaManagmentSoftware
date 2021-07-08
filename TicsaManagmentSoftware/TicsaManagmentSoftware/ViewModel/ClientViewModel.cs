using System.Collections.Generic;
using System.ComponentModel;
using TicsaManagmentSoftware.APIHelper.DTO.Clients;

namespace TicsaManagmentSoftware.ViewModel {
    public class ClientViewModel : INotifyPropertyChanged {
        private IEnumerable<DtoClient> _Clients;

        public ClientViewModel() {

        }

        public IEnumerable<DtoClient> Clients {
            get => _Clients;
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
