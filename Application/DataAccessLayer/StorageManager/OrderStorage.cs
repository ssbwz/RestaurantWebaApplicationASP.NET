using MySql.Data.MySqlClient;
using Shawarma.Enum;

namespace Shawarma.DataAccess
{
    public class OrderStorage
    {

        private Dictionary<string, OrderStatus> orderStatusDictionary;

        public OrderStorage()
        {
            creatingOrderStatusDictionary();
        }
        public MySqlConnection connection { get { return Connection.Connect; } }

        public bool IsOrderProcessed(int orderId)
        {

            MySqlCommand cmd = new MySqlCommand(
                "Select status from `order` where ID = @ORDERID AND status != 'CREATED' AND status != 'DONE'"
                ,connection);

            cmd.Parameters.AddWithValue("ORDERID", orderId);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                if (reader.HasRows)
                {
                    return true;
                }
            }
            return false;

        }

        public bool AddItem(int orderId, ItemOTD item)
        {
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO `order_line` (`OrderID`, `ItemID`, `Price`,`Discount`,`Quantity`)" +
                " VALUES (@ORDERID,@ITEMID,@PRICE,@DISCOUNT,@QUANTITY)"
                , connection);

            cmd.Parameters.AddWithValue("@ORDERID", orderId);
            cmd.Parameters.AddWithValue("@ITEMID", item.Id);
            cmd.Parameters.AddWithValue("@PRICE", item.Price);
            cmd.Parameters.AddWithValue("@DISCOUNT", item.Discount);
            cmd.Parameters.AddWithValue("@QUANTITY", item.Quantity);

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public double GetTotalPerItem(int orderId, int itemId)
        {
            MySqlCommand cmd = new MySqlCommand(
          "Select Price * Quantity from `order_line` where orderId = @ORDERID AND itemId = @ITEMID"
          , connection);

            cmd.Parameters.AddWithValue("ORDERID", orderId);
            cmd.Parameters.AddWithValue("ITEMID", itemId);

            object total = cmd.ExecuteScalar();

            if (total is DBNull)
            {
                return 0;
            }

            return Convert.ToDouble(cmd.ExecuteScalar());
        }

        public List<int> GetItemsIdList(int orderId)
        {
            List<int> idsList = new List<int>();

            MySqlCommand cmd = new MySqlCommand(
                "Select itemId from `order_line` where orderId = @ORDERID"
                , connection);

            cmd.Parameters.AddWithValue("ORDERID", orderId);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    idsList.Add(Convert.ToInt32(reader[0]));
                }
            }
            return idsList;
        }

        public OrderStatus GetOrderStatus(int orderId)
        {
            MySqlCommand cmd = new MySqlCommand(
                "Select Status from `order` Where ID = @ID",
                connection);

            cmd.Parameters.AddWithValue("@ID", orderId);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                reader.Read();
                return orderStatusDictionary[reader[0].ToString()];
            }
        }

        public void ChangeStatus(int orderId, OrderStatus orderStatus)
        {
            MySqlCommand cmd = new MySqlCommand(
                "UPDATE `order` SET`Status`= @ORDERSTATUS WHERE ID = @ORDERID",
                connection);
            cmd.Parameters.AddWithValue("ORDERSTATUS", orderStatus.ToString());
            cmd.Parameters.AddWithValue("ORDERID", orderId);

            cmd.ExecuteNonQuery();
        }

        public void UpdateOrderNote(int orderId, string note)
        {
            MySqlCommand cmd = new MySqlCommand
                (
                "UPDATE `order` SET `Note`= @NOTE WHERE ID = @ORDERID",
                connection
                );

            cmd.Parameters.AddWithValue("NOTE", note);
            cmd.Parameters.AddWithValue("ORDERID", orderId);

            cmd.ExecuteNonQuery();
        }

        public bool AdjustQuantity(int orderId, int itemId, string symbol)
        {
            MySqlCommand cmd = new MySqlCommand(
                "Update `order_line` set " +
                $"`Quantity`= `Quantity` {symbol} 1 Where orderId =@ORDERID And ItemId =@ITEMID",
                connection);

            cmd.Parameters.AddWithValue("@ORDERID", orderId);
            cmd.Parameters.AddWithValue("@ITEMID", itemId);

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public int GetItemQuantity(int orderid, int itemId)
        {
            MySqlCommand cmd = new MySqlCommand("Select Quantity from `order_line` where orderId = @ORDERID AND itemId = @ITEMID", connection);

            cmd.Parameters.AddWithValue("ITEMID", itemId);
            cmd.Parameters.AddWithValue("ORDERID", orderid);

            object total = cmd.ExecuteScalar();
            if (total is DBNull)
            {
                return 0;
            }
            return Convert.ToInt32(total);

        }

        public bool RemoveItem(int orderId, int itemId)
        {
            MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM `order_line` WHERE OrderID =@ORDERID AND ItemID =@ITEMID",
                connection);

            cmd.Parameters.AddWithValue("@ORDERID", orderId);
            cmd.Parameters.AddWithValue("@ITEMID", itemId);

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }

            return false;
        }

        public bool IsItemInOrder(int orderId, int itemId)
        {
            MySqlCommand cmd = new MySqlCommand(
                "Select itemId from `order_line` where itemId =@ITEMID AND orderId = @ORDERID"
                , connection);

            cmd.Parameters.AddWithValue("@ITEMID", itemId);
            cmd.Parameters.AddWithValue("@ORDERID", orderId);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;

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
