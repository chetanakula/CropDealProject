using CropDealProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Repository
{
    #region declaration
    public interface IViewCropRepository
    {
        List<ViewCrop> ViewCrops();
    }
    #endregion
}
