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

        public async Task<IEnumerable<Club>> ListSelectClubes()
        {
            var clubes = await _context.Clubs.Where(x => x.Active == true).AsNoTracking().ToListAsync();
            return clubes;
        }
        public async Task<Club> GetClubById(int clubID)
        {
            var club = await _context.Clubs.AsNoTracking().FirstOrDefaultAsync(x => x.ClubID.Equals(clubID));
            return club;
        }
        public async Task<bool> RegisterClub(Club club)
        {
            await _context.AddAsync(club);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public Task<bool> EditClub(Club club)
        {
            throw new NotImplementedException();
        }
    }
}
