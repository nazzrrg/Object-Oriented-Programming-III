namespace lab2.Core.Types
{
    public class StockItem
    {
        public int Qty;
        public decimal Price;
        public Product Product;

        public StockItem(Product product, int qty, decimal price)
        {
            Product = product;
            Qty = qty;
            Price = price;
        }
    }
}
