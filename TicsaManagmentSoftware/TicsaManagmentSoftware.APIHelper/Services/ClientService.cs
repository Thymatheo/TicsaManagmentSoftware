using TicsaManagmentSoftware.APIHelper.DTO.Clients;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper.Services {
    public class ClientService : GeneriqueService<DtoClient>, IClientService {
        public ClientService(HelperConfig config) : base(config, "Client") {
        }
    }
}
