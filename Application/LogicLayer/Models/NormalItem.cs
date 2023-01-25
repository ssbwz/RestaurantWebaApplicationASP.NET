using Shawarma.Enum;

namespace Shawarma.Models
{
    public class NormalItem : Item
    {
        public NormalItem(string name, string description, double price, Category category) : base(name, description, price, category)
        {
        }

        public NormalItem(ItemOTD itemOTD)
        {
            this.Id = itemOTD.Id;
            this.Name = itemOTD.Name;
            this.Description = itemOTD.Description;
            this.Price = itemOTD.Price;
            this.Category = itemOTD.Category;
            this.Quantity = itemOTD.Quantity;
        }

        public NormalItem() { }
        public override double Price
        { get => Math.Round(base.Price, 2); set => base.Price = value; }


        public override string ToString()
        {
            return $"{Id} - Dish type: Normal - Name: {Name} - price:{Price} - quantity:{Quantity}";
        }

    }
}
