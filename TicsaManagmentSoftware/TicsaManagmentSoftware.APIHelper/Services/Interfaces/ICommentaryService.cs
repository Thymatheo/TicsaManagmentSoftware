using System.Collections.Generic;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.DTO.Commentary;

namespace TicsaManagmentSoftware.APIHelper.Services.Interfaces {
    public interface ICommentaryService : IGeneriqueService<DtoCommentary> {
        Task<Response<IEnumerable<DtoCommentary>>> GetByClient(string route);
    }
}