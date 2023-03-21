using CropDealProject.Models;
using CropDealProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Services
{
    public class CropViewService
    {
        private IViewCropRepository _repository;
        public CropViewService(IViewCropRepository repository)
        {
            _repository = repository;
        }
        #region viewcrops
        public List<ViewCrop> CropsView()
        {
            return _repository.ViewCrops();
        }
        #endregion
    }
}
