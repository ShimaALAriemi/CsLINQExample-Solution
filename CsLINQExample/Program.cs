namespace CsLINQExample
{
    internal class Program
    {
        class ProductStore
        {
            public int category { get; set; }
            public string productName { get; set; }
            public int productPrice { get; set; }
            public List<string> details { get; set; }

            public string type { get; set; }
        }

        static List<ProductStore> GetProductDetails()
        {
            List<ProductStore> product = new List<ProductStore>
            {
            new ProductStore
                {
                productName = "Bicycle",
                productPrice = 25,
                details = new List<string>{"Sport","Red","New"}
                },
            new ProductStore
                {
                productName = "BMW",
                productPrice = 75000,
                details = new List<string>{"Blue","Used","Sport"}
                },
            new ProductStore
                {
                productName = "Bus",
                productPrice = 30400,
                details = new List<string>{"Mini","Gray", "Automatic" }
                },

            new ProductStore 
            { productName = "Hard Disk",
              productPrice = 1280,
              details = new List<string>{"240GB","500GB","1TB"}
            },
            new ProductStore 
            { productName = "Monitor", 
              productPrice = 3000,
              details = new List<string>{"Samsong","2023","small"}
            },
            new ProductStore 
            { productName = "SSD Disk",
                productPrice = 3500 
            , details = new List < string > { "240GB", "500GB", "1TB" }
            },
            new ProductStore 
            { productName = "Monitor", 
                productPrice = 3000 },
            new ProductStore 
            { productName = "Monitor", 
                productPrice = 3500 },
            new ProductStore 
            { productName = "Monitor", 
                productPrice = 2000 },
            new ProductStore 
            { productName = "RAM", 
              productPrice = 2450 
            , details = new List < string > { "240GB", "500GB", "1TB" }}
        };
            return product;
        }

        static List<ProductStore> GetProductDetailsType()
        {
            List<ProductStore> product = new List<ProductStore>
            {
           new ProductStore { category = 1, productName = "Hard Disk", type = "MEMORY" },
            new ProductStore { category = 2, productName = "Monitor", type = "DISPLAY" },
            new ProductStore { category = 1, productName = "SSD Disk", type = "MEMORY" },
            new ProductStore { category = 1, productName = "RAM", type = "MEMORY" },
            new ProductStore { category = 2, productName = "Processor", type = "CPU" },
            new ProductStore { category = 1, productName = "Bluetooth", type = "Accessories" },
            new ProductStore { category = 2, productName = "Keyboard & Mouse", type = "Accessories" },
        };
            return product;
        }


        static void Main(string[] args)
        {
            #region Select
            /*
         var result = from product in GetProductDetails()
        select new { product.productName, product.productPrice, product.details };
           
            foreach (var r in result)Console.WriteLine(r);
            */




            /*
            var result = from product in GetProductDetails()
                         select product;
            for (int i = 0; i< result.Count(); i++)
            {  
                ProductStore d = (ProductStore)result;

                Console.WriteLine( d.productName ,d.productPrice);
                foreach(var item in d.details) Console.Write(item+ " ");
            }
            Console.WriteLine();
                */
            #endregion

            #region SelectMany
            /*
            var result = from p in GetProductDetails()
                         select p;
          foreach (var r in result.SelectMany(ProductStore => ProductStore.details))
            
          Console.WriteLine(r);


            /*
            var result = from p in GetProductDetails() select  
                         new { p.productName, p.productPrice};

            var result1 = from p in GetProductDetails() select p;

            foreach (var m in result) {
                
                foreach (var r in result1.SelectMany(ProductStore => ProductStore.details))
                {
                    Console.WriteLine(m);
                    Console.Write(r +" ");
                }
                 Console.WriteLine("\n");
            }
            */

            #endregion

            #region orderby
            /*
            var result = from p in GetProductDetails()
                orderby p.productPrice select p;

            foreach (var list in result)
           Console.WriteLine("Product Name: {0} | Product Price : {1}", 
               list.productName, list.productPrice);
            */

            #endregion

            #region orderby descending
            /*
            var result = from p in GetProductDetails()
                         orderby p.productPrice descending
                         select p;

            foreach (var list in result)
                Console.WriteLine("Product Name: {0} | Product Price : {1}",
                    list.productName, list.productPrice);
            */
            #endregion

            #region ThenBy
            /*
            var result = GetProductDetails().OrderBy(p => p.productName).
                ThenBy(p => p.productPrice);

            foreach (var list in result)
           Console.WriteLine("Product Name: {0} | Product Price : {1}",
               list.productName, list.productPrice);

            */
            #endregion

            #region ThenByDescending
            /*
            var result = GetProductDetails().OrderBy(p => p.productName).
                ThenByDescending(p => p.productPrice);

            foreach (var list in result)
                Console.WriteLine("Product Name: {0} | Product Price : {1}",
                    list.productName, list.productPrice);
            */
            #endregion

            #region Reverse
            /*
            var result = GetProductDetails().OrderBy(p => p.productPrice).Reverse();

            foreach (var list in result)
                Console.WriteLine("Product Name: {0} | Product Price : {1}",
                    list.productName, list.productPrice);
            */
            #endregion

            #region group
            /*
            var result = from product in GetProductDetailsType()
                         group product by product.category;

            foreach (var group in result)
            {
                Console.WriteLine(string.Format("Category: {0}", group.Key));
                foreach (var name in group)
                {
                    Console.WriteLine(string.Format("\tProduct Name: {0} | Type: {1}", 
                        name.productName, name.type));
                }
            }
            */
            #endregion

            #region MULTI KEY GROUPING
            /*
            var result = from product in GetProductDetailsType()
                group product by new { product.category, product.type };

            foreach (var group in result)
            {
                Console.WriteLine(string.Format("Category: {0} | Type: {1}", 
                    group.Key.category, group.Key.type));
                foreach (var name in group)
                    Console.WriteLine(string.Format("\tProduct Name: {0} | Type: {1}", 
                        name.productName, name.type));
                
            }
            */
            #endregion

            #region GROUPING WITH SORTING
            /*
            var result = from product in GetProductDetailsType()
             group product by new { product.category, product.type } into pgroup
                   orderby pgroup.Key.category
                   select pgroup;

            foreach (var group in result)
            {
                Console.WriteLine(string.Format("Category: {0} | Type: {1}",
                    group.Key.category, group.Key.type));
                foreach (var name in group)
                    Console.WriteLine(string.Format("\tProduct Name: {0} | Type: {1}",
                        name.productName, name.type));

            }
            */
            #endregion

            #region ToLookup
            /*

            var result = GetProductDetailsType().ToLookup(p => p.category);
            foreach (var group in result)
            {
                Console.WriteLine(string.Format("Category: {0}", group.Key));
                foreach (var name in group)
                {
                    Console.WriteLine(string.Format("\tProduct Name: {0} | Type: {1}",
                        name.productName, name.type));
                }
            }
            */
            #endregion


            var result = from p in GetProductDetails()
                         select p.productPrice;

            Console.WriteLine("Average: " + GetProductDetails().Average(p => p.productPrice));
            Console.WriteLine("Count: " + GetProductDetails().Count());
            Console.WriteLine("Max: " + result.Max());
            Console.WriteLine("Min: " + result.Min());
            Console.WriteLine("Sum: " + result.Sum());
            Console.WriteLine("First Value: " + result.First());
            Console.WriteLine("Last Value: " + result.Last());
            Console.WriteLine("Is 3500 Available? " + result.Contains(3500));
            Console.WriteLine("Element at 4th Position: " + result.ElementAt(3));

            var distinctPrice = result.Distinct();
            Console.WriteLine("\n\n------- Distinct Result --------\n");
            foreach (var price in distinctPrice)
            {
                Console.WriteLine("Distinct Value: " + price.ToString());
            }

        }
    }
}