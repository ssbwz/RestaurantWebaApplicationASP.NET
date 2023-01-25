using MySql.Data.MySqlClient;


namespace Shawarma.DataAccess
{
    public class Connection
    {
        private static MySqlConnection? conn;


        public static void Reconnect()
        {
            CloseConnection();
            conn = Connect;
        }

        public static MySqlConnection Connect
        {
            get
            {
                if (conn == null)
                {
                    conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi488364;Database=dbi488364;Pwd=123Saeed;");
                    conn.Open();
                }
                return conn;
            }
        }

        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            conn = null;
        }
    }
}
