using System.Data.SqlClient;

namespace AmbientWeather.Controllers
{
    //pS9UCznx4C#9
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
            new(() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        private Singleton()
        {
            //TODO
            //Open db connection with singleton, hold connection here
            //Use appsettions.json for connection string
        }

        public void InsertData(Dictionary<string, string> values)
        {
            
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Server=192.168.1.14;Database=Weather;User Id=WeatherApp;Password=pS9UCznx4C#9;";
                conn.Open();

                // Create the command  
                SqlCommand command = new SqlCommand("INSERT INTO dbo.WeatherRaw (stationtype ,PASSKEY ,dateutc ,tempinf ,humidityin ,baromrelin ,baromabsin ,tempf ,battout ,humidity ,winddir ,windspeedmph ,windgustmph ,maxdailygust ,hourlyrainin ,eventrainin ,dailyrainin ,weeklyrainin ,monthlyrainin ,totalrainin ,solarradiation ,uv ,temp1f ,humidity1 ,batt1 ,batt_co2)"
                            + " VALUES (@0 ,@1 ,@2 ,@3 ,@4 ,@5 ,@6 ,@7 ,@8 ,@9 ,@10 ,@11 ,@12 ,@13 ,@14 ,@15 ,@16 ,@17 ,@18 ,@19 ,@20 ,@21 ,@22 ,@23 ,@24 ,@25)", conn);
                
                // Add the parameters.  
                command.Parameters.Add(new SqlParameter("0", values["stationtype"]));
                command.Parameters.Add(new SqlParameter("1", values["PASSKEY"]));
                command.Parameters.Add(new SqlParameter("2", values["dateutc"]));
                command.Parameters.Add(new SqlParameter("3", values["tempinf"]));
                command.Parameters.Add(new SqlParameter("4", values["humidityin"]));
                command.Parameters.Add(new SqlParameter("5", values["baromrelin"]));
                command.Parameters.Add(new SqlParameter("6", values["baromabsin"]));
                command.Parameters.Add(new SqlParameter("7", values["tempf"]));
                command.Parameters.Add(new SqlParameter("8", values["battout"]));
                command.Parameters.Add(new SqlParameter("9", values["humidity"]));
                command.Parameters.Add(new SqlParameter("10", values["winddir"]));
                command.Parameters.Add(new SqlParameter("11", values["windspeedmph"]));
                command.Parameters.Add(new SqlParameter("12", values["windgustmph"]));
                command.Parameters.Add(new SqlParameter("13", values["maxdailygust"]));
                command.Parameters.Add(new SqlParameter("14", values["hourlyrainin"]));
                command.Parameters.Add(new SqlParameter("15", values["eventrainin"]));
                command.Parameters.Add(new SqlParameter("16", values["dailyrainin"]));
                command.Parameters.Add(new SqlParameter("17", values["weeklyrainin"]));
                command.Parameters.Add(new SqlParameter("18", values["monthlyrainin"]));
                command.Parameters.Add(new SqlParameter("19", values["totalrainin"]));
                command.Parameters.Add(new SqlParameter("20", values["solarradiation"]));
                command.Parameters.Add(new SqlParameter("21", values["uv"]));
                command.Parameters.Add(new SqlParameter("22", values["temp1f"]));
                command.Parameters.Add(new SqlParameter("23", values["humidity1"]));
                command.Parameters.Add(new SqlParameter("24", values["batt1"]));
                command.Parameters.Add(new SqlParameter("25", values["batt_co2"]));

                //use the connection here
                command.ExecuteNonQuery();
            }
        }
    }
}
