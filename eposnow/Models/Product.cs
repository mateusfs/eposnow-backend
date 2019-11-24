using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eposnow.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public Category category { get; set; }

    }
}