using MySql.Data.MySqlClient;

namespace Shawarma_website.DataAccess
{
    public class Connection
    {

        public Connection()
        {
                StartConnecting();           
        }

        public bool StartConnecting()
        {
            try
            {
                Connect = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi488364;Database=dbi488364;Pwd=123Saeed;");
                Connect.Open();
                return true;
            }
            catch (Exception)
            {
                //Add Methods to save the errors
                Connect.Close();
                return false;
            }

        }
        public void Reconnect() 
        {
            Connect.Close();
            StartConnecting();
        }
        public MySqlConnection Connect
        {
            get;
            set;
        }
    }
}
