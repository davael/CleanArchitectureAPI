using Application.Dtos.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubApplication _clubApplication;
        public ClubController(IClubApplication clubApplication)
        {
            _clubApplication = clubApplication;
        }
        [HttpPost]
        public async Task<IActionResult> ListClubs([FromBody] BaseFilterRequest filters)
        { 
            var response = await _clubApplication.ListClub(filters);
            return Ok(response);
        }
        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectClub()
        {
            var response = await _clubApplication.ListSelectClubs();
            return Ok(response);
        }
        [HttpGet("{clubId:int}")]
        public async Task<IActionResult> ClubById(int clubId)
        {
            var response = await _clubApplication.ClubById(clubId);
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterClub([FromBody] ClubRequestDto clubRequest)
        {
            var response= await _clubApplication.RegisterClub(clubRequest);
            return Ok(response);
        }
        
    }
}
