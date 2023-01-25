using Shawarma_website.Enum;

namespace Shawarma_website.Class
{
    public class Item
    {
        private double price;
        private double discountPercentage;

        public Item(string name, string description, double price, Category category)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Category = category;
        }
        public Item()
        {
        }

        public int OrderId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double DiscountPercentage
        {
            get { return discountPercentage; }
            set { discountPercentage = value / 100 * Price; }
        }
        public string Description { get; set; }
        public virtual double Price
        {
            get { return price - DiscountPercentage; }
            set
            {
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
        public Category Category { get; set; }
        /* public abstract void ExtraStuff(string extraStuff);

         public abstract string ToString();*/
    }
}
