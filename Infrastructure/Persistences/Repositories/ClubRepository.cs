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
        public ClubRepository(ClubesContext context): base(context) { }

        public async Task<BaseEntityResponse<Club>> ListClubes(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Club>();
            var clubes = GetEntityQuery();

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

            if (filters.Sort is null) filters.Sort = "Id";
            response.TotalRecords = await clubes.CountAsync();
            response.Items= await Ordering(filters,clubes).ToListAsync();
            return response;
        }
    }
}
