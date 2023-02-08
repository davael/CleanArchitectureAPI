using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistences.Interfaces
{
    public interface IClubRepository
    {
        Task<BaseEntityResponse<Club>> ListClubes(BaseFilterRequest filters);
        Task<IEnumerable<Club>> ListSelectClubes();
        Task<Club> GetClubById(int clubID);
        Task<bool> RegisterClub (Club club);
        Task<bool> EditClub(Club club);

    }
}
