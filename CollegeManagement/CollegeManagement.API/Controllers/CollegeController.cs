using CollegeManagement.API.DTOs;
using CollegeManagement.API.Model;
using CollegeManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService _service;

        public CollegeController(
            ICollegeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponse
            {
                Success = true,
                Data = await _service.GetAll()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(new ApiResponse
            {
                Success = true,
                Data = await _service.GetById(id)
            });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(
            CollegeDto dto)
        {
            await _service.Add(dto);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "College Added"
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(
            int id,
            CollegeDto dto)
        {
            await _service.Update(id, dto);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "College Updated"
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(
            int id)
        {
            await _service.Delete(id);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "College Deleted"
            });
        }
    }
}
