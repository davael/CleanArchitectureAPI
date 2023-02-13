using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistences.Interfaces
{
    public interface IClubRepository: IGenericRepository<Club>
    {
        Task<BaseEntityResponse<Club>> ListClubes(BaseFilterRequest filters);
    }
}
