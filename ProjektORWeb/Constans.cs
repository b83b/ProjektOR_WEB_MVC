namespace ProjektORWeb
{
    public class Constans
    {
        public static string ConnectionString = "";

        public static string ConnectionStr(string login, string haslo)
        {
            ConnectionString = $"Data Source=DESKTOP-BBU712F; Initial Catalog=ProjektOR;User ID={login};Password={haslo}; " +
            "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;" +
            " Integrated Security=False; TrustServerCertificate=True";

            return ConnectionString;
        }
        


        //SqlConnection con = new SqlConnection(ConnectionString);
        //SqlCommand com = new SqlCommand();
        //com.Connection = con;


        //SqlConnection con = new SqlConnection(Constants.ConnectionString); - dziala dla windows authentication
        //SqlCommand com = new SqlCommand();
        //com.Connection = con;
        //string sql = "SELECT * FROM Uzytkownik WHERE Login = @login AND Haslo = @haslo";
        //com.CommandText = sql; // TO ZAPYTANIE LECI DO SERWERA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //com.Parameters.AddWithValue("@login", loginTextBox.Text);
        //com.Parameters.AddWithValue("@haslo", hasloTextBox.Text);
    }
}
