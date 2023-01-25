using MySql.Data.MySqlClient;
using Shawarma.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shawarma.DataAccess
{
    public class ItemStorage    
    {
         

        public ItemStorage()
        {
        }

        private MySqlConnection connection { get { return Connection.Connect; } }


        public bool AddItem(ItemOTD item)
        {

            string sql = "INSERT INTO `item`(`ID`, `Name`, `Description`, `Price`, `Discount`, `Category`, `DishType`) VALUES (NULL,@NAME,@DESCRIPTION,@PRICE,@DISCOUNT,@CATEGORY,@DISHTYPE)";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@NAME", item.Name);
            cmd.Parameters.AddWithValue("@DESCRIPTION", item.Description);
            cmd.Parameters.AddWithValue("@DISCOUNT", item.Discount);
            cmd.Parameters.AddWithValue("@PRICE", item.Price);
            cmd.Parameters.AddWithValue("@CATEGORY", item.Category.ToString());
            cmd.Parameters.AddWithValue("@DISHTYPE", getItemType(item));

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public List<ItemOTD> GetItems()
        {
            List<ItemOTD> items = new List<ItemOTD>();

            string sql = $"SELECT `ID`, `Name`, `Description`, `Price`, `Discount`, `Category`, `DishType` FROM `item`";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    if (reader[6].ToString() == "NORMAL")
                    {
                        NormalItemOTD normalItem = new NormalItemOTD();

                        normalItem.Id = Convert.ToInt32(reader[0]);
                        normalItem.Name = reader[1].ToString();
                        normalItem.Description = reader[2].ToString();
                        normalItem.Price = Convert.ToDouble(reader[3]);
                        normalItem.Discount = Convert.ToDouble(reader[4]);
                        normalItem.Category = getCategory(reader[5].ToString());

                        items.Add(normalItem);
                    }

                    if (reader[6].ToString() == "HOILDAY")
                    {
                        HoildayItemOTD hoildayItem = new HoildayItemOTD();

                        hoildayItem.Id = Convert.ToInt32(reader[0]);
                        hoildayItem.Name = reader[1].ToString();
                        hoildayItem.Description = reader[2].ToString();
                        hoildayItem.Price = Convert.ToDouble(reader[3]);
                        hoildayItem.Discount = Convert.ToDouble(reader[4]);
                        hoildayItem.Category = getCategory(reader[5].ToString());

                        items.Add(hoildayItem);

                    }

                    if (reader[6].ToString() == "SUMMER")
                    {
                        SummerItemOTD summerItem = new SummerItemOTD();

                        summerItem.Id = Convert.ToInt32(reader[0]);
                        summerItem.Name = reader[1].ToString();
                        summerItem.Description = reader[2].ToString();
                        summerItem.Price = Convert.ToDouble(reader[3]);
                        summerItem.Discount = Convert.ToDouble(reader[4]);
                        summerItem.Category = getCategory(reader[5].ToString());

                        items.Add(summerItem);
                    }
                }
            }
            return items;
        }

        public ItemOTD GetItem(int id)
        {
            if (id == -1)
            {
                return null;
            }

            ItemOTD item = null;

            string sql = $"SELECT `ID`, `Name`, `Description`, `Price`, `Discount`,`Category`,`DishType` FROM item WHERE id = @ID";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@ID", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    if (reader[6].ToString() == "NORMAL")
                    {
                        NormalItemOTD normalItem = new NormalItemOTD();
                        normalItem.Id = Convert.ToInt32(reader[0]);
                        normalItem.Name = reader[1].ToString();
                        normalItem.Description = reader[2].ToString();
                        normalItem.Price = Convert.ToDouble(reader[3]);
                        normalItem.Discount = Convert.ToDouble(reader[4]);
                        normalItem.Category = getCategory(reader[5].ToString());
                        return normalItem;
                    }

                    else if (reader[6].ToString() == "HOILDAY")
                    {
                        HoildayItemOTD hoildayItem = new HoildayItemOTD();
                        hoildayItem.Id = Convert.ToInt32(reader[0]);
                        hoildayItem.Name = reader[1].ToString();
                        hoildayItem.Description = reader[2].ToString();
                        hoildayItem.Price = Convert.ToDouble(reader[3]);
                        hoildayItem.Discount = Convert.ToDouble(reader[4]);
                        hoildayItem.Category = getCategory(reader[5].ToString());
                        return hoildayItem;
                    }

                    else
                    {
                        SummerItemOTD summerItem = new SummerItemOTD();
                        summerItem.Id = Convert.ToInt32(reader[0]);
                        summerItem.Name = reader[1].ToString();
                        summerItem.Description = reader[2].ToString();
                        summerItem.Price = Convert.ToDouble(reader[3]);
                        summerItem.Discount = Convert.ToDouble(reader[4]);
                        summerItem.Category = getCategory(reader[5].ToString());
                        return summerItem;
                    }
                }
            }
            return null;
        }

        public bool UpdateItem(ItemOTD item)
        {

            string sql = "UPDATE `item` SET `Name`=@NAME,`Description`=@DESCRIPTION,`Price`=@PRICE,`Discount`=@DISCOUNT,`Category`=@CATEGORY,`DishType`= @DISHTYPE WHERE ID = @ID";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@ID", item.Id);
            cmd.Parameters.AddWithValue("@NAME", item.Name);
            cmd.Parameters.AddWithValue("@DESCRIPTION", item.Description);
            cmd.Parameters.AddWithValue("@PRICE", item.Price);
            cmd.Parameters.AddWithValue("@DISCOUNT", item.Discount);
            cmd.Parameters.AddWithValue("@CATEGORY", item.Category.ToString());
            cmd.Parameters.AddWithValue("@DISHTYPE", getItemType(item));


            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public bool DeleteItem(int id)
        {
            if (id == -1)
            {
                return false;
            }

            string sql = "DELETE FROM `item` WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@ID", id);

            int effectedRows = cmd.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                return true;
            }
            return false;
        }

        public int GetTheLastID()
        {
            MySqlCommand cmd = new MySqlCommand(
                "SELECT Max(ID) FROM `item`"
                , connection);

            return (int)cmd.ExecuteScalar();
        }

        private Category getCategory(string category)
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

        private string getItemType(ItemOTD item)
        {
            if (item is NormalItemOTD)
            {
                return "NORMAL";
            }
            if (item is SummerItemOTD)
            {
                return "SUMMER";
            }
            else
            {
                return "HOILDAY";
            }
        }

        public string GetDishType(int itemId)
        {
            MySqlCommand cmd = new MySqlCommand(
                "Select DishType from `item` where ID= @ID", 
                connection);

            cmd.Parameters.AddWithValue("@ID", itemId);

            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader) 
            {
                reader.Read();
                return reader.GetString(0);
            }
        }
    }
}
