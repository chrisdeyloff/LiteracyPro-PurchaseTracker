using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PurchaseTracker.BusinessLogic.Contracts;
using PurchaseTracker.Model;
using EntityFramework.Toolkit;

namespace PurchaseTracker.Web.Controllers
{
    public class TransactionController : ApiController
    {
        ITransactionLogic transactionLogic;
        public TransactionController(ITransactionLogic transactionLogic)
        {
            this.transactionLogic = transactionLogic;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            var result = this.transactionLogic.GetAll();
            return result;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Transaction value)
        {
            this.transactionLogic.Save(value);
        }

        // PUT api/<controller>
        public void Put([FromBody]Transaction value)
        {
            this.transactionLogic.Save(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            this.transactionLogic.Delete(id);
        }
    }
}