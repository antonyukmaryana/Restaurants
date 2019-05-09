using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace Restaurant.Models
{
  public class Cuisine
  {
    private string _name;
    private string _description;
    private int _id;

    public Cuisine (string name, string description, int id = 0)
    {
      _name = name;
      _description = description;
      _id = id;
    }
    public int GetId()
    {
      return _id;
    }
    public int SetId (int newId)
    {
    _id = newId;
    }

    public string GetName()
    {
      return _name;
    }
    public string SetName (string newName)
    {
      _name = newName;
    }

    public string GetDescription()
    {
      return _description;
    }
    public string SetDescription (string newDescription)
    {
      _description = newDescription;
    }
    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allTypes = new List<Cuisine>{};
      MySqlCnnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cuisine;";
      MySqlDataeader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string cuisineName = rdr.GetString(0);
        string cuisineDescription = rdr.GetString(1);
        int cuisineId =  GetInt32(2);
        Cuisine newCuisine = new Cuisine (cuisineName, cuisineDescription, cuisineId);
        allTypes.Add(newCuisine);
      }
      conn.Close();

     if (conn != null)
     {
       conn.Dispose();
     }
     return allPlaces;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand()as MySqlCommand;
      cmd.CommandText = @"INSERT INTO cuisine (name, description) VALUES(@CuisineName, @CuisineDescription);";

      MySqlParameter name = new MySqlParameter();
     name.ParameterName = "@CuisineName";
     name.Value = this._name;
     cmd.Parameters.Add(name);
     //
     MySqlParameter description = new MySqlParameter();
    description.ParameterName = "@CuisineDescription";
    description.Value = this._description;
    cmd.Parameters.Add(description);

    cmd.ExecuteNonQuery();
    _id = (int) cmd.LastInsertedId;
     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
    }
  }
}
