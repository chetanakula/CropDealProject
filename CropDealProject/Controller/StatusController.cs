using CropDealProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {


        private readonly CropDealDataBaseContext _dbcontext;
        public StatusController(CropDealDataBaseContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult ChangeUserStatus(ChangeStatus user)
        {
            try
            {
                (from u in _dbcontext.UserProfiles
                 where u.UserId == user.userId
                 select u).ToList()
                        .ForEach(x => x.UserStatus = user.userStatus);

                _dbcontext.SaveChanges();
                return Ok();
            }
            catch
            {
                throw;
            }
        }
    }
}
