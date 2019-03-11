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
    public class TransactionLogic : ITransactionLogic
    {
        private ITransactionRepository transactionRepo;

        public TransactionLogic(ITransactionRepository transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }

        public void Delete(int id)
        {
            try
            {
                var item = this.transactionRepo.FindById(id);
                this.transactionRepo.Remove(item);
                this.transactionRepo.Save();
            }
            catch { throw; }
        }

        public Transaction Get(int id)
        {
            return this.transactionRepo.FindById(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return this.transactionRepo.GetAll();
        }

        public void Save(Transaction item)
        {
            try
            {
                this.transactionRepo.AddOrUpdate(item);
                this.transactionRepo.Save();
            }
            catch { throw; }
        }

        public void Save(IEnumerable<Transaction> items)
        {
            try
            {
                foreach (var item in items)
                {
                    this.transactionRepo.AddOrUpdate(item);
                }
                this.transactionRepo.Save();
            }
            catch { throw; }
        }
    }
}
