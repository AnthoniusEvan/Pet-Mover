using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbSalesPurchasing;
using MySql.Data.MySqlClient;
namespace petMover_Final_Project
{
    public class City
    {
        #region Data Members
        int id;
        string name;
        string province;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Province { get => province; set => province = value; }
        #endregion

        #region Constructors
        public City(int id)
        {
            Id = id;
        }
        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public City(int id, string name, string province)
        {
            Id = id;
            Name = name;
            Province = province;
        }
        #endregion

        #region Methods
        public static List<City> Get(string searchCriteria, string criteriaValue)
        {
            string sql = "";
            if (searchCriteria == "")
            {
                sql = "SELECT * FROM city";
            }
            else if (searchCriteria == "any")
            {
                sql = "SELECT * FROM city WHERE Id = '" + criteriaValue + "' OR Name LIKE '%" + criteriaValue + "%' OR Province LIKE '%" + criteriaValue + "%'";
            }
            else
            {
                sql = "SELECT * FROM city WHERE "+ searchCriteria + " = " + criteriaValue;
            }
            MySqlDataReader results = dbConnection.ExecuteQuery(sql);
            List<City> list = new List<City>();
            while (results.Read() == true)
            {
                City city = new City(results.GetInt32(0), results.GetString(1), results.GetString(2));
                list.Add(city);
            }
            return list;
        }
        public static City GetByCode(string categoryCode)
        {
            List<City> results = City.Get("Id", categoryCode);
            return results[0];
        }

        public static int Add(City newRecord)
        {
            newRecord.Name = newRecord.Name.Replace("'", "\\");
            string sql = "INSERT INTO city(Id, Name, Province) VALUES ('" + newRecord.Id + "','" + newRecord.Name + "','" + newRecord.Province + "')";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Edit(City editRecord)
        {
            editRecord.Name = editRecord.Name.Replace("'", "\\");
            string sql = "UPDATE city SET Name = '" + editRecord.Name + "', Province = '" + editRecord.Province + "' WHERE Id = '" + editRecord.Id + "'";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public static int Delete(City deleteRecord)
        {
            string sql = "DELETE FROM city WHERE Id = '" + deleteRecord.Id + "';";

            return dbConnection.ExecuteNonQuery(sql);
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
