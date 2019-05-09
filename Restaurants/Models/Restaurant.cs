using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace Restaurant.Models
{
  public class Restaurant
  {
    private string _name;
    private int _cuisineId;
    private string _cuisine;
    private int _id;

    public Restaurant(string name, int cuisineId, string cuisine, int id = 0)
    {
        _name = name;
        _cuisineId = cuisineId;
        _cuisine = cuisine;
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
    public void SetName (string newName)
    {
      _name = newName;
    }
    public int GetCuisineId()
    {
      return _cuisineId;
    }
    public int SetCuisineId (int newCuisineId)
    {
      _cuisineId = newCuisineId;
    }
    public int GetCuisine()
    {
      return _cuisineId;
    }
    public string SetCuisine(string newCuisine)
    {
      _cuisine = newCuisine;
    }

    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allPlaces = new List<Restaurant>{};
      MySqlCnnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurant;";
      MySqlDataeader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string restaurantName = rdr.GetString(0);
        int restaurantCuisineId = rdr.GetInt32(1);
        string restaurantCuisine = rdr.GetString(2);
        int restaurantId =  GetInt32(3);
        Restaurant newRestaurant = new Restaurant (restaurantName, restaurantCuisineId, restaurantCuisine, restaurantId);
        allPlaces.Add(newRestaurant);
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
      cmd.CommandText = @"INSERT INTO restaurant (name, cuisine_id, cuisine) VALUES(@RestaurantName, @RestaurantCuisineId, @RestaturantCuisine);";
      MySqlParameter name = new MySqlParameter();
     name.ParameterName = "@RestaurantName";
     name.Value = this._name;
     cmd.Parameters.Add(name);
     //
     MySqlParameter cuisine_id = new MySqlParameter();
     cuisine_id.ParameterName = "@RestaurantCuisineId";
     cuisine_id.Value = this._cuisineId;
     cmd.Parameters.Add(cuisine_id);
     //
     MySqlParameter cuisine = new MySqlParameter();
     cuisine.ParameterName = "@RestaurantCuisine";
     cuisine.Value = this._cuisine;
     cmd.Parameters.Add(type);

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
