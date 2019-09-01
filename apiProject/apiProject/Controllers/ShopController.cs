using apiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using apiProject.Migrations;

namespace apiProject.Controllers
{
    public class ShopController : ApiController
    {
        ApplicationDbcontext shop = new ApplicationDbcontext();
        // GET: api/Shop
        [HttpGet]
        [Route("api/Shopq")]
        [AllowAnonymous]
        public IEnumerable<Product> GetCourses()
        {
            return shop.Products.Include(c => c.Category).AsEnumerable();
        }
        [HttpGet]
        [Route("api/Shop")]
        [AllowAnonymous]
        public IHttpActionResult GetShop()
        {
            var All = (from products in shop.Products
                       select products).ToList() ;
            List<PrdModel> PrdData = new List<PrdModel>();

            foreach (var item in All)
            {
                PrdModel stDatas = new PrdModel();
                stDatas.ID = item.ID;
                stDatas.Name = item.Name;
                stDatas.Images = item.Images;
                stDatas.Height = item.Height;
                stDatas.Weight = item.Weight;
                stDatas.Width = item.Width;
                stDatas.Depth = item.Depth;
                stDatas.Price = item.Price;
                stDatas.Quantity = item.Quantity;
                stDatas.Description = item.Description;
                Catagory query = (from products in shop.Catagories
                             where products.ID==item.CategoryID
                             select products).FirstOrDefault();
                stDatas.cate_id = query.ID;
                stDatas.cate_name = query.Name;

                PrdData.Add(stDatas);
            }
            return Ok(PrdData);
        }
        [HttpGet]
        [Route("api/Cate")]
        [AllowAnonymous]
        public IHttpActionResult Getcate()
        {
            var All = (from products in shop.Catagories
                       select products).ToList();
      
            return Ok(All);
        }

        // GET: api/Shop/5
        [HttpGet]
        [Route("api/Product/{id}")]
        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            Product product = (from i in shop.Products
                                where i.ID == id
                                select i).FirstOrDefault();
            return Json(product);
        }

        // POST: api/Shop
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Shop/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shop/5
        public void Delete(int id)
        {
        }
    }
}
