using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Repository
{
    public interface IInvoiceRepository<TEntity> where TEntity : class

    {
        #region Funtion Declaration

        
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> ViewInvoices();

        Task<TEntity> Add(TEntity entity);
        //Task edit(int id,invoice entity);
        Task<TEntity> Edit(TEntity entity);
        Task Delete(int id);
        Task Save();
        #endregion

    }
}
