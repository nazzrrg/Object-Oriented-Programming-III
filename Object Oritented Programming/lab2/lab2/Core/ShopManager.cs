using System;
using System.Collections.Generic;
using System.Linq;
using lab2.Core.Types;

namespace lab2.Core
{
    public class ShopManager
    {
        private readonly List<Shop> _shopList = new List<Shop>();
        private readonly List<Product> _productList = new List<Product>();

        public void CreateShop(string shopName, string shopAddress)
        {
            _shopList.Add(new Shop(_shopList.Count + 1, shopName, shopAddress));
        }

        public void CreateProduct(string productName)
        {
            _productList.Add(new Product(_productList.Count + 1, productName));
        }

        public List<Shop> GetShopList()
        {
            return _shopList;
        }

        public List<Product> GetProductsList()
        {
            return _productList;
        }

        public void AddStock(Shop shop, Product product, int qty, decimal atPrice = -1)
        {
            var shopFromList = _shopList.FirstOrDefault(x => x.Equals(shop));
            if (shopFromList is null)
            {
                throw new Exception($"Error: Unable to add stock to shop {shop.Name}({shop.Id}), shop does not exist!");
            }

            var productFromList = _productList.FirstOrDefault(x => x.Equals(product));
            if (productFromList is null)
            {
                throw new Exception($"Error: Unable to add product {product} to shop {shop.Name}({shop.Id}), product does not exist!");
            }

            if (qty < 1)
            {
                throw new Exception($"Error: Unable to add negative or 0 quantity of product {product} to shop {shop.Name}({shop.Id})!");
            }

            if (atPrice == -1)
            {
                shopFromList.Add(productFromList, qty);
            } else
            {
                shopFromList.Add(productFromList, qty, atPrice);
            }
        }

        public Shop GetShopWhereCheapest(Product product)
        {
            Shop cheapestShop = null;
            decimal lowestPrice = Decimal.MaxValue;

            foreach(Shop shop in _shopList)
            {
                if (shop.GetAvailableProducts().FirstOrDefault(x => x.Equals(product)) is null)
                {
                    continue;
                }
            
                if (shop.GetPrice(product) < lowestPrice)
                {
                    lowestPrice = shop.GetPrice(product);
                    cheapestShop = shop;
                }
            
            }

            return cheapestShop;
        }

        public List<(Product product, int qty)> CalculatePossiblePurchaseByMaxOrderSum(Shop shop, decimal maxOrderSum)
        {
            var shopFromList = _shopList.FirstOrDefault(x => x.Equals(shop)); 
            if (shopFromList is null)
            {
                throw new Exception($"Error: Unable to calculate purchase in shop {shop.Name}({shop.Id}), shop does not exist!");
            }

            var possibleOrders = new List<(Product product, int qty)>();

            foreach (var product in shopFromList.GetAvailableProducts())
            {
                var singleItemPrice = shop.GetPrice(product);
                var availableQty = shop.GetQty(product);

                var maxPossibleQty = Math.Min(availableQty, Decimal.ToInt32(Decimal.Floor(maxOrderSum / singleItemPrice)));

                if (maxPossibleQty > 0)
                {
                    possibleOrders.Add((product, maxPossibleQty));
                }
            }

            return possibleOrders;
        }

        public bool TryBuyFromShop(Shop shop, Product product, int qty, out decimal orderSum)
        {
            orderSum = 0;

            var shopFromList = _shopList.FirstOrDefault(x => x.Equals(shop));
            var productFromList = _productList.FirstOrDefault(x => x.Equals(product));
            if (shopFromList is null || productFromList is null)
            {    
                return false;
            }

            if (!shopFromList.TryBuy(productFromList, qty, out decimal sum))
            {
                return false;
            }
            
            orderSum = sum;
            return true;
        }
    

        public Shop GetCheapestShopForOrderList(List<(Product product, int qty)> orderList)
        {
            Shop cheapestShop = null;
            var lowestOrderSum = Decimal.MaxValue;

            foreach(var shop in _shopList)
            {
                decimal orderSum = 0;
                var ableToCompleteOrder = true;

                foreach(var orderListElement in orderList)
                {
                    if (!(shop.GetAvailableProducts().FirstOrDefault(x => x.Equals(orderListElement.product)) is null) &&
                        orderListElement.qty <= shop.GetQty(orderListElement.product))
                    {
                        orderSum += shop.GetPrice(orderListElement.product) * orderListElement.qty;
                    } else
                    {
                        ableToCompleteOrder = false;
                        break;
                    }
                }

                if (!ableToCompleteOrder)
                {
                    continue;
                }

                if (orderSum < lowestOrderSum)
                {
                    lowestOrderSum = orderSum;
                    cheapestShop = shop;
                }
            }

            return cheapestShop;
        }

        public override string ToString()
        {
            var resultString = "[PRODUCTS]\nID\tNAME\n";
            
            foreach (var product in _productList)
            {
                resultString += $"{product.Id.ToString()}\t{product.Name}\n";
            }

            resultString += "\n[SHOPS]\nID\tNAME\t\tADDRESS\n";

            foreach (var shop in _shopList)
            {
                resultString += $"{shop.Id.ToString()}\t{shop.Name}\t{shop.Address}\n";
            }
            return resultString;
        }
    }
}
