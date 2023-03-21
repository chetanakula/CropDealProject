using CropDealProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Repository
{
    public class InvoiceRepository : IInvoiceRepository<Invoice>
    {
        private readonly CropDealDataBaseContext _dbContext;
        public InvoiceRepository(CropDealDataBaseContext dbContext) => this._dbContext = dbContext;

        #region Add
        public async Task<Invoice> Add(Invoice entity)
        {
            try
            {
                var invoice = new Invoice()
                {
                    InvoiceId = entity.InvoiceId,
                    CropSaleId=entity.CropSaleId,
                    UserId=entity.UserId,
                    OrderDate=entity.OrderDate,
                    
                    CropName = entity.CropName,
                    CropType=entity.CropType,
                    CropQty=entity.CropQty,
                    OrderTotal=entity.OrderTotal,
                    Review=entity.Review,
                    // CropImage = entity.CropImage
                };
                _dbContext.Invoices.Add(invoice);
                await _dbContext.SaveChangesAsync();
                return invoice;
            }
            catch
            {
                return null;
            }
            //throw new NotImplementedException();
        }

        #endregion


        #region GetById
        public async Task<Invoice> GetById(int id)
        {
            try
            {
                var invoice = await _dbContext.Invoices.Where(i => i.InvoiceId == id).Select(i => new Invoice()
                {
                    InvoiceId = i.InvoiceId,
                    CropSaleId=i.CropSaleId,
                    UserId=i.UserId,
                    OrderDate = i.OrderDate,
                    
                    CropName = i.CropName,
                    CropQty = i.CropQty,
                    OrderTotal = i.OrderTotal,
                    Review = i.Review
                }).FirstOrDefaultAsync();
                return invoice;
            }
            catch
            {
                throw;
            }
            //  throw new NotImplementedException();
        }
        #endregion

        


        #region Edit

        public async Task<Invoice> Edit(Invoice entity)
        {
            try
            {
                var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceId == entity.InvoiceId);
                if (invoice != null)
                {
                    invoice.InvoiceId = entity.InvoiceId;
                    invoice.CropSaleId = entity.CropSaleId;
                    invoice.UserId = entity.UserId;
                    invoice.OrderDate = entity.OrderDate;
                    
                    invoice.CropName = entity.CropName;
                    invoice.CropQty = entity.CropQty;
                    invoice.OrderTotal = entity.OrderTotal;
                    invoice.Review = entity.Review;
                    _dbContext.SaveChanges();
                }
                return invoice;
            }
            catch
            {
                return null;
            }
            // throw new NotImplementedException();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            try
            {
                var invoice = new Invoice() { InvoiceId = id };
                _dbContext.Invoices.Remove(invoice);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            //throw new NotImplementedException();
        }

        #endregion
        #region ViewAll
        public async Task<IEnumerable<Invoice>> ViewInvoices()
        {
            try
            {
                return await _dbContext.Invoices.ToListAsync();
                throw new NotImplementedException();
            }
            catch
            {
                return Enumerable.Empty<Invoice>();
            }
        }
# endregion 

        #region Save
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
            //  throw new NotImplementedException();
        }

        #endregion
    }
}
