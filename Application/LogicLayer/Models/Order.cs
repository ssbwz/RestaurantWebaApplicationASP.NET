using Shawarma.Enum;


namespace Shawarma.Models
{
    public class Order
    {
 
        public Order()
        {
        }

        public Order(OrderOTD orderOTD) 
        {
            Id = orderOTD.Id;
            PersonID = orderOTD.PersonID;
            Note = orderOTD.Note;
            OrderStatus = orderOTD.OrderStatus;
        } 

        public int Id { get; set; }

        public int PersonID { get; set; }
        
        public string Note { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public override string ToString()
        {
            return $"{Id} - Note: {Note} - Order status: {OrderStatus.ToString()}";
        }

    }
}
