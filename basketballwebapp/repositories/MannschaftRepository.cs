using basketballwebapp.Models;
using Npgsql;

namespace basketballwebapp.repositories;

public class MannschaftRepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=basketballverwaltung;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        
        connection.Open();
        return connection;
    }
    
    
    
    public List<Mannschaft> GetAllMannschafts()
    {
        //conncect to db
        NpgsqlConnection myConnection = ConnectToDB();
        //sql query ausführen
        
        using NpgsqlCommand cmd = new NpgsqlCommand(cmdText:"Select * from Mannschaft;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Mannschaft> mannschafts = new List<Mannschaft>();
        while (reader.Read())
        {
            //datensätze in objekte verwandeln
            Mannschaft newMannschaft = new Mannschaft();
            newMannschaft.mannschaftId = (int)reader["mannschaftId"];
            newMannschaft.mannschaftsname = (string)reader["mannschaftsname"];
            newMannschaft.trainer = (string)reader["trainer"];
            
            mannschafts.Add(newMannschaft);
            
        }
        
        
        myConnection.Close();
        //mit return zurückgeben
        return mannschafts;
    }

    public void CreateMannschaft(Mannschaft mannschaft)
    {
        
    }

    public void DeleteMannschaft(int mannschaftId)
    {
        
    }

    public void UpdateMannschaft(Mannschaft mannschaft)
    {
        
    }
    
    
}