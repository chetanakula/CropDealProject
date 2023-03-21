using CropDealProject.Models;
using CropDealProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        // private readonly IRepository<UserProfile> _userRepository ;
        public readonly UserProfileService _userProfileService;
        public UserProfileController(UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        #region Register
        [HttpPost]
        public async Task<IActionResult> Register([Bind()] UserProfile entity)
        {

            await _userProfileService.Register(entity);
            await _userProfileService.Save();
            return (Ok());


        }
        #endregion

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var userprofiles = await _userProfileService.GetAll();
            return Ok(userprofiles);


        }
        #endregion

        #region GetById
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var userProfile = await _userProfileService.GetById(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);

        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserProfile userProfile)
        {

            await _userProfileService.Update(userProfile);
            await _userProfileService.Save();
            return Ok(userProfile);

        }
        #endregion


    }
}
