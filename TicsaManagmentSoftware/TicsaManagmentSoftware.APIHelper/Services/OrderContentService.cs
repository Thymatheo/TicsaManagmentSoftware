using System.Collections.Generic;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.DTO.OrderContent;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper.Services {
    public class OrderContentService : GeneriqueService<DtoOrderContent>, IOrderContentService {
        public OrderContentService(HelperConfig config) : base(config, "OrderContent") {
        }

        public async Task<Response<IEnumerable<DtoOrderContent>>> GetByorder(string route) {
            return await RequestHttpGet<Response<IEnumerable<DtoOrderContent>>>("order/" + route);
        }
    }
}
