using System;
using System.Collections.Generic;
using System.Linq;
using lab2.Core.Types;
using lab2.Core;

namespace lab2
{
    class MainClass
    {
        public static void Main()
        {
            var manager = new ShopManager();
            
            manager.CreateProduct("prod 1");
            manager.CreateProduct("prod 2");
            manager.CreateProduct("prod 3");
            manager.CreateProduct("prod 4");
            manager.CreateProduct("prod 5");
            manager.CreateProduct("prod 6");
            manager.CreateProduct("prod 7");
            manager.CreateProduct("prod 8");
            manager.CreateProduct("prod 9");
            manager.CreateProduct("prod 1");
            
            manager.CreateShop("shop 1", "Saint-Petersburg, Kronversky ave., 49");
            manager.CreateShop("shop 2", "Saint-Petersburg, Lomonosova st., 9");
            manager.CreateShop("shop 3", "Saint-Petersburg, Vyazemsky lane, 5-7");
            
            Console.WriteLine("\n--- Task 1,2 ---");
            Console.WriteLine(manager.ToString());

            
            var availableShops = manager.GetShopList();
            var availableProducts = manager.GetProductsList();

            Random random = new Random();
            
            Console.WriteLine("\n--- Task 3 ---");
            Console.WriteLine("FIRST PASS:");
            foreach (var shop in availableShops)
            {
                foreach (var product in availableProducts)
                {
                    if (random.Next() % 2 == 0)
                    {
                        manager.AddStock(shop, product, random.Next(1, 30), random.Next(1, 500));
                    }
                }
                Console.WriteLine(shop.ToString());
            }
            Console.WriteLine("SECOND PASS:");
            foreach (var shop in availableShops)
            {
                foreach (var product in availableProducts)
                {
                    if (random.Next() % 2 == 0)
                    {
                        if (random.Next() % 2 == 0)
                        {
                            manager.AddStock(shop, product, random.Next(1, 30), random.Next(1, 500));    
                        }
                        else
                        {
                            if (!(shop.GetAvailableProducts().FirstOrDefault(x => x.Equals(product)) is null))
                            {
                                manager.AddStock(shop, product, random.Next(1, 30));
                            }
                        }
                    }
                }
                Console.WriteLine(shop.ToString());
            }
            
            Console.WriteLine("\n--- Task 4 ---");
            var result4 = manager.GetShopWhereCheapest(availableProducts[0]);
            Console.WriteLine($"Shop, where {availableProducts[0]} is cheapest:");
            Console.WriteLine(result4 is null ? "No such shop" : result4.ToString());

            Console.WriteLine("\n--- Task 5 ---");
            var result5 = manager.CalculatePossiblePurchaseByMaxOrderSum(availableShops[2], 1000);
            Console.WriteLine($"Products available from shop {availableShops[2].Name}({availableShops[2].Id}) for 1000 hrivna");
            foreach (var tuple in result5)
            {
                Console.WriteLine($"{tuple.product}\t{tuple.qty}");
            }
            
            Console.WriteLine("\n--- Task 6 ---");
            Console.WriteLine($"Try to buy 3 {availableProducts[5]} form shop {availableShops[1].Name}({availableShops[1].Id})");
            if (manager.TryBuyFromShop(availableShops[1], availableProducts[5], 3, out decimal result6))
            {
                Console.WriteLine($"Purchase is possible, total: {result6}");
                Console.WriteLine("Changed stock of shop:");
                Console.WriteLine(availableShops[1].ToString());
            }
            else
            {
                Console.WriteLine("Purchase is not possible");
            }
            
            Console.WriteLine("\n--- Task 7 ---");
            List<(Product product, int qty)> input7 = new List<(Product product, int qty)>();
            Console.WriteLine("Shop with the cheapest deal for");
            foreach (var tuple in result5)
            {
                if (random.Next() % 3 == 0)
                {
                    input7.Add(tuple);
                    Console.WriteLine($"{tuple.product}\t{tuple.qty}");
                }
            }
            Console.WriteLine(manager.GetCheapestShopForOrderList(input7));
        }
    }
}
