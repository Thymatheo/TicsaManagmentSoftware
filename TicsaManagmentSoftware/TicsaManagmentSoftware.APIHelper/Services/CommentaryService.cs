using System.Collections.Generic;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.DTO.Commentary;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper.Services {
    public class CommentaryService : GeneriqueService<DtoCommentary>, ICommentaryService {
        public CommentaryService(HelperConfig config) : base(config, "Commentary") {
        }
        public async Task<Response<IEnumerable<DtoCommentary>>> GetByClient(string route) {
            return await RequestHttpGet<Response<IEnumerable<DtoCommentary>>>("client/" + route);
        }
    }
}
