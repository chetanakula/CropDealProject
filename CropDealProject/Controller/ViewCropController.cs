using CropDealProject.Models;
using CropDealProject.Services;
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
    public class ViewCropController : ControllerBase
    {
        private readonly CropViewService _cropview;

        public ViewCropController(CropViewService cropview)
        {

            _cropview = cropview;

        }
        #region getcrops
        [Authorize(Roles = "Dealer")]

        [HttpGet]
        public List<ViewCrop> GetCrops()
        {
            return _cropview.CropsView();

        }
        #endregion
    }
}
