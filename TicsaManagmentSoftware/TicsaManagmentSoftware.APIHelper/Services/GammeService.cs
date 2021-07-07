using System.Collections.Generic;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.DTO.Gamme;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper.Services {
    public class GammeService : GeneriqueService<DtoGamme>, IGammeService {
        public GammeService(HelperConfig config) : base(config, "Gamme") {
        }
        public async Task<Response<IEnumerable<DtoGamme>>> GetByGammeType(string route) {
            return await RequestHttpGet<Response<IEnumerable<DtoGamme>>>("type/" + route);
        }

        public async Task<Response<IEnumerable<DtoGamme>>> GetByProducer(string route) {
            return await RequestHttpGet<Response<IEnumerable<DtoGamme>>>("producer/" + route);
        }
    }
}
