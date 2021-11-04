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
    public class SupplierController : ControllerBase
    {
        [HttpGet("GetAll")]
        public List<Supplier> GetAll()
        {
            List<Supplier> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Suppliers.ToList();
            }
            return result;
        }

        [HttpGet("{id}")]
        public Supplier GetByID(int id)
        {
            Supplier result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Suppliers.Find(id);
            }
            return result;
        }

        [HttpPost("AddSupplier")]
        public Supplier AddSupplier(int id, string name)
        {
            Supplier newSupplier = null;
            newSupplier.SupplierId = id;
            newSupplier.CompanyName = name;
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Orders.Add(newSupplier);
            }
            return newSupplier;
        }
    }
}
