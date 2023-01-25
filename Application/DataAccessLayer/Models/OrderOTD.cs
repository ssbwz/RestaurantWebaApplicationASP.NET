using Shawarma.Enum;


namespace Shawarma
{
    public class OrderOTD
    {
 
        public OrderOTD()
        {
        }
        public int Id { get; set; }

        public int PersonID { get; set; }

        public string Note { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
