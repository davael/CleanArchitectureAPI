using Application.Commons.Bases;
using Application.Dtos.Response;
using Application.Interfaces;
using Application.Validators.Club;
using AutoMapper;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClubApplication : IClubApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ClubValidator _validator;

        public ClubApplication(IUnitOfWork unitOfWork, IMapper mapper, ClubValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public Task<BaseResponse<ClubResponseDto>> ClubById(int ClubId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<BaseEntityResponse<ClubResponseDto>>> ListClub(BaseFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<ClubSelectResponseDto>>> ListSelectClubs()
        {
            throw new NotImplementedException();
        }
    }
}
