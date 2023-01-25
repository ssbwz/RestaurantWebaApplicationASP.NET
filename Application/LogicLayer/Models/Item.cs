using System.ComponentModel.DataAnnotations;
using Shawarma.Enum;

namespace Shawarma.Models
{
    abstract public class Item
    {
        private double price;
        private double dicount ;
        private int quantity = 1;

        public Item(string name,string description,double price, Category category) 
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Category = category;
        }

        public Item() 
        {
        }


        public int Id { get; set; }

        [Required(ErrorMessage = "Please fill the name.")]
        public string Name { get; set; }

        public double Discount { get { return dicount; }
            set { dicount = value / 100 * Price; } }

        [Required(ErrorMessage = "Please fill the description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please fill the price.")]
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

        public abstract string ToString();
    }
}
