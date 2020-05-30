using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystemEF.Class
{
    [Serializable]
    public class Item
    {
        [Key]
        public string ItemId { set; get; }
        public string Name { set; get; }
        public int Price { set; get; }
        public Item()
        {
        }
        public Item(string id,int price)
        {
            this.ItemId = id;
            this.Price = price;
        }
    }
}