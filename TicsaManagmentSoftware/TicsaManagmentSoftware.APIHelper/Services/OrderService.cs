using System.Collections.Generic;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.DTO.Order;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper.Services {
    public class OrderService : GeneriqueService<DtoOrder>, IOrderService {
        public OrderService(HelperConfig config) : base(config, "Order") {
        }

        public async Task<Response<IEnumerable<DtoOrder>>> GetByClient(string route) {
            return await RequestHttpGet<Response<IEnumerable<DtoOrder>>>("client/" + route);
        }
    }
}
