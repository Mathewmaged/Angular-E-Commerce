using apiProject.Dto;
using apiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiProject.Controllers
{
    public class OrderController : ApiController
    {
        private ApplicationDbcontext db = new ApplicationDbcontext();

        public IHttpActionResult GetOrders()
        {
            return Json(db.Orders.ToList());
        }

        public IHttpActionResult PostOrder(order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var x = (from i in db.Users
                     where i.UserName == order.CustomerName
                     select i.Id).FirstOrDefault();
            Orders ord = new Orders();
            ord.OrderUserProduct = order.item;
            ord.TotalOrderCash = order.TotalOrderCash;
            ord.CustomerId = x;
            db.Orders.Add(ord);
            db.SaveChanges();

            return Ok();
        }

    }
}
