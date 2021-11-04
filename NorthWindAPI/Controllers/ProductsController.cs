using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("GetAll")]
        public List<Product> GetAll()
        {
            List<Product> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Products.ToList();
            }
            return result;
        }

        [HttpGet("{id}")]
        public Product GetByID(int id)
        {
            Product result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Products.Find(id);
            }
            return result;
        }
    }

}
