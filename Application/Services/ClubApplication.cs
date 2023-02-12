using Application.Commons.Bases;
using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Application.Validators.Club;
using AutoMapper;
using Domain.Entities;
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
        public async Task<BaseResponse<ClubResponseDto>> ClubById(int ClubId)
        {
            var response = new BaseResponse<ClubResponseDto>();
            var club= await _unitOfWork.Club.GetClubById(ClubId);

            if(club is not null)
            {
                response.IsSuccess= true;
                response.Data=_mapper.Map<ClubResponseDto>(club);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else { 
                response.IsSuccess= false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;

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

        public async Task<BaseResponse<IEnumerable<ClubSelectResponseDto>>> ListSelectClubs()
        {
            var response = new BaseResponse<IEnumerable<ClubSelectResponseDto>>();
            var clubs = await _unitOfWork.Club.ListSelectClubes();
            if(clubs is not null) {
                response.IsSuccess= true;
                response.Data= _mapper.Map<IEnumerable<ClubSelectResponseDto>>(clubs);
                response.Message= ReplyMessage.MESSAGE_QUERY;
            } else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterClub(ClubRequestDto clubRequest)
        {
            var response= new BaseResponse<bool>();
            var validationResult= await _validator.ValidateAsync(clubRequest);
            if(validationResult.Errors.Count>0)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }
            var club = _mapper.Map<Club>(clubRequest);
            response.Data= await _unitOfWork.Club.RegisterClub(club);
            if (response.Data)
            {
                response.IsSuccess= true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }
    }
}
