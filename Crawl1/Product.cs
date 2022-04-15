using System;
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
        string Description { get; set; }
        bool IsAvailable { get; set; }
        float Price { get; set; }
        int Quantity { get; set; }
        string Image { get; set; }
        Category CategoryName { get; set; }
        string priceCurrency { get; set; }
        bool isNewProduct { get; set; }

        void printProduct(Product pro)
        {
            Console.WriteLine(pro.ID);
            Console.WriteLine(pro.Name);
            Console.WriteLine(pro.Description);
            Console.WriteLine(pro.Price);
            Console.WriteLine(pro.Quantity);
            Console.WriteLine(pro.isNewProduct);
            Console.WriteLine(pro.priceCurrency);
            Console.WriteLine(pro.CategoryName);
           
        }

    }
}
