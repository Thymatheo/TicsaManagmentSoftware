using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicsaManagmentSoftware.APIHelper.Services.Interfaces {
    public interface IGeneriqueService<U> where U : class {
        Task<Response<U>> Delete(string route);
        Task<Response<IEnumerable<U>>> GetAll();
        Task<Response<U>> GetById(string route);
        Task<Response<U>> Post(object param);
        Task<Response<U>> Put(object param, string route);
    }
}