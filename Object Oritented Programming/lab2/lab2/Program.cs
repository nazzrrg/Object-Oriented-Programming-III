using System;
using lab2.Core.Types;
using lab2.Core;

namespace lab2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var manager = new ShopManager();
            
            manager.CreateProduct("pipa 1");
            manager.CreateProduct("pipa 2");
            manager.CreateProduct("pipa 3");
            manager.CreateProduct("pipa 4");
            manager.CreateProduct("pipa 5");
            manager.CreateProduct("pipa 6");
            manager.CreateProduct("pipa 7");
            manager.CreateProduct("pipa 8");
            manager.CreateProduct("pipa 9");
            manager.CreateProduct("pipa 1");
            
            manager.CreateShop("pipa shop 1", "Spb, Kronversky prospekt, 49");
            manager.CreateShop("pipa shop 2", "Spb, Lomonosova st., 9");
            manager.CreateShop("pipa shop 3", "Spb, Vyazemsky lane, 5-7");

            var availableShops = manager.GetShopList();
            var availableProducts = manager.GetProductsList();
            Console.WriteLine(manager.ToString());
            Console.WriteLine();
            
            manager.AddStock(availableShops[0], availableProducts[0], 2, 100);
            manager.AddStock(availableShops[0], availableProducts[0], 2, 200);
            manager.AddStock(availableShops[0], availableProducts[0], 2, 300);
            Console.WriteLine(manager.GetShopWhereCheapest(availableProducts[0]).ToString());
            
            
            
            
            
            
            foreach (var shop in availableShops)
            {
                Console.WriteLine(shop.ToString());
            }
            
        }
    }
}
