using apiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiProject.Migrations
{
    public class PrdModel
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string Description { get; set; }
        public string Images { get; set; }
        public string cate_name { get; set; }
        public int cate_id { get; set; }

    }
}