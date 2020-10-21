using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Core.Types
{
    public class Shop
    {
        public int Id { get; }
        public string Name { get; }
        public string Address { get; }
        private readonly List<StockItem> _stock = new List<StockItem>();

        public Shop(int id, string name, string address)
        {
            Name = name;
            Id = id;
            Address = address;
        }

        public void Add(Product product, int qty, decimal atPrice) // assuming price will change
        {
            var stockItem = _stock.FirstOrDefault(x => x.Product.Equals(product));
            
            if (stockItem is null)
            {
                _stock.Add(new StockItem(product, qty, atPrice));
            } else
            {
                stockItem.Qty += qty;    
                stockItem.Price = atPrice;
            }
        }
        public void Add(Product product, int qty)
        {
            var stockItem = _stock.FirstOrDefault(x => x.Product.Equals(product));
            
            if (stockItem is null)
            {
                throw new Exception($"Error: Failed to add new product {product} to shop {Name}({Id}), product price is unspecified!");
            }
            
            stockItem.Qty += qty;
        }

        public bool TryBuy(Product product, int qty, out decimal sum)
        {
            try
            {
                sum = Buy(product, qty);
                return true;
            } catch
            {
                sum = 0;
                return false;
            }
        }

        public decimal Buy(Product product, int qty)
        {
            var stockItem = _stock.FirstOrDefault(x => x.Product.Equals(product));
            
            if (stockItem is null)
            {
                throw new Exception($"Error: No product {product}) in shop {Name}({Id})!");
            }
            if (stockItem.Qty < qty)
            {
                throw new Exception($"Error: Not enough {product} in stock in shop {Name}({Id})!");
            }

            stockItem.Qty -= qty;

            var orderSum = qty * stockItem.Price;

            if (stockItem.Qty == 0)
            {
                _stock.Remove(stockItem);
            }

            return orderSum;
        }

        public decimal GetPrice(Product product)
        {
            var stockItem = _stock.FirstOrDefault(x => x.Product.Equals(product));
            
            if (stockItem is null)
            {
                throw new Exception($"Error: No product {product} in shop {Name}({Id})!");
            }
            
            return stockItem.Price;
        }

        public int GetQty(Product product)
        {
            var stockItem = _stock.FirstOrDefault(x => x.Product.Equals(product));
            
            if (stockItem is null)
            {
                throw new Exception($"Error: No product ({product}) in shop {Name}({Id})");
            }
            
            return stockItem.Qty;
        }

        public List<Product> GetAvailableProducts()
        {
            return _stock.Select(x => x.Product).ToList();
        }

        public override bool Equals(object obj)
        {
            if (obj is Shop other)
            {
                return other.Id == Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            var resultString = $"ID: {Id}\tNAME: {Name}\tADDRESS: {Address}\nPRODUCTS:\n";

            foreach (var item in _stock)
            {
                resultString += $"{item.Product.Id}\t{item.Product.Name}\t{item.Qty}\t{item.Price}\n";
            }
            
            return resultString;
        }
    }
}
