using CropDealProject.Models;
using CropDealProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Services
{
    public class InvoiceService
    {
        IInvoiceRepository<Invoice> _repository;
        public InvoiceService(IInvoiceRepository<Invoice> repo)
        {
            _repository = repo;
        }

        #region GetById
        public async Task<Invoice> GetById(int id)
        {
            return await _repository.GetById(id);
            //   throw new NotImplementedException();
        }
        #endregion

        #region Edit
        public async Task Edit( int id,Invoice entity)
        {
            await _repository.Edit(entity);
            //throw new NotImplementedException();
        }

        #endregion

        #region Delete
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
            // throw new NotImplementedException();
        }

        #endregion

        #region Save
        public async Task Save()
        {
            await _repository.Save();
            //throw new NotImplementedException();
        }
        #endregion

        #region Add
        public async Task<Invoice> Add(Invoice entity)
        {
            return await _repository.Add(entity);


            //throw new NotImplementedException();
        }
        #endregion
        #region GetAll
        public async Task<IEnumerable<Invoice>> GetAll()
        {
            return await _repository.ViewInvoices();
            //throw new NotImplementedException();
        }
        #endregion
    }
}

