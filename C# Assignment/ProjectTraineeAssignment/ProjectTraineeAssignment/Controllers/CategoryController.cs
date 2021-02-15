using Newtonsoft.Json;
using ProjectTraineeAssignment.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectTraineeAssignment.Controllers
{
    public class CategoryController : ApiController
    {
        ICategory _cat;
        public CategoryController(ICategory cat)
        {
            _cat = cat;
        }
        /*
         This api returns the list of categories of product.
             */
        public IHttpActionResult Get()
        {
            
            return Ok(JsonConvert.SerializeObject(_cat.Get()));
           
        }
    }
}
