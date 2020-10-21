namespace lab2.Core.Types
{
    public class StockItemInfo
    {
        public int Qty;
        public decimal Price;

        public StockItemInfo(int qty, decimal price)
        {
            Qty = qty;
            Price = price;
        }
    }
}
