using MySql.Data.MySqlClient;
using Shawarma.Enum;

namespace Shawarma.DataAccess
{
    public class OrdersStorage
    {

        private Dictionary<string, OrderStatus> orderStatusDictionary;
        public OrdersStorage()
        {
            creatingOrderStatusDictionary();
        }

        public MySqlConnection connection { get { return Connection.Connect; } }

        public bool AddOrder(OrderOTD order, int makerId)
        {
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO `order`(`Note`, `PersonId`)" +
                " VALUES (@NOTE,@PERSONID)"
                , connection);

            cmd.Parameters.AddWithValue("@NOTE", order.Note);

            cmd.Parameters.AddWithValue("@PERSONID", makerId);

            int effectedRows = cmd.ExecuteNonQuery();


            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public List<OrderOTD> GetOrders()
        {
            List<OrderOTD> orders = new List<OrderOTD>();



            MySqlCommand cmd = new MySqlCommand(
                "SELECT `ID`, `Note`, `PersonId` ,`Status` FROM `order`"
                  , connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    OrderOTD order = new OrderOTD();

                    order.Id = Convert.ToInt32(reader[0]);
                    order.Note = reader[1].ToString();
                    order.PersonID = Convert.ToInt32(reader[2]);
                    order.OrderStatus = orderStatusDictionary[reader[3].ToString()];
                    orders.Add(order);
                }
            }
            return orders;
        }

        public OrderOTD GetOrder(int orderId)
        {
            if (orderId == 0)
            {
                return null;
            }

            OrderOTD order = new OrderOTD();

            MySqlCommand cmd = new MySqlCommand(
                "SELECT `ID`, `Note`, `PersonId` ,`Status` FROM `order` WHERE id =@ID"
                  , connection);

            cmd.Parameters.AddWithValue("@ID", orderId);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                reader.Read();

                order.Id = Convert.ToInt32(reader[0]);
                order.Note = reader[1].ToString();
                order.PersonID = Convert.ToInt32(reader[2]);
                order.OrderStatus = orderStatusDictionary[reader[3].ToString()];
            }
            return order;
        }

        public List<ItemOTD> GetItemsPerOrder(int orderId)
        {
            List<ItemOTD> itemsOTD = new List<ItemOTD>();

            MySqlCommand cmd = new MySqlCommand("SELECT i.*,o.Quantity FROM item as i INNER JOIN order_line as o on i.ID = o.ItemID " +
           "where o.OrderID = @ORDERID"
               , connection);

            cmd.Parameters.AddWithValue("@ORDERID", orderId);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    if (reader[6].ToString() == "NORMAL")
                    {
                        NormalItemOTD normalItemOTD = new NormalItemOTD();

                        normalItemOTD.Id = Convert.ToInt32(reader[0]);
                        normalItemOTD.Name = reader[1].ToString();
                        normalItemOTD.Description = reader[2].ToString();
                        normalItemOTD.Price = Convert.ToDouble(reader[3]);
                        normalItemOTD.Discount = Convert.ToDouble(reader[4]);
                        normalItemOTD.Category = GetCategory(reader[5].ToString());
                        normalItemOTD.Quantity = Convert.ToInt32(reader[7]);

                        itemsOTD.Add(normalItemOTD);
                    }

                    if (reader[6].ToString() == "HOILDAY")
                    {
                        HoildayItemOTD hoildayItemOTD = new HoildayItemOTD();

                        hoildayItemOTD.Id = Convert.ToInt32(reader[0]);
                        hoildayItemOTD.Name = reader[1].ToString();
                        hoildayItemOTD.Description = reader[2].ToString();
                        hoildayItemOTD.Price = Convert.ToDouble(reader[3]);
                        hoildayItemOTD.Discount = Convert.ToDouble(reader[4]);
                        hoildayItemOTD.Category = GetCategory(reader[5].ToString());
                        hoildayItemOTD.Quantity = Convert.ToInt32(reader[7]);

                        itemsOTD.Add(hoildayItemOTD);

                    }

                    if (reader[6].ToString() == "SUMMER")
                    {
                        SummerItemOTD summerItemOTD = new SummerItemOTD();

                        summerItemOTD.Id = Convert.ToInt32(reader[0]);
                        summerItemOTD.Name = reader[1].ToString();
                        summerItemOTD.Description = reader[2].ToString();
                        summerItemOTD.Price = Convert.ToDouble(reader[3]);
                        summerItemOTD.Discount = Convert.ToDouble(reader[4]);
                        summerItemOTD.Category = GetCategory(reader[5].ToString());
                        summerItemOTD.Quantity = Convert.ToInt32(reader[7]);

                        itemsOTD.Add(summerItemOTD);
                    }
                }
            }

            return itemsOTD;
        }

        public bool RemoveOrder(int orderId)
        {
            MySqlCommand cmd = new MySqlCommand(
               "DELETE FROM `order` WHERE id =@ID"
                 , connection);

            cmd.Parameters.AddWithValue("@ID", orderId);

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public bool PersonHasOrderCreated(int personId)
        {
            MySqlCommand cmd = new MySqlCommand(
                "Select personId from `order` Where personId =@PERSONID AND Status like \"CREATED\"",
                connection);

            cmd.Parameters.AddWithValue("@PERSONID", personId);

            int foundPersonId = Convert.ToInt32(cmd.ExecuteScalar());

            if (foundPersonId != 0)
            {
                return true;
            }
            return false;
        }

        public List<int> GetOrdersIdByPersonIdIfOrderDone(int personId)
        {
            List<int> ordersId = new List<int>();
            MySqlCommand cmd = new MySqlCommand(
                "Select ID from `order` Where personId =@PERSONID AND Status like \"DONE\"",
                connection);

            cmd.Parameters.AddWithValue("@PERSONID", personId);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    ordersId.Add(Convert.ToInt32(reader[0]));
                }
            }

            return ordersId;
        }

        public int GetOrderIdByPersonIdIfOrderIsCreated(int personId)
        {
            MySqlCommand cmd = new MySqlCommand(
                "Select ID from `order` where Status != \"Done\" AND PersonId = @PERSONID",
                connection);

            cmd.Parameters.AddWithValue("PERSONID", personId);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int GetLastOrderID()
        {
            MySqlCommand cmd = new MySqlCommand(
            "SELECT MAX(id) FROM `order`"
             , connection);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private Category GetCategory(string category)
        {
            switch (category)
            {
                case "POPULARDISHES": return Category.POPULARDISHES;
                case "STARTERS": return Category.STARTERS;
                case "SANDWICHES": return Category.SANDWICHES;
                case "BURGERS": return Category.BURGERS;
                case "DISHES": return Category.DISHES;
                case "DRINKS": return Category.DRINKS;
                case "COCKTAILS": return Category.COCKTAILS;
                default: return Category.STARTERS;
            }
        }

        private void creatingOrderStatusDictionary()
        {
            orderStatusDictionary = new Dictionary<string, OrderStatus>();
            orderStatusDictionary.Add("CREATED", OrderStatus.CREATED);
            orderStatusDictionary.Add("SENT", OrderStatus.SENT);
            orderStatusDictionary.Add("ACCEPTED", OrderStatus.ACCEPTED);
            orderStatusDictionary.Add("PREPARING", OrderStatus.PREPARING);
            orderStatusDictionary.Add("DONE", OrderStatus.DONE);
        }
    }
}
