using System.Collections.Generic;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.DTO.OrderContent;

namespace TicsaManagmentSoftware.APIHelper.Services.Interfaces {
    public interface IOrderContentService : IGeneriqueService<DtoOrderContent> {
        Task<Response<IEnumerable<DtoOrderContent>>> GetByorder(string route);
    }
}