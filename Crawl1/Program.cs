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
            List<string> linkProduct = new List<string>();   // list link all products of websitr
            string patternListLinkProduct = "product-name(.*?)<a href=\"(.*?)\"";
            MatchCollection matches = Regex.Matches(html, patternListLinkProduct, RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                // ex: /product/banh-bo
                linkProduct.Add("https://anvatchumanh.com"+match.Groups[2].Value);
                //Console.WriteLine(match.Groups[2].Value);
                // url of each product
                //string urlItem = "https://anvatchumanh.com" + match.Groups[2].Value;
            }


            //Console.WriteLine(linkProduct[1]);
            string urlItem = linkProduct[0];
            Product product = new Product();
            //// get source html of item from url product
            var htmlItem = await client.GetStringAsync(urlItem);
            //Console.WriteLine(htmlItem);
            string patternItemName = "title-head(.*?)>(.*?)</h1";
            Match itemName = Regex.Match(htmlItem, patternItemName, RegexOptions.Multiline);
            product.Name = itemName.Groups[2].Value;
            Console.WriteLine(product.Name);

            //viet 1 ham regex truyen vao html, pattern, regexoption


            //Console.WriteLine(listLinkProduct);
            /*  for (int i=0; i < listLinkProduct.Groups.Count; i++)
              {
                  string name = listLinkProduct.Groups[i].Value;
                  Console.WriteLine(i);
                  Console.WriteLine(name);
              }    */
            /*while (listLinkProduct.Success)
                 Console.WriteLine("Found '{0}' at position {1}.", listLinkProduct.Groups[2], listLinkProduct.Index);
 */

            /*var content = "https://anvatchumanh.com/";

            Regex regx = new Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);
            MatchCollection mactches = regx.Matches(content);
            foreach (Match match in mactches)
            {
                content = content.Replace(match.Value, "<a href='" + match.Value + "'>" + match.Value + "</a>");
            }
            Console.WriteLine(content);*/



            //Console.WriteLine(products.Count);
            //System.IO.StreamWriter writer = new System.IO.StreamWriter("D:\\tiki.csv", false, System.Text.Encoding.UTF8);
            //writer.WriteLine("ProductName\tImageLink");
            ////System.Threading.Thread.Sleep(10000);
            ///string productLink = product.GetAttribute("href");
            ////string productName = product.FindElement(By.CssSelector(".product-item .name")).Text;
            ////string innerHtml = product.GetAttribute("innerHTML");
            //string productName = Regex.Match(outerHtml, "alt=\"(.*?)\"").Groups[1].Value;
            //string productThumbnail = Regex.Match(outerHtml, "<img src=\"(.*?)\"").Groups[1].Value;
            //writer.WriteLine(productName + "\t" + productThumbnail);
            //writer.Close();
        }

    }
}