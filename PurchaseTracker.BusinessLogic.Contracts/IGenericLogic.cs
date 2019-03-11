using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseTracker.BusinessLogic
{
    public interface IGenericLogic<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Save(TEntity item);
        void Save(IEnumerable<TEntity> items);
        void Delete(int id);
    }
}
