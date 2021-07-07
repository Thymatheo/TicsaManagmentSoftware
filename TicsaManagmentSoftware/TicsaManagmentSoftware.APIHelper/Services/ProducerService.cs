using TicsaManagmentSoftware.APIHelper.DTO.Producer;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper.Services {
    public class ProducerService : GeneriqueService<DtoProducer>, IProducerService {
        public ProducerService(HelperConfig config) : base(config, "Producer") {
        }
    }
}
