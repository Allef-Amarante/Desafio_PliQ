using DesafioPliQ.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioPliQ.Repositories
{
    public interface IEstagiosRepository
    {
        Task<IEnumerable<EstagiosCRM>> ListOrder();

        Task<EstagiosCRM> Get(int id);

        Task<EstagiosCRM> Create(EstagiosCRM estagios);

        Task<EstagiosCRM> Delete(int id);

        Task<EstagiosCRM> Update(EstagiosCRM estagios);

    }
}
