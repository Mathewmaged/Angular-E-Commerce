using apiProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace apiProject.Dto
{
    public class order
    {
        public List<OrderUserProduct> item = new List<OrderUserProduct> { };
        public string CustomerName { get; set; }
        public int TotalOrderCash { get; set; }
    }
}