using Shawarma.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shawarma
{
    abstract public class ItemOTD
    {
        private double price;
        private double dicount;
        private int quantity = 1;

        public ItemOTD(string name,string description,double price,Category category) 
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Category = category;
        }
        public ItemOTD() 
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Discount { get { return dicount; }
            set { dicount = value / 100 * Price; } }

        public string Description { get; set; }

        public virtual double Price {
            get { return price - Discount; }
            set {
                if (value > 0)
                {
                    price = value;

                }
                else 
                {
                    price = 0;
                }
            } 
        }

        public int Quantity { get { return quantity; } set { quantity = value; } }

        public Category Category { get; set; }
    }
}
