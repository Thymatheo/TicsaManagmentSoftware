using System.Collections.Generic;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.DTO.Order;

namespace TicsaManagmentSoftware.APIHelper.Services.Interfaces {
    public interface IOrderService : IGeneriqueService<DtoOrder> {
        Task<Response<IEnumerable<DtoOrder>>> GetByClient(string route);
    }
}