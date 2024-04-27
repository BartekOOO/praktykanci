using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
public class Functions
{
    public static ObservableCollection<Apprentices> addData(ObservableCollection<Apprentices> data1, ObservableCollection<Apprentices> data2) {
        try
        {
            foreach (Apprentices apprent in data2)
            {
                data1.Add(apprent);
            }
            return data1;
        }
        catch(Exception ex) {
            return new ObservableCollection<Apprentices>();
        }
    }

    public static string dataToString(DateTime date)
    {
        return date.Day.ToString("00") + "-" + date.Month.ToString("00") + "-" + date.Year.ToString();

    }

    public static ObservableCollection<Apprentices> getDataFromDataBase()
    {
        ObservableCollection<Apprentices> data = new ObservableCollection<Apprentices>();
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString);
            conn.Open();

            int index = 1;

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Praktykanci;";

            SqlDataReader reader = cmd.ExecuteReader();

            

            while (reader.Read())
            {
                data.Add(new Apprentices(index, reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6)));
                index++;
            }
            conn.Close();
            return data;
        }
        catch
        {
            return new ObservableCollection<Apprentices>();
        }
        
    }

    public static void querryCommand(string command)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        catch
        {

        }
    }

    public static int lastIndex()
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id FROM dbo.Praktykanci;";

            SqlDataReader reader = cmd.ExecuteReader();
            int index = 0;
            while (reader.Read())
            {
                index = reader.GetInt32(0);
            }
            conn.Close();
            return index;
        }
        catch
        {
            return 0;
        }
    }

}
