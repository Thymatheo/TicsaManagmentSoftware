using TicsaManagmentSoftware.APIHelper.DTO.GammeType;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper.Services {
    public class GammeTypeService : GeneriqueService<DtoGammeType>, IGammeTypeService {
        public GammeTypeService(HelperConfig config) : base(config, "GammeType") {
        }
    }
}
