using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PurchaseTracker.BusinessLogic.Contracts;
using PurchaseTracker.Model;

namespace PurchaseTracker.Web.Controllers
{
    public class CategoryController : ApiController
    {
        ICategoryLogic categoryLogic;
        public CategoryController(ICategoryLogic categoryLogic)
        {
            this.categoryLogic = categoryLogic;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var result = this.categoryLogic.GetAll();
            return result;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}