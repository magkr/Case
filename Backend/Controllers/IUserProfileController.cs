using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Services;

namespace Backend.Controllers
{
    public interface IUserProfileController
    {
        Task<ActionResult<UserProfileDto>> GetUserByEmail(string email);

        Task<ActionResult> AddUser([FromBody] UserProfileDto userProfileDto);

        Task<ActionResult> UpdateUser(string email, [FromBody] UserProfileDto userProfileDto);

        Task<ActionResult> DeleteUser(string email);
    }
}