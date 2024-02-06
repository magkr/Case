using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/userprofiles")]
    [ApiController]
    public class UserProfileController : ControllerBase, IUserProfileController
    {
        private readonly IUserService _userService;

        public UserProfileController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserProfileDto>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] UserProfileDto userProfileDto)
        {
            try
            {
                await _userService.AddUser(userProfileDto);
                return CreatedAtAction(nameof(GetUserByEmail), new { email = userProfileDto.Email }, userProfileDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{email}")]
        public async Task<ActionResult> UpdateUser(string email, [FromBody] UserProfileDto userProfileDto)
        {
            if (email != userProfileDto.Email)
            {
                return BadRequest("Mismatched email in the request body.");
            }

            await _userService.UpdateUser(userProfileDto);
            return NoContent();
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> DeleteUser(string email)
        {
            await _userService.DeleteUser(email);
            return NoContent();
        }
    }
}