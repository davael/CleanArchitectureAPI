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
using Utilities.Static;

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

        public async Task<BaseResponse<BaseEntityResponse<ClubResponseDto>>> ListClub(BaseFilterRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ClubResponseDto>>();
            var clubs= await this._unitOfWork.Club.ListClubes(filters);

            if(clubs is not null)
            {
                response.IsSuccess= true;
                response.Data= _mapper.Map<BaseEntityResponse<ClubResponseDto>>(clubs);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else { 
                response.IsSuccess= false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public Task<BaseResponse<IEnumerable<ClubSelectResponseDto>>> ListSelectClubs()
        {
            throw new NotImplementedException();
        }
    }
}
