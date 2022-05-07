﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawl1
{
    public class Product
    {
        string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //bool IsAvailable { get; set; }
        public float Price { get; set; }
        //int Quantity { get; set; }
        public List<string> Images { get; set; }
        //public string Image { get; set; }
      
     

        public void printProduct(Product pro)
        {
            Console.WriteLine(pro.ID);
            Console.WriteLine(pro.Name);
            Console.WriteLine(pro.Description);
            Console.WriteLine(pro.Price);
        }

    }
}
