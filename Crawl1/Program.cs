using Crawl1;
using System.Text.RegularExpressions;

namespace Crawler2
{
    public class Program : Product
    {
        static async Task Main(string[] args)
        {
            //// http client
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            var html = await client.GetStringAsync("https://anvatchumanh.com/");

            ////get list url product from source html
            List<Product> listProduct = new List<Product>();   // list link all products of website
            string patternListLinkProduct = "product-name(.*?)<a href=\"(.*?)\"";
            MatchCollection matches = Regex.Matches(html, patternListLinkProduct, RegexOptions.Multiline);

            //path
            string path = "D:\\AnVatChuManh\\Crawl1\\Crawl_15.txt";
            /*await File.WriteAllTextAsync(path,"@Name@Price@Description@Image");*/

            System.IO.StreamWriter file = new System.IO.StreamWriter(path, false, System.Text.Encoding.UTF8);

            //write header
            string format = "@ID@Type@SKU@Name@Published@Is featured?@Visibility in catalog@Short description@Description@Date sale price starts@Date sale price ends@Tax status@Tax class@In stock?@Stock@Low stock amount@Backorders allowed?@Sold individually?@Weight(kg)@Length(cm)@Width(cm)@Height(cm)@Allow customer reviews?@Purchase note@Sale price@Regular price@Categories@Tags@Shipping class@Images@Download limit@Download expiry days@Parent@Grouped products@Upsells@Cross-sells@External URL@Button text@Position@Attribute 1 name@Attribute 1 value(s)@Attribute 1 visible@Attribute 1 global@Attribute 1 default\n";

/*            string header = "@ID	@Type	@SKU	@Name	@Published	@Is featured?	@Visibility in catalog	@Short description	@Description	@Date sale price starts	@Date sale price ends	@Tax status	@Tax class	@In stock?	@Stock	@Low stock amount	@Backorders allowed?	@Sold individually?	@Weight(kg)	@Length(cm)	@Width(cm)	@Height(cm)	@Allow customer reviews?	@Purchase note	@Sale price	@Regular price	@Categories	@Tags	@Shipping class	@Images	@Download limit	@Download expiry days	@Parent	@Grouped products	@Upsells	@Cross-sells	@External URL	@Button text	@Position	@Attribute 1 name	@Attribute 1 value(s)	@Attribute 1 visible	@Attribute 1 global	@Attribute 1 default";
*/           
            string header = format;

            //export header to file
           /* await File.WriteAllTextAsync(path, header.ToString());*/
           file.Write(header);

            foreach (Match match in matches)
            {
                // url of each product          
                string urlItem = "https://anvatchumanh.com" + match.Groups[2].Value;
                Product product = new Product();

                //// get source html of item from url product
                var htmlItem = await client.GetStringAsync(urlItem);
                /*Console.WriteLine(htmlItem);*/


                //Pattern
                string patternItem_Name = "title-head(.*?)>(.*?)</h1";
                string patternItem_Description = "metadescription\":\"(.*?)\"";
                string patternItem_Price = "itemprop='price' content='(.*?)'";
                string patternItem_Image = "data-image=\"(.*?)\" data-zoom-image(.*?)data-rel";

                //Regex
                //Regex name
                product.Name = Regex.Match(htmlItem, patternItem_Name).Groups[2].Value;

                //Regex price, change type of price from string to integer
                var tempPrice = Regex.Match(htmlItem, patternItem_Price).Groups[1].Value;
                product.Price = Convert.ToInt32(tempPrice != "" ? tempPrice : 0);

                //regex list imgae
                MatchCollection matchesImage = Regex.Matches(htmlItem, patternItem_Image);
                product.Images = new List<string>();
                foreach (Match matchImage in matchesImage)
                {
                    var temp = matchImage.Groups[1].Value;
                    product.Images.Add(temp);
                }

                //check description not null
                if (Regex.Match(htmlItem, patternItem_Description).Groups[1].Value == "")
                    product.Description = "null";
                else
                    product.Description = Regex.Match(htmlItem, patternItem_Description).Groups[1].Value;
           
                Console.WriteLine("cho xiu sap xong r");
         
                //write data
                string data = format.Replace("@ID", "@\"\"");
                data = data.Replace("@Type", "@simple");
                data = data.Replace("@SKU", "@\"\"");
                data = data.Replace("@Name","@\""+ product.Name + "\"");
                data = data.Replace("@Published", "@1");
                data = data.Replace("@Is featured?", "@\"0\"");
                data = data.Replace("@Visibility in catalog", "@visible");
                data = data.Replace("@Short description", "@\"\"");
                data = data.Replace("@Description", "@\""+product.Description+"\"");
                data = data.Replace("@Date sale price starts", "@\"\"");
                data = data.Replace("@Date sale price ends", "@\"\"");
                data = data.Replace("@Tax status", "@taxable");
                data = data.Replace("@Tax class", "@\"\"");
                data = data.Replace("@In stock?", "@\"1\"");
                data = data.Replace("@Stock", "@\"\"");
                data = data.Replace("@Low stock amount", "@\"\"");
                data = data.Replace("@Backorders allowed?", "@\"0\"");
                data = data.Replace("@Sold individually?", "@\"0\"");
                data = data.Replace("@Weight(kg)", "@\"\"");
                data = data.Replace("@Length(cm)", "@\"\"");
                data = data.Replace("@Width(cm)", "@\"\"");
                data = data.Replace("@Height(cm)", "@\"\"");
                data = data.Replace("@Allow customer reviews?", "@\"1\"");
                data = data.Replace("@Purchase note", "@\"\"");
                data = data.Replace("@Sale price", "@\"\"");
                data = data.Replace("@Regular price", "@\""+product.Price + "\"");
                data = data.Replace("@Categories", "@\"\"");
                data = data.Replace("@Tags", "@\"\"");
                data = data.Replace("@Shipping class", "@\"\"");
                string tempListImage="";
                foreach (string image in product.Images)
                    tempListImage += ""+image + ",";           
                data = data.Replace("@Images", "@\""+tempListImage+"\"");
                data = data.Replace("@Download limit", "@\"\"");
                data = data.Replace("@Download expiry days", "@\"\"");
                data = data.Replace("@Parent", "@\"\"");
                data = data.Replace("@Grouped products", "@\"\"");
                data = data.Replace("@Upsells", "@\"\"");
                data = data.Replace("@Cross-sells", "@\"\"");
                data = data.Replace("@External URL", "@\"\"");
                data = data.Replace("@Button text", "@\"\"");
                data = data.Replace("@Position", "@\"0\"");
                data = data.Replace("@Attribute 1 name", "@\"\"");
                data = data.Replace("@Attribute 1 value(s)", "@\"\"");
                data = data.Replace("@Attribute 1 visible", "@\"\"");
                data = data.Replace("@Attribute 1 global", "@\"\"");
                data = data.Replace("@Attribute 1 default", "@\"\""+"\n");

               // await File.AppendAllTextAsync(path, data.ToString()); 
               file.Write(data);

               // write file each product to .txt
               /*  string tempList;
                tempList = "@"+product.Name + "@" + product.Price + "@" + product.Description + "@";
                 foreach (string image in product.Images)
                     tempList += image + ",";
                 await File.AppendAllTextAsync(path, tempList.ToString());*/

               System.Threading.Thread.Sleep(5000);
            }
            Console.WriteLine("CHUC MUNG LINH DA XONG DEADLINE");
            }
    }
}
