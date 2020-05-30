using System;
using System.Collections.Generic;

namespace OrderManagementSystemEF.Class
{
    public class iList<orderitem> : List<OrderItem>
    {
        public override string ToString()
        {
            string s = "\n";
            int count = 1;
            Array.ForEach(this.ToArray(), i => s += (count++) + "." + i.ToString() + "\n");
            return $"{s}";
        }

        public bool Contains(OrderItem item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Equals(item))
                    return true;
            }
            return false;
        }
    }
}