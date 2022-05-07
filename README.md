# Web_crawler_anvatchumanh.com
get data of website anvatchumanh.com to import wordpress website xusobanhkeo.com

1. using http client to connect website
2. create path to save file (SystemIO.StreamWrite).Ex: path="D:\\ crawl\test.txt"
3. create format data. Ex: string format = "@ID@Type@SKU@Name\n";
4. write header of files. Ex: string header=format
5. //prepare to write data in files
6. Get list url of each product by Regex (pattern and match collection).Ex: MatchCollection matches = Regex.Matches(html, patternListLinkProduct, RegexOptions.Multiline);
7. foreach (match in matches)
8. crawl all data of each product.
9. design pattern of product.name, product.image, product.description, product.price,... and Regex. Output: name, image, price,... of each product.
10. write data of files. Ex:  data = data.Replace("@Name","@\""+ product.Name + "\"").
11. check  path="D:\\ crawl\test.txt" have files .txt.

IMPORT TO WORDPRESS. Type:"@".
GOOD LUCK TO YOU.
Notes: you can export files csv wordpress to change data and import again to resume.
