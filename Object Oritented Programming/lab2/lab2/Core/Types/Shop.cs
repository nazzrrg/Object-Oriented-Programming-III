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
        private readonly Dictionary<Product, StockItemInfo> _stock = new Dictionary<Product, StockItemInfo>();

        public Shop(int id, string name, string address)
        {
            Name = name;
            Id = id;
            Address = address;
        }

        public void Add(Product product, int qty, decimal atPrice) // assuming price will change
        {
            //if (!_stock.FirstOrDefault(x => x.Key.Id == product.Id).Equals(default))
            if (!_stock.ContainsKey(product))
            {
                _stock.Add(product, new StockItemInfo(qty, atPrice));
            } else
            {
                _stock[product].Qty += qty;    
                _stock[product].Price = atPrice;
            }
        }
        public void Add(Product product, int qty)
        {
            if (!_stock.ContainsKey(product))
            {
                throw new Exception($"Error: Failed to add new product to shop {Id}, product price is unspecified!");
            }
            _stock[product].Qty += qty;
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
            //if (!_stock.FirstOrDefault(x => x.Key.Id == product.Id).Equals(default))
            if (!_stock.ContainsKey(product))
            {
                throw new Exception($"Error no product {product.Name}({product.Id}) in shop {Name}({Id})");
            }
            if (_stock[product].Qty < qty)
            {
                throw new Exception($"Error not enough {product.Name}({product.Id}) in stock in shop {Name}({Id}). Requested: {qty}, available: {_stock[product].Qty}");
            }

            _stock[product].Qty -= qty;

            var orderSum = qty * _stock[product].Price;

            if (_stock[product].Qty == 0)
            {
                _stock.Remove(product);
            }

            return orderSum;
        }

        public decimal GetPrice(Product product)
        {
            //if (!_stock.FirstOrDefault(x => x.Key.Id == product.Id).Equals(default))
            if (!_stock.ContainsKey(product))
            {
                throw new Exception($"Error no product {product.Name}({product.Id}) in shop {Name}({Id})");
            }
            return _stock[product].Price;
        }

        public int GetQty(Product product)
        {
            //if (!_stock.FirstOrDefault(x => x.Key.Id == product.Id).Equals(default))
            if (!_stock.ContainsKey(product))
            {
                throw new Exception($"Error no product {product.Name}({product.Id}) in shop {Name}({Id})");
            }
            return _stock[product].Qty;
        }

        public List<Product> GetAvailableProducts()
        {
            return _stock.Select(x => x.Key).ToList();
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
                resultString += $"{item.Key.Id.ToString()}\t{item.Key.Name}\t{item.Value.Qty}\t{item.Value.Price}\n";
            }
            
            return resultString;
        }
    }
}
