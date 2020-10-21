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
            if (!_shopList.Contains(shop))
            {
                throw new Exception($"Error: Unable to add stock to shop id={shop.Id}, shop does not exist!");
            }

            if (!_productList.Contains(product))
            {
                throw new Exception($"Error: Unable to add product id={product.Id} to shop id={shop.Id}, product does not exist!");
            }

            if (qty < 1)
            {
                throw new Exception($"Error: Unable to add negative or 0 quantity of product id={product.Id} to shop id={shop.Id}!");
            }

            if (atPrice == -1)
            {
                _shopList.First(x => x.Equals(shop)).Add(_productList.First(x => x.Equals(product)), qty);
            } else
            {
                _shopList.First(x => x.Equals(shop)).Add(_productList.First(x => x.Equals(product)), qty, atPrice);
            }
        }

        public Shop GetShopWhereCheapest(Product product)
        {
            Shop cheapestShop = null;
            decimal lowestPrice = -1;

            foreach(Shop shop in _shopList)
            {
                if (shop.GetAvailableProducts().FirstOrDefault(x => x.Equals(product)).Equals(default))
                {
                    if (shop.GetPrice(product) < lowestPrice)
                    {
                        lowestPrice = shop.GetPrice(product);
                        cheapestShop = shop;
                    }
                }
            }

            return cheapestShop;
        }

        public List<(Product product, int qty)> CalculatePossiblePurchaseByMaxOrderSum(Shop shop, decimal maxOrderSum)
        {
            if (!_shopList.Contains(shop))
            {
                throw new Exception($"Error: Unable to calculate purchase in shop id={shop.Id}, shop does not exist!");
            }

            var possibleOrders = new List<(Product product, int qty)>();

            foreach (var product in shop.GetAvailableProducts())
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
            if (_shopList.Contains(shop) && _productList.Contains(product))
            {
                if (_shopList.First(x => x.Equals(shop)).TryBuy(_productList.First(x => x.Equals(product)), qty, out decimal sum))
                {
                    orderSum = sum;
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        public Shop GetCheapestDealForOrderList(List<(Product product, int qty)> orderList)
        {
            Shop cheapestShop = null;
            decimal lowestOrderSum = Decimal.MaxValue;

            foreach(var shop in _shopList)
            {
                decimal orderSum = 0;
                var ableToCompleteOrder = true;

                foreach(var orderListElement in orderList)
                {
                    if (orderListElement.qty <= shop.GetQty(orderListElement.product))
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
