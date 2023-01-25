using Shawarma.Enum;

namespace Shawarma.Models
{
    public class HoildayItem : Item
    {
        public HoildayItem( string name, string description, double price, Category category) : base(name, description, price, category)
        {
        }

        public HoildayItem(ItemOTD itemOTD)
        {
            this.Id = itemOTD.Id;
            this.Name = itemOTD.Name;
            this.Description = itemOTD.Description;
            this.Price = itemOTD.Price;
            this.Category = itemOTD.Category;
            this.Quantity = itemOTD.Quantity;
        }

        public HoildayItem() { }

        public override double Price { get => Math.Round(base.Price, 2); set => base.Price = value; }

        public override string ToString() 
        {
            return $"{Id} - Dish type: Holiday - Name: {Name} - price:{Price} - quantity:{Quantity} - (gets free drink)";
        }

       /* private CategoryLogic convertCatergoryDataAccessToCategoryLogic(string catergoryDataAccess) 
        {
            switch (catergoryDataAccess) 
            {
                case "STARTERS": return CategoryLogic.STARTERS;
                case "SANDWICHES": return CategoryLogic.SANDWICHES;
                case "BURGERS": return CategoryLogic.BURGERS;
                case "DISHES": return CategoryLogic.DISHES;
                case "DRINKS": return CategoryLogic.DRINKS;
                case "COCKTAILS": return CategoryLogic.COCKTAILS;
                default:return CategoryLogic.POPULARDISHES;
            }
        }*/
    }
}
