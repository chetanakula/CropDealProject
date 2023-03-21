using CropDealProject.Models;
using CropDealProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Services
{
    public class CropOnSaleService
    {
        ICropOnSale _repository;
        public CropOnSaleService(ICropOnSale repo)
        {
            _repository = repo;
        }

        #region Insert in Service
        public async Task<CropOnSale> Insert(CropOnSale entity)
        {
            return await _repository.Insert(entity);


            //throw new NotImplementedException();
        }
        #endregion

        #region Delete in Service
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
            // throw new NotImplementedException();
        }

        #endregion

        #region Edit in service
        public async Task Edit( int id,CropOnSale entity)
        {
            await _repository.Edit(id,entity);
            //throw new NotImplementedException();
        }

        #endregion

        #region GetAll
        public async Task<IEnumerable<CropOnSale>> GetAll()
        {
            return await _repository.GetAll();
            //throw new NotImplementedException();
        }

        #endregion

        #region GetById
        public async Task<CropOnSale> GetById(int id)
        {
            return await _repository.GetById(id);
            //   throw new NotImplementedException();
        }

        #endregion

        #region Save
        public async Task Save()
        {
            await _repository.Save();
            //throw new NotImplementedException();
        }
        #endregion
    }
}
