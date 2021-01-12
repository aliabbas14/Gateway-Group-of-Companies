using Newtonsoft.Json;
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
        /*
         This api returns the list of categories of product.
             */
        public IHttpActionResult Get()
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data=context.tbl_category.Select(x=>new { x.category_id,x.name }).ToList();                    
                    return Ok(JsonConvert.SerializeObject(data));
                }
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }
    }
}
