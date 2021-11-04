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
    public class OrdersController : ControllerBase
    {
        [HttpGet("GetAll")]
        public List<Order> GetAll()
        {
            List<Order> result = null;
            using(NorthwindContext context = new NorthwindContext())
            {
                result = context.Orders.ToList();
            }
            return result;
        }

        [HttpGet("{id}")]
        public Order GetByID(int id)
        {
            Order result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Orders.Find(id);
            }
            return result;
        }
        [HttpDelete("Delete/{id}")]
        public Order DeleteOrder(int id)
        {
            Order result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Orders.Find(id);
                context.Orders.Remove(result);
                context.SaveChanges();
            }
            return result;
        }

        [HttpPost("AddOrder")]
        public Order AddOrder(string id, string address )
        {
            Order newOrder = null;
            newOrder.CustomerId = id;
            newOrder.ShipAddress = address;
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Orders.Add(newOrder);
            }
            return newOrder;
        }
    }


}
