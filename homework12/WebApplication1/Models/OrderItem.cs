namespace WebApplication1.Models
{
    public class OrderItem
    {
        public OrderItem()
        {

        }
        public OrderItem(int id, int price, int amount)
        {
            this.Id = id;
            this.Price = price;
            this.Amount = amount;
        }

        public int Id { set; get; }
        public int Price { set; get; }
        public int Amount { set; get; }
    }
}