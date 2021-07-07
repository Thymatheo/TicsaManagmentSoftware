using System.Collections.Generic;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.DTO.Gamme;

namespace TicsaManagmentSoftware.APIHelper.Services.Interfaces {
    public interface IGammeService : IGeneriqueService<DtoGamme> {
        Task<Response<IEnumerable<DtoGamme>>> GetByGammeType(string route);
        Task<Response<IEnumerable<DtoGamme>>> GetByProducer(string route);
    }
}