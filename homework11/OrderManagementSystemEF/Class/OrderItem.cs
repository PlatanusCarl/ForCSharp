using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystemEF.Class
{
    [Serializable]
    public class OrderItem
    {
        [Key]
        public string OrderItemId { set; get; }
        public string OrderId { set; get; }
        
        [ForeignKey("Item")]
        public string ItemId { set; get; }
        public virtual Item Item { set; get; }
        public int Amount { set; get; }
        public int Price { set; get; }
        public int Total => Price * Amount;
        public OrderItem()
        {
            OrderItemId = Guid.NewGuid().ToString();
            Item = new Item();
            ItemId = Item.ItemId;
        }

        public OrderItem(string itemid,int price,int amount):this()
        {
            Item.Price = price;
            Price = Item.Price;
            Item.ItemId = itemid;
            ItemId = Item.ItemId;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"商品号：{Item.ItemId}，商品价格：{Item.Price}，商品数量：{Amount}";
        }
        public bool Equals(OrderItem obj)
        {
            if (obj.ItemId != this.ItemId)
                return false;
            return true;
        }
        public bool Same(OrderItem obj)
        {
            if (obj.ItemId != this.ItemId)
                return false;
            return true;
        }
    }
}