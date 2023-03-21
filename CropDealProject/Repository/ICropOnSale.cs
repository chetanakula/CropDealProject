using CropDealProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Repository
{
    public interface ICropOnSale
    {
        #region Function Declaration
        Task<IEnumerable<CropOnSale>> GetAll();
        Task<CropOnSale> GetById(int id); Task<CropOnSale> Insert(CropOnSale entity);
        // Task Edit(int id, Crop entity);
        Task<CropOnSale> Edit(int id, CropOnSale entity);
        // Task Delete(Crop entity);
        Task Delete(int id);
        Task Save();
        #endregion
    }
}
