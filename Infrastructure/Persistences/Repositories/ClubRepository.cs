using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences.Repositories
{
    public class ClubRepository : GenericRepository<Club>, IClubRepository
    {
        private readonly ClubesContext _context;
        public ClubRepository(ClubesContext context)
        {
            _context = context;

        }
        public async Task<BaseEntityResponse<Club>> ListClubes(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Club>();
            var clubes = _context.Clubs.AsNoTracking().AsQueryable();

            if(filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter)) 
            {
                switch(filters.NumFilter)
                {
                    case 1:
                        clubes= clubes.Where(x => x.ClubDes.Contains(filters.TextFilter)); break;
                }
            }
            if(filters.StateFilter is not null)
            {
                clubes = clubes.Where(x => x.Active.Equals(filters.StateFilter));
            }
            response.TotalRecords = await clubes.CountAsync();
            response.Items= await Ordering(filters,clubes).ToListAsync();
            return response;
        }

        public Task<IEnumerable<Club>> ListSelectClubes()
        {
            throw new NotImplementedException();
        }
        public Task<Club> GetClubById(int clubID)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RegisterClub(Club club)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditClub(Club club)
        {
            throw new NotImplementedException();
        }
    }
}
