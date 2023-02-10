using Application.Commons.Bases;
using Application.Dtos.Response;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClubApplication
    {
        Task<BaseResponse<BaseEntityResponse<ClubResponseDto>>> ListClub(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<ClubSelectResponseDto>>> ListSelectClubs();
        Task<BaseResponse<ClubResponseDto>> ClubById(int ClubId);
    }
}
