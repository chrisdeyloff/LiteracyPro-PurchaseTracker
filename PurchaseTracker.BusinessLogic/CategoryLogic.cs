using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseTracker.DataAccess.Contracts.Repository;
using PurchaseTracker.BusinessLogic.Contracts;
using PurchaseTracker.Model;

namespace PurchaseTracker.BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryRepository categoryRepo;

        public CategoryLogic(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public void Delete(int id)
        {
            try
            {
                var item = this.categoryRepo.FindById(id);
                this.categoryRepo.Remove(item);
                this.categoryRepo.Save();
            }
            catch { throw; }
        }

        public Category Get(int id)
        {
            return this.categoryRepo.FindById(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categoryRepo.GetAll();
        }

        public void Save(Category item)
        {
            try
            {
                this.categoryRepo.AddOrUpdate(item);
                this.categoryRepo.Save();
            }
            catch { throw; }
        }

        public void Save(IEnumerable<Category> items)
        {
            try
            {
                foreach (var item in items)
                {
                    this.categoryRepo.AddOrUpdate(item);
                }
                this.categoryRepo.Save();
            }
            catch { throw; }
        }
    }
}
